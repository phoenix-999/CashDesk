using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageLib
{
    public interface ILanguage
    {
        string LanguageName { get; }
        string this[StrResourceKeys key] { get; }
        void Initialize();
    }
}
