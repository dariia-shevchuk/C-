using System;

namespace DelegeateSecond
{
    public class EmailNotification
    {
        public void SendEmailToOwner(string msg)
        {
            Console.WriteLine("Wysyłam email-a do włściciela o treści: {0}", msg);
        }

        public void SendEmailToEmergency(string msg)
        {
            Console.WriteLine("Wysyłam email-a do szpitala o treści: {0}", msg);
        }
    }
}
