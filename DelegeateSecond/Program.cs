using System;

namespace DelegeateSecond
{
    //w projekcie drugm od interfejsów na samym końcu pokazałem jak 
    //można wykżystać interfejsy do komunikacji zwrotnej teraz ten sam przykład przerobie zastępując
    //interfejsy, które wysyłaly komunikaty, delgatami
    class Program
    {

        static void Swap(ref int a, ref int b)
        {
        }
        static void Ab(out int a)
        {
            a = 45;
         }



        static void Main(string[] args)
        {
            var warningDelegate = new Stove.WorningDelegate(SendSmsToOwner);
            var explodedDelegate = new Stove.ExploadDelegate(SendSmsToEmergency);

            var stove = new Stove();
            stove.OnExpload(explodedDelegate);
            stove.OnWorning(warningDelegate);
            //w definicj metody OnExpload oraz OnWorning widzieliśmy
            //znak += co oznacza ze mozemy przekazac wiecej delegatów 
            var emailNotification = new EmailNotification();
            stove.OnExpload(emailNotification.SendEmailToEmergency);
            stove.OnWorning(emailNotification.SendEmailToOwner);


            for (int i = 0; i < 7; i++)
            {
                stove.RaiseTemperature();
            }


            //sprzątamy po sobie
            stove.RemoveExpload(explodedDelegate);
            stove.RemoveWorning(warningDelegate);

            stove.RemoveExpload(emailNotification.SendEmailToEmergency);
            stove.RemoveWorning(emailNotification.SendEmailToOwner);

            ////kolejny przykłąd
            //Console.WriteLine("\n***************************************\n");
            ////utwórz garaż 
            //var garage = new Garage();

            ////utwórz serwis
            //var service = new ServiceDepartment();


            //Console.WriteLine("\numyj samochody\n"); 
            //garage.ProcessCar(new Car.CarMaintenceDelegate(service.WashCar));

            //Console.WriteLine("\nwymień opony\n");
            //garage.ProcessCar(new Car.CarMaintenceDelegate(service.RotateTires));
        }

        public static void SendSmsToOwner(string msg)
        {
            Console.WriteLine("Wysyłam sms do włściciela o treści: {0}", msg);
        }

        public static void SendSmsToEmergency(string msg)
        {
            Console.WriteLine("Wysyłam sms do szpitala o treści: {0}", msg);
        }
    }
}
