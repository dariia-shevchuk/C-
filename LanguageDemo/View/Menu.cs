using LanguageDemo.Interfaces;
using System;

namespace LanguageDemo.View
{
    public class Menu : IMenu
    {
        private readonly ILanguageManager _languageManager;

        public Menu(ILanguageManager languageManager)
        {
            _languageManager = languageManager;
        }

        public void ShowChangeLanguageMenu()
        {
            Console.Clear();
            Console.WriteLine($"--- {_languageManager.GetString("ChangeLanguageTitle")} ---");
            Console.WriteLine($"0 - {_languageManager.GetString("Polish")}");
            Console.WriteLine($"1 - {_languageManager.GetString("English")}");
        }

        public void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine($"--- {_languageManager.GetString("MainMenuTitle")} ---");
            Console.WriteLine($"1 - {_languageManager.GetString("ChangeLanguage")}");
            Console.WriteLine($"2 - {_languageManager.GetString("Registry")}");
            Console.WriteLine($"3 - {_languageManager.GetString("Option3")}");
            Console.WriteLine($"4 - {_languageManager.GetString("Option4")}");
        }
    }
}
