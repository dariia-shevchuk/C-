using LanguageDemo.Enums;

namespace LanguageDemo.Interfaces
{
    public interface ILanguageManager
    {
        void SetCurrentLanguage(Languages language);

        string GetString(string key);
    }
}
