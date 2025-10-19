using System.Data;

namespace Softela.PestScheduler.Infrastructure.Database.Connections
{
    public interface IDatabaseConnection
    {
        IDbConnection GetConnection();
        string GetConnectionString();
    }
}
