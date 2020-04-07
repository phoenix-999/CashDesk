using LanguageLib;
using LanguageLib.Locales;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashDesc
{
    class Config
    {
        public static ILanguage Language { get; private set; }

        internal static void SetLanguage()
        {
            var locale = ConfigurationManager.AppSettings["language"].ToLowerInvariant();
            Language = LanguagesManager.GetLanguage(locale);
        }
    }
}
