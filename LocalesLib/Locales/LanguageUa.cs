using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLib.Locales
{
    [Serializable]
    class LanguageUa : ILanguage
    {
        private Dictionary<StrResourceKeys, string> _resources;

        public LanguageUa()
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

        public string LanguageName { get => "ua"; }

        public void Initialize()
        {
            _resources[StrResourceKeys.DbException] = "Помилка в роботі з базою даних. Зверніться до адміністратора.";
        }
    }
}
