using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interfaces
{
    public interface ICrud<T>
    {
        void Add(T entity);
    }

    ///Marker
    public interface IMongCrud<T> : ICrud<T>
    {

    }

    ///Marker
    public interface ISqlCrud<T> : ICrud<T>
    {

    }
}
