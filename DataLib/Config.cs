using LanguageLib;
using LanguageLib.Locales;
using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLib
{
    static class Config
    {
        static Config()
        {
            SetLanguage();
        }

        public static string ConnectionString {
            get
            {
                return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            }
        }

        public static Logger Logger
        {
            get
            {
                return LogManager.GetCurrentClassLogger();
            }
        }
    
        public static ILanguage Language { get; private set; }

        private static void SetLanguage()
        {
            var locale = ConfigurationManager.AppSettings["language"].ToLowerInvariant();
            Language = LanguagesManager.GetLanguage(locale);
        }
    }
}
