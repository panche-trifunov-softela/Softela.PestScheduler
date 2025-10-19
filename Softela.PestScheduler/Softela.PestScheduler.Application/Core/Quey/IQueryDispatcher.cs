using MediatR;

namespace Softela.PestScheduler.Application.Core.Quey
{
    public interface IQueryDispatcher
    {
        Task<TResponse> QueryAsync<TResponse>(IRequest<TResponse> query, CancellationToken cancellationToken);
    }
}
