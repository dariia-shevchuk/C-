using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWebApi.Exceptions
{
    public abstract class ApiExceptionBase : Exception
    {
        protected ApiExceptionBase() : base()
        {
        }

        protected ApiExceptionBase(string message) : base(message)
        {
        }

        public abstract string Code { get; }
    }
}
