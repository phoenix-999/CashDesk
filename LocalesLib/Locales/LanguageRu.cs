using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLib.Locales
{
    [Serializable]
    class LanguageRu : ILanguage
    {
        private Dictionary<StrResourceKeys, string> _resources;

        public LanguageRu()
        {
            _resources = new Dictionary<StrResourceKeys, string>();
        }
        public string this[StrResourceKeys key]
        {
            get
            {
                return _resources[key];
            }
        }

        public string LanguageName { get => "ru"; }

        public  void Initialize()
        {
            _resources[StrResourceKeys.DbException] = "Ошибка в работе с базой данных. Обратитесь к администратору.";
        }
    }
}
