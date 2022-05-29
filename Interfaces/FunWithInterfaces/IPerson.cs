using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithInterfaces
{
    public interface IPerson
    {
        public string Name { get; }

        string GetData();
    }
}