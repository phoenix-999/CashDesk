using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLib.Locales
{
    public static class LanguagesManager
    {

        static LanguagesManager()
        {
            _languages = new Dictionary<string, Type>();
            Init();
        }

        private static Dictionary<string, Type> _languages;

        #region Class Interface
        public static void Register<T>(string languageName) where T: ILanguage
        {
            if (languageName == null)
                throw new ArgumentNullException();


            _languages.Add(languageName.ToLowerInvariant(), typeof(T));
        }

        public static void Register(string languageName, Type type)
        {
            if (languageName == null)
                throw new ArgumentNullException();

            if (type == null)
                throw new ArgumentNullException();

            _languages.Add(languageName.ToLowerInvariant(), type);
        }

        public static ILanguage GetLanguage(string languageName)
        {
            if (languageName == null)
                throw new ArgumentNullException();
            ILanguage instance = (ILanguage)Activator.CreateInstance(_languages[languageName]);
            instance.Initialize();
            return instance;
        }
        #endregion Class Interface


        private static void Init()
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            var types = assembly.GetTypes();
            foreach(var type in types)
            {
                foreach(var inter in type.GetInterfaces())
                {
                    if(inter.FullName == "LanguageLib.ILanguage")
                    {
                        ILanguage locale = (ILanguage)Activator.CreateInstance(type);
                        Register(locale.LanguageName, type);
                    }
                }
            }
        }
        
        
    }
}
