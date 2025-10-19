using Microsoft.Data.SqlClient;
using Softela.PestScheduler.Infrastructure.Database.Connections;
using System.Data;

namespace Softela.PestScheduler.Infrastructure.Database.Dapper
{
    public sealed class DapperDataContext : IDapperDataContext
    {
        private readonly string? _connectionString;

        private IDbConnection? _connection;
        private IDbTransaction? _transaction;

        public DapperDataContext(IDatabaseConnection dbConnection)
        {
            _connectionString = dbConnection.GetConnectionString();
        }

        public IDbConnection? Connection
        {
            get
            {
                if (_connection is null || _connection.State != ConnectionState.Open)
                {
                    _connection = new SqlConnection(_connectionString);
                }

                return _connection;
            }
        }

        public IDbTransaction? Transaction
        {
            get => _transaction;
            set => _transaction = value;
        }
    }
}
