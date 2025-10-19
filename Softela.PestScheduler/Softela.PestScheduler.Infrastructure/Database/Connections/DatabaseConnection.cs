using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Softela.PestScheduler.Infrastructure.Database.Connections
{
    public class DatabaseConnection : DatabaseConnectionStringProvider, IDatabaseConnection
    {
        public DatabaseConnection(DatabaseOptions dbOptions, IConfiguration configuration) : base(dbOptions, configuration)
        { }

        public IDbConnection GetConnection() => new SqlConnection(GetConnectionString());
    }
}
