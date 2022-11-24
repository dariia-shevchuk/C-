using LanguageDemo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageDemo.Interfaces
{
    public interface ILanguageManager
    {
        void SetCurrentLanguage(Languages language);

        string GetString(string key);
    }
}
