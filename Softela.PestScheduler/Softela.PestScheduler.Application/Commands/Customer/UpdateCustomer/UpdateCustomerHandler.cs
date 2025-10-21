using MediatR;
using Microsoft.Extensions.Logging;
using Softela.PestScheduler.Application.Mappers;
using Softela.PestScheduler.Application.Repositories;

namespace Softela.PestScheduler.Application.Commands.Customer.UpdateCustomer
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerRequest, bool>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<UpdateCustomerHandler> _logger;

        public UpdateCustomerHandler(ICustomerRepository customerRepository, ILogger<UpdateCustomerHandler> logger)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(UpdateCustomerRequest request, CancellationToken cancellationToken)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));
            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                _logger.LogInformation("Handling UpdateCustomerRequest for AccountId={AccountId}", request.AccountId);

                var entity = request.ToEntity();
                var id = await _customerRepository.UpsertAsync(entity);

                _logger.LogInformation("UpdateCustomerRequest completed successfully. Resulting Id={Id}", id);
                return true;
            }
            catch (OperationCanceledException)
            {
                _logger.LogWarning("UpdateCustomerRequest was cancelled for AccountId={AccountId}", request.AccountId);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while handling UpdateCustomerRequest for AccountId={AccountId}", request.AccountId);
                return false;
            }
        }
    }
}
