using MediatR;

namespace Softela.PestScheduler.Application.Core.Command
{
    public interface ICommandDispatcher
    {
        Task<TResponse> SendAsync<TResponse, T>(T command, CancellationToken cancellationToken) where T : IRequest<TResponse>;
    }
}
