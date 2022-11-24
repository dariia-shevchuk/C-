using LanguageDemo.Interfaces;
using System;

namespace LanguageDemo.View
{

    public class ConsoleResponsProvider : IResponsProvider
    {


        public int GetIntFromUser()
        {
            while (true)
            {
                Console.Write(":> ");
                var res = Console.ReadLine();
                if (int.TryParse(res, out var result))
                    return result;
                Console.Clear();
            }
        }
        public string GetStringFromUser()
        {
            while(true)
            {
                Console.Write(":> ");
                var response = Console.ReadLine();
                if (response.Length > 0)
                    return response;
                Console.Clear();
            }
        }


    }
}
