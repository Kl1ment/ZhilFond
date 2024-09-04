using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace ZhilFond.DataAccess
{
    public class DapperDbContext(IConfiguration configuration) : IDapperDbContext
    {
        public IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(configuration.GetConnectionString(nameof(ZhilFondDbContext)));
            }
        }
    }
}
