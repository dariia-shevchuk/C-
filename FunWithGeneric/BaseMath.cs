using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithGeneric
{
    public class BaseMath : IMath<int>
    {
        public int Add(int arg1, int arg2)
            => arg1 + arg2;

        public int Divide(int arg1, int arg2)
            => arg1 / arg2;

        public int Multiply(int arg1, int arg2)
            => arg1 * arg2;

        public int Subtract(int arg1, int arg2)
            => arg1 - arg2;
    }
}
