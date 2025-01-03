using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomBeatPvz.Core.Exceptions
{
    public class AuthenticationException : Exception
    {
        public AuthenticationException(string msg = "") : base(msg) { }
    }
}
