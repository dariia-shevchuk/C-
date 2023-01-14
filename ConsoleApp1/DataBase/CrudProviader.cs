using ConsoleApp1.Interfaces;
using ConsoleApp1.Models;

namespace ConsoleApp1.DataBase
{
    public class CrudProviader : ICrudProvider<Car>
    {
        public CrudProviader(ISqlCrud<Car> sqlCrud, IMongCrud<Car> mongoCrud)
        {
            _sqlCrud = sqlCrud;
            _mongoCrud = mongoCrud;
        }

        private ICrud<Car> _crud = new SqlCrud();
        private readonly ISqlCrud<Car> _sqlCrud;
        private readonly IMongCrud<Car> _mongoCrud;

        private string _dbType;

        public ICrud<Car> GetCrud()
        {
            if (_dbType == "Sql")
                return _sqlCrud;
            else
                return _mongoCrud;
        }

        public void SetCurrentCrudOption(string dbName)
        {
            _dbType = dbName;
        }
    }
}
