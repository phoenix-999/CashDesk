using LanguageLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLib.Exceptions
{
    public class InputDataException : Exception
    {
        public InputDataException(Exception ex)
        {

        }

        public override string Message
        {
            get
            {
                return Config.Language[StrResourceKeys.InputDataException];
            }
        }
    }
}
