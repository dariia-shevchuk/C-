using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithInterfaces
{
    public class Rectangle : IShape
    {
        public void DrawMe()
        {
            Console.WriteLine("Rysuje prostokat");
        }

        public void Do()
        {
        }
    }
}