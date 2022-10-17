using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithGeneric
{
    public interface IMath<T>
    {
        T Add(T arg1, T arg2);
        T Subtract(T arg1, T arg2);
        T Multiply(T arg1, T arg2);

        T Divide(T arg1, T arg2);
    }
}
