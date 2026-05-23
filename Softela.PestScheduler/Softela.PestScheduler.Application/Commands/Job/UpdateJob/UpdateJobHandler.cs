using MediatR;
using Microsoft.Extensions.Logging;
using Softela.PestScheduler.Application.Mappers;
using Softela.PestScheduler.Application.Repositories;

namespace Softela.PestScheduler.Application.Commands.Job.UpdateJob
{
    public class UpdateJobHandler : IRequestHandler<UpdateJobRequest, bool>
    {
        private readonly IJobRepository _jobRepository;
        private readonly ILogger<UpdateJobHandler> _logger;

        public UpdateJobHandler(IJobRepository jobRepository, ILogger<UpdateJobHandler> logger)
        {
            _jobRepository = jobRepository ?? throw new ArgumentNullException(nameof(jobRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(UpdateJobRequest request, CancellationToken cancellationToken)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));
            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                _logger.LogInformation("Handling UpdateJobRequest for EventId={EventId}", request.EventId);

                var entity = request.ToEntity();
                var id = await _jobRepository.UpsertAsync(entity);

                _logger.LogInformation("UpdateJobRequest completed successfully. Resulting Id={Id}", id);
                return true;
            }
            catch (OperationCanceledException)
            {
                _logger.LogWarning("UpdateJobRequest was cancelled for EventId={EventId}", request.EventId);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while handling UpdateJobRequest for EventId={EventId}", request.EventId);
                return false;
            }
        }
    }
}
