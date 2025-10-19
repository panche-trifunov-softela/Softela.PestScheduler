using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Softela.PestScheduler.Infrastructure.Database.Connections
{
    public class DatabaseConnectionStringProvider
    {
        private readonly DatabaseOptions _dbOptions;
        private readonly IConfiguration _configuration;

        public DatabaseConnectionStringProvider(DatabaseOptions dbOptions, IConfiguration configuration)
        {
            _dbOptions = dbOptions;
            _configuration = configuration;
        }

        public string GetConnectionString()
        {
            var connectionStringConfig = _configuration.GetValue<string>("ConnectionString");
            if (!string.IsNullOrWhiteSpace(connectionStringConfig))
            {
                return connectionStringConfig;
            }

            var builder = new SqlConnectionStringBuilder(_dbOptions.Configuration)
            {
                DataSource = _dbOptions.Server,
                InitialCatalog = _dbOptions.Name,
                UserID = _dbOptions.Username,
                Password = _dbOptions.Password,
                Encrypt = true,
                TrustServerCertificate = true
            };
            return builder.ConnectionString;
        }
    }
}
