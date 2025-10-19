using Dapper;
using Softela.PestScheduler.Application.Repositories;
using Softela.PestScheduler.Domain.Entities;
using Softela.PestScheduler.Infrastructure.Database.Dapper;
using System.Data;

namespace Softela.PestScheduler.Infrastructure.Database.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly IDapperDataContext _context;

        public JobRepository(IDapperDataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<long> InsertAsync(Job job)
        {
            if (job is null) throw new ArgumentNullException(nameof(job));
            var conn = _context.Connection ?? throw new InvalidOperationException("Database connection is not available.");

            const string proc = "usp_Job_Insert";
            return await conn.QuerySingleAsync<long>(proc, job, transaction: _context.Transaction, commandType: CommandType.StoredProcedure);
        }

        public async Task<long> UpsertAsync(Job job)
        {
            if (job is null) throw new ArgumentNullException(nameof(job));
            var conn = _context.Connection ?? throw new InvalidOperationException("Database connection is not available.");

            const string proc = "usp_Job_Upsert";
            // Stored procedure must return the resulting Id (inserted or updated)
            return await conn.QuerySingleAsync<long>(proc, job, transaction: _context.Transaction, commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateAsync(Job job)
        {
            if (job is null) throw new ArgumentNullException(nameof(job));
            var conn = _context.Connection ?? throw new InvalidOperationException("Database connection is not available.");

            const string proc = "usp_Job_Update";
            await conn.ExecuteAsync(proc, job, transaction: _context.Transaction, commandType: CommandType.StoredProcedure);
        }

        public async Task<Job?> GetByIdAsync(long id)
        {
            var conn = _context.Connection ?? throw new InvalidOperationException("Database connection is not available.");

            const string proc = "usp_Job_GetById";
            return await conn.QuerySingleOrDefaultAsync<Job>(proc, new { Id = id }, transaction: _context.Transaction, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Job>> FilterAsync(object? filterParams = null)
        {
            var conn = _context.Connection ?? throw new InvalidOperationException("Database connection is not available.");

            const string proc = "usp_Job_Filter";
            return await conn.QueryAsync<Job>(proc, filterParams, transaction: _context.Transaction, commandType: CommandType.StoredProcedure);
        }
    }
}
