using Softela.PestScheduler.Domain.Entities;

namespace Softela.PestScheduler.Application.Repositories
{
    public interface ICustomerRepository
    {
        Task<long> InsertAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task<long> UpsertAsync(Customer customer);
        Task<Customer?> GetByIdAsync(long id);
        Task<IEnumerable<Customer>> FilterAsync(object? filterParams = null);
    }
}
