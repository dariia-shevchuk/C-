using ConsoleApp1.Interfaces;
using ConsoleApp1.Models;
using System.Diagnostics;


namespace ConsoleApp1.DataBase
{
    public class MongoCrud : IMongCrud<Car>
    {
        public void Add(Car entity)
        {
            Debug.WriteLine("-------------> Zapis do Mongo");
        }
    }
}
