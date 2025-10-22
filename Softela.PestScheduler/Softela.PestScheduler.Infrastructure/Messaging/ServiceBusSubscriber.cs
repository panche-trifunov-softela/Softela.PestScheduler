using Azure.Messaging.ServiceBus;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Softela.PestScheduler.Application.Commands.Customer.CreateCustomer;
using Softela.PestScheduler.Application.Commands.Customer.UpdateCustomer;
using Softela.PestScheduler.Application.Commands.Job.CreateJob;
using Softela.PestScheduler.Application.Commands.Job.UpdateJob;
using System.Text.Json;
namespace Softela.PestScheduler.Infrastructure.Messaging
{
    public class ServiceBusSubscriber : IHostedService, IAsyncDisposable
    {
        private readonly ServiceBusClient _client;
        private ServiceBusProcessor? _processor;
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        private readonly ILogger<ServiceBusSubscriber> _logger;

        public ServiceBusSubscriber(
            ServiceBusClient client,
            IMediator mediator,
            IConfiguration configuration,
            ILogger<ServiceBusSubscriber> logger)
        {
            _client = client;
            _mediator = mediator;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var queueOrTopic = _configuration["AzureServiceBus:QueueName"] ?? throw new InvalidOperationException("AzureServiceBus:QueueName missing");
            var subscription = _configuration["AzureServiceBus:SubscriptionName"]; // optional if you're using topics/subscriptions

            _logger.LogInformation("Starting ServiceBusSubscriber for {QueueOrTopic}", queueOrTopic);

            var options = new ServiceBusProcessorOptions
            {
                MaxConcurrentCalls = 1,
                AutoCompleteMessages = false
            };

            // If using a subscription, create processor for topic/subscription:
            if (!string.IsNullOrEmpty(subscription))
            {
                _processor = _client.CreateProcessor(queueOrTopic, subscription, options);
            }
            else
            {
                _processor = _client.CreateProcessor(queueOrTopic, options);
            }

            _processor.ProcessMessageAsync += ProcessMessageAsync;
            _processor.ProcessErrorAsync += ProcessErrorAsync;

            await _processor.StartProcessingAsync(cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopping ServiceBusSubscriber");
            if (_processor is null) return;

            await _processor.StopProcessingAsync(cancellationToken);
            _processor.ProcessMessageAsync -= ProcessMessageAsync;
            _processor.ProcessErrorAsync -= ProcessErrorAsync;
        }

        private async Task ProcessMessageAsync(ProcessMessageEventArgs args)
        {
            var body = args.Message.Body.ToString();
            _logger.LogDebug("ServiceBus message received: SequenceNumber={SequenceNumber} Body={Body}",
                args.Message.SequenceNumber, body);

            var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            try
            {
                using var doc = JsonDocument.Parse(body);
                var root = doc.RootElement;

                // Try explicit discriminator fields first
                string? messageType = null;
                if (root.TryGetProperty("messageType", out var mtProp) && mtProp.ValueKind == JsonValueKind.String)
                    messageType = mtProp.GetString();
                else if (root.TryGetProperty("type", out var tProp) && tProp.ValueKind == JsonValueKind.String)
                    messageType = tProp.GetString();

                bool processed = false;

                if (!string.IsNullOrEmpty(messageType))
                {
                    messageType = messageType!.Trim();
                    if (string.Equals(messageType, "CreateJob", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(messageType, "JobCreated", StringComparison.OrdinalIgnoreCase))
                    {
                        processed = await HandleCreateJobAsync(body, args, jsonOptions);
                    }
                    else if (string.Equals(messageType, "UpdateJob", StringComparison.OrdinalIgnoreCase) ||
                             string.Equals(messageType, "JobUpdated", StringComparison.OrdinalIgnoreCase))
                    {
                        processed = await HandleUpdateJobAsync(body, args, jsonOptions);
                    }
                    else if (string.Equals(messageType, "CreateCustomer", StringComparison.OrdinalIgnoreCase) ||
                             string.Equals(messageType, "CustomerCreated", StringComparison.OrdinalIgnoreCase))
                    {
                        processed = await HandleCreateCustomerAsync(body, args, jsonOptions);
                    }
                    else if (string.Equals(messageType, "UpdateCustomer", StringComparison.OrdinalIgnoreCase) ||
                             string.Equals(messageType, "CustomerUpdated", StringComparison.OrdinalIgnoreCase))
                    {
                        processed = await HandleUpdateCustomerAsync(body, args, jsonOptions);
                    }
                }
                else
                {
                    // Fallback inference by presence of known properties (best-effort)
                    if (root.TryGetProperty("eventId", out _))
                    {
                        // eventId could be create or update — prefer Update if it has fields typical for update
                        if (root.TryGetProperty("completedDate", out _) || root.TryGetProperty("completedAmount", out _))
                            processed = await HandleUpdateJobAsync(body, args, jsonOptions);
                        else
                            processed = await HandleCreateJobAsync(body, args, jsonOptions);
                    }
                    else if (root.TryGetProperty("accountId", out _))
                    {
                        // accountId could be create or update — prefer Update if it has program fields or many address fields
                        if (root.TryGetProperty("programSaleDate", out _) || root.TryGetProperty("billingAddressId", out _))
                            processed = await HandleUpdateCustomerAsync(body, args, jsonOptions);
                        else
                            processed = await HandleCreateCustomerAsync(body, args, jsonOptions);
                    }
                }

                if (!processed)
                {
                    _logger.LogWarning("Message could not be mapped to any known command. SequenceNumber={SequenceNumber}", args.Message.SequenceNumber);
                    // Abandon to allow retry or move to DLQ depending on Service Bus configuration
                    await args.AbandonMessageAsync(args.Message, cancellationToken: args.CancellationToken);
                }
            }
            catch (JsonException jex)
            {
                _logger.LogError(jex, "Invalid JSON message. Abandoning message. SequenceNumber={SequenceNumber}", args.Message.SequenceNumber);
                try
                {
                    await args.AbandonMessageAsync(args.Message, cancellationToken: args.CancellationToken);
                }
                catch (Exception abandonEx)
                {
                    _logger.LogError(abandonEx, "Failed to abandon message.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing Service Bus message. Abandoning message. SequenceNumber={SequenceNumber}", args.Message.SequenceNumber);
                try
                {
                    await args.AbandonMessageAsync(args.Message, cancellationToken: args.CancellationToken);
                }
                catch (Exception abandonEx)
                {
                    _logger.LogError(abandonEx, "Failed to abandon message.");
                }
            }
        }

        private async Task<bool> HandleCreateJobAsync(string body, ProcessMessageEventArgs args, JsonSerializerOptions jsonOptions)
        {
            try
            {
                var request = JsonSerializer.Deserialize<CreateJobRequest>(body, jsonOptions);
                if (request is null)
                {
                    _logger.LogWarning("Deserialized CreateJobRequest was null. SequenceNumber={SequenceNumber}", args.Message.SequenceNumber);
                    return false;
                }

                _logger.LogInformation("Dispatching CreateJobRequest for EventId={EventId}", request.EventId);
                var result = await _mediator.Send(request, args.CancellationToken);

                if (result)
                {
                    await args.CompleteMessageAsync(args.Message, args.CancellationToken);
                    _logger.LogInformation("CreateJobRequest processed and message completed. SequenceNumber={SequenceNumber}", args.Message.SequenceNumber);
                    return true;
                }
                else
                {
                    _logger.LogWarning("CreateJobRequest handler returned false. Abandoning message. SequenceNumber={SequenceNumber}", args.Message.SequenceNumber);
                    await args.AbandonMessageAsync(args.Message, cancellationToken: args.CancellationToken);
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception handling CreateJobRequest. Abandoning message. SequenceNumber={SequenceNumber}", args.Message.SequenceNumber);
                try { await args.AbandonMessageAsync(args.Message, cancellationToken: args.CancellationToken); } catch { /* swallow */ }
                return false;
            }
        }

        private async Task<bool> HandleUpdateJobAsync(string body, ProcessMessageEventArgs args, JsonSerializerOptions jsonOptions)
        {
            try
            {
                var request = JsonSerializer.Deserialize<UpdateJobRequest>(body, jsonOptions);
                if (request is null)
                {
                    _logger.LogWarning("Deserialized UpdateJobRequest was null. SequenceNumber={SequenceNumber}", args.Message.SequenceNumber);
                    return false;
                }

                _logger.LogInformation("Dispatching UpdateJobRequest for EventId={EventId}", request.EventId);
                var result = await _mediator.Send(request, args.CancellationToken);

                if (result)
                {
                    await args.CompleteMessageAsync(args.Message, args.CancellationToken);
                    _logger.LogInformation("UpdateJobRequest processed and message completed. SequenceNumber={SequenceNumber}", args.Message.SequenceNumber);
                    return true;
                }
                else
                {
                    _logger.LogWarning("UpdateJobRequest handler returned false. Abandoning message. SequenceNumber={SequenceNumber}", args.Message.SequenceNumber);
                    await args.AbandonMessageAsync(args.Message, cancellationToken: args.CancellationToken);
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception handling UpdateJobRequest. Abandoning message. SequenceNumber={SequenceNumber}", args.Message.SequenceNumber);
                try { await args.AbandonMessageAsync(args.Message, cancellationToken: args.CancellationToken); } catch { /* swallow */ }
                return false;
            }
        }

        private async Task<bool> HandleCreateCustomerAsync(string body, ProcessMessageEventArgs args, JsonSerializerOptions jsonOptions)
        {
            try
            {
                var request = JsonSerializer.Deserialize<CreateCustomerRequest>(body, jsonOptions);
                if (request is null)
                {
                    _logger.LogWarning("Deserialized CreateCustomerRequest was null. SequenceNumber={SequenceNumber}", args.Message.SequenceNumber);
                    return false;
                }

                _logger.LogInformation("Dispatching CreateCustomerRequest for AccountId={AccountId}", request.AccountId);
                var result = await _mediator.Send(request, args.CancellationToken);

                if (result)
                {
                    await args.CompleteMessageAsync(args.Message, args.CancellationToken);
                    _logger.LogInformation("CreateCustomerRequest processed and message completed. SequenceNumber={SequenceNumber}", args.Message.SequenceNumber);
                    return true;
                }
                else
                {
                    _logger.LogWarning("CreateCustomerRequest handler returned false. Abandoning message. SequenceNumber={SequenceNumber}", args.Message.SequenceNumber);
                    await args.AbandonMessageAsync(args.Message, cancellationToken: args.CancellationToken);
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception handling CreateCustomerRequest. Abandoning message. SequenceNumber={SequenceNumber}", args.Message.SequenceNumber);
                try { await args.AbandonMessageAsync(args.Message, cancellationToken: args.CancellationToken); } catch { /* swallow */ }
                return false;
            }
        }

        private async Task<bool> HandleUpdateCustomerAsync(string body, ProcessMessageEventArgs args, JsonSerializerOptions jsonOptions)
        {
            try
            {
                var request = JsonSerializer.Deserialize<UpdateCustomerRequest>(body, jsonOptions);
                if (request is null)
                {
                    _logger.LogWarning("Deserialized UpdateCustomerRequest was null. SequenceNumber={SequenceNumber}", args.Message.SequenceNumber);
                    return false;
                }

                _logger.LogInformation("Dispatching UpdateCustomerRequest for AccountId={AccountId}", request.AccountId);
                var result = await _mediator.Send(request, args.CancellationToken);

                if (result)
                {
                    await args.CompleteMessageAsync(args.Message, args.CancellationToken);
                    _logger.LogInformation("UpdateCustomerRequest processed and message completed. SequenceNumber={SequenceNumber}", args.Message.SequenceNumber);
                    return true;
                }
                else
                {
                    _logger.LogWarning("UpdateCustomerRequest handler returned false. Abandoning message. SequenceNumber={SequenceNumber}", args.Message.SequenceNumber);
                    await args.AbandonMessageAsync(args.Message, cancellationToken: args.CancellationToken);
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception handling UpdateCustomerRequest. Abandoning message. SequenceNumber={SequenceNumber}", args.Message.SequenceNumber);
                try { await args.AbandonMessageAsync(args.Message, cancellationToken: args.CancellationToken); } catch { /* swallow */ }
                return false;
            }
        }

        private Task ProcessErrorAsync(ProcessErrorEventArgs args)
        {
            _logger.LogError(args.Exception, "ServiceBus Processor error. EntityPath={EntityPath} ErrorSource={ErrorSource}",
                args.EntityPath, args.ErrorSource);
            return Task.CompletedTask;
        }

        public async ValueTask DisposeAsync()
        {
            if (_processor != null)
            {
                await _processor.DisposeAsync();
                _processor = null;
            }
        }
    }
}
