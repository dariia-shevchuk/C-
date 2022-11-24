using LanguageDemo.Enums;
using LanguageDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageDemo
{
    public class App : IApp
    {
        private readonly IMenu _menu;
        private readonly IResponsProvider _userResponsProvider;
        private readonly ILanguageManager _languageManager;

        public App(IMenu menu, IResponsProvider userResponsProvider,
            ILanguageManager languageManager)
        {
            _menu = menu;
            _userResponsProvider = userResponsProvider;
            _languageManager = languageManager;
        }
        public void Start()
        {
            while(true)
            {
                _menu.ShowMainMenu();
                var response = _userResponsProvider.GetIntFromUser();

                switch (response)
                {
                    case 1:
                        ChangeLanguage();
                        break;
                    case 2:
                        break;
                    default:
                        break;
                }

            }
        }

        private void ChangeLanguage()
        {
            _menu.ShowChangeLanguageMenu();
            var language = _userResponsProvider.GetIntFromUser();
            _languageManager.SetCurrentLanguage((Languages)language);
        }
    }
}
