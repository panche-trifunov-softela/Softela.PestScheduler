using System.Data;

namespace Softela.PestScheduler.Infrastructure.Database.Dapper
{
    public interface IDapperDataContext
    {
        IDbConnection? Connection { get; }
        IDbTransaction? Transaction { get; set; }
    }
}
