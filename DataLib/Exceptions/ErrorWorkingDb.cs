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
            _lowerLevelException = ex.GetLowerLevelException(ex);
            _innerMessage = _lowerLevelException.Message;
            if(ex.GetType() != _lowerLevelException.GetType())
            {
                Config.Logger.Error("\tLower level exception:\n\t" + _lowerLevelException.ToString());
            }
        }

        Exception _lowerLevelException;
        string _innerMessage = "";

        public string AdminMessage => _innerMessage; //Для отображения в админке

        public override string Message
        {
            get
            {
                return Config.Language[StrResourceKeys.DbException];
            }
        }
    }
}
