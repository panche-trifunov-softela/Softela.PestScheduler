using MediatR;

namespace Softela.PestScheduler.Application.Core.Quey
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IMediator _mediator;

        public QueryDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<TResponse> QueryAsync<TResponse>(IRequest<TResponse> query, CancellationToken cancellationToken)
        {
            return await _mediator.Send(query, cancellationToken).ConfigureAwait(false);
        }
    }
}
