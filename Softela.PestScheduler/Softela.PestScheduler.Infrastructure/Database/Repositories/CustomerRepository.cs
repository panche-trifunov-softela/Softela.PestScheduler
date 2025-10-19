using Dapper;
using Softela.PestScheduler.Application.Repositories;
using Softela.PestScheduler.Domain.Entities;
using Softela.PestScheduler.Infrastructure.Database.Dapper;
using System.Data;

namespace Softela.PestScheduler.Infrastructure.Database.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDapperDataContext _context;

        public CustomerRepository(IDapperDataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<long> InsertAsync(Customer customer)
        {
            if (customer is null) throw new ArgumentNullException(nameof(customer));
            var conn = _context.Connection ?? throw new InvalidOperationException("Database connection is not available.");

            const string proc = "usp_Customer_Insert";
            return await conn.QuerySingleAsync<long>(proc, customer, transaction: _context.Transaction, commandType: CommandType.StoredProcedure);
        }

        public async Task<long> UpsertAsync(Customer customer)
        {
            if (customer is null) throw new ArgumentNullException(nameof(customer));
            var conn = _context.Connection ?? throw new InvalidOperationException("Database connection is not available.");

            const string proc = "usp_Customer_Upsert";
            // Stored procedure must return the resulting Id (inserted or updated)
            return await conn.QuerySingleAsync<long>(proc, customer, transaction: _context.Transaction, commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateAsync(Customer customer)
        {
            if (customer is null) throw new ArgumentNullException(nameof(customer));
            var conn = _context.Connection ?? throw new InvalidOperationException("Database connection is not available.");

            const string proc = "usp_Customer_Update";
            await conn.ExecuteAsync(proc, customer, transaction: _context.Transaction, commandType: CommandType.StoredProcedure);
        }

        public async Task<Customer?> GetByIdAsync(long id)
        {
            var conn = _context.Connection ?? throw new InvalidOperationException("Database connection is not available.");

            const string proc = "usp_Customer_GetById";
            return await conn.QuerySingleOrDefaultAsync<Customer>(proc, new { Id = id }, transaction: _context.Transaction, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Customer>> FilterAsync(object? filterParams = null)
        {
            var conn = _context.Connection ?? throw new InvalidOperationException("Database connection is not available.");

            const string proc = "usp_Customer_Filter";
            return await conn.QueryAsync<Customer>(proc, filterParams, transaction: _context.Transaction, commandType: CommandType.StoredProcedure);
        }
    }
}
