using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLib.Exceptions
{
    static class ExceptionExtensions
    {
        public static Exception GetLowerLevelException(this Exception ex, Exception upperLevelException)
        {
            var result = upperLevelException;
            while(upperLevelException.InnerException != null)
            {
                result = upperLevelException.InnerException;
            }

            return result;
        }
    }
}
