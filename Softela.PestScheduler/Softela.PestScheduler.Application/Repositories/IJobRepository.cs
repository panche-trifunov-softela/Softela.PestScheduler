using Softela.PestScheduler.Domain.Entities;

namespace Softela.PestScheduler.Application.Repositories
{
    public interface IJobRepository
    {
        Task<long> InsertAsync(Job job);
        Task UpdateAsync(Job job);
        Task<long> UpsertAsync(Job job);
        Task<Job?> GetByIdAsync(long id);
        Task<IEnumerable<Job>> FilterAsync(object? filterParams = null);
    }
}
