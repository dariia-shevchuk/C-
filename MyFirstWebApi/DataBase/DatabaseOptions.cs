using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWebApi.DataBase
{
    public class DatabaseOptions
    {
        public string ConnectionString { get; }

        public DatabaseOptions(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}