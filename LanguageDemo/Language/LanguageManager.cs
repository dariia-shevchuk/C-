using LanguageDemo.Enums;
using LanguageDemo.Interfaces;
using System.Collections.Generic;

namespace LanguageDemo.Language
{
    public class LanguageManager : ILanguageManager
    {
        private static Languages _currentLanguage;
        private Dictionary<string, string> _dictPl = new Dictionary<string, string>
        {
            {"ChangeLanguageTitle", "Zmień język" },
            {"Polish", "Polski" },
            {"English", "Angielski" },
            {"MainMenuTitle", "Menu" },
            {"ChangeLanguage", "Zmień język" },
            {"Registry", "Zarejestruj" },
        };

        private Dictionary<string, string> _dictEn = new Dictionary<string, string>
        {
            {"ChangeLanguageTitle", "Zmień język_En" },
            {"Polish", "Polski_En" },
            {"English", "Angielski_En" },
            {"MainMenuTitle", "Menu_En" },
            {"ChangeLanguage", "Zmień język_En" },
            {"Registry", "Zarejestruj_EN" },
        };

        public string GetString(string key)
        {
            var dict = GetCurentDict();

            if (dict.ContainsKey(key))
                return dict[key];
            return $"[-- {key.ToUpper()} --]";
        }

        private Dictionary<string, string> GetCurentDict()
        {
            if (_currentLanguage == Languages.English)
                return _dictEn;
            return _dictPl;
        }

        public void SetCurrentLanguage(Languages language)
        {
            _currentLanguage = language;
        }
    }
}
