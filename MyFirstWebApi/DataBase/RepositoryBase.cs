using Dapper;
using System.Data.SqlClient;
using System.Linq;

namespace MyFirstWebApi.DataBase
{
    public abstract class RepositoryBase
    {
        private readonly DatabaseOptions _databaseOptions;

        protected RepositoryBase(DatabaseOptions databaseOptions)
        {
            _databaseOptions = databaseOptions;
        }

        protected T QuerySingle<T>(string sql)
               where T : class
        {
            var result = default(T);
            using (var connection = new SqlConnection(_databaseOptions.ConnectionString))
            {
                result = connection.QueryFirstOrDefault<T>(sql);
            }
            return result;
        }

        protected void Execute(string sql)
        {
            using (var connection = new SqlConnection(_databaseOptions.ConnectionString))
            {
                connection.Execute(sql);
            }
        }
    }
}