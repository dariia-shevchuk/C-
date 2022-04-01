

//data-godzina-poziom logu-plik-metoda-linijka-message

using AP.SlLoggerr;

namespace LoggerExampleApp
{
    public class MyMath
    {
        Logger _logger;
        public MyMath(Logger logger)
        {
            _logger = logger;
        }
        public int Add(int a, int b)
        {


            _logger.LogTrace($"Parametry: a={a}, b={b}");
            _logger.LogInformation("To jest jakas informacja");
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
                return -1;
                
            }
        }
    }
}
