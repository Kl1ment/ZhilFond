using Npgsql;
using System.Data;

namespace ZhilFond.DataAccess
{
    public interface IDapperDbContext
    {
        IDbConnection Connection { get; }
    }
}