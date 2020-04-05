using LanguageLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLib.Exceptions
{
    public class ErrorWorkingDb : Exception
    {
        public ErrorWorkingDb(Exception ex)
        {
            _innerMessage = ex.GetLowerLevelException(ex).Message;
        }

        string _innerMessage = "";

        public override string Message
        {
            get
            {
                return Config.Language[StrResourceKeys.DbException];
            }
        }
    }
}
