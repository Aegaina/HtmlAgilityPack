#if METRO
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aegaina.HtmlAgilityPack
{
    public class InvalidProgramException : System.Exception
    {
        public InvalidProgramException(string message)
            : base(message)
        {
        }
    }
}
#endif