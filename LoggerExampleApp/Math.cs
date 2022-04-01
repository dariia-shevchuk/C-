using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//data-godzina-plik-metoda-linijka-message

namespace LoggerExampleApp
{
    public class Math
    {
        public int Add(int a, int b)
        {
            _logger.LogTrace($"Parametry: a={a}, b={b}");
            return a + b;

        }

        public int Divide(int a, int b)
        {
            try
            {
                return a / b;
            }
            catch (Exception)
            {
                _logger.LogError($"Parametry: a={a}, b={b}");
                throw;
            }
        }
    }
}
