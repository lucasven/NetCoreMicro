using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreMicro.Common.Exceptions
{
    public class NetCoreMicroException : Exception
    {
        public string Code { get; set; }

        public NetCoreMicroException()
        {

        }

        public NetCoreMicroException(string code)
        {
            Code = code;
        }

        public NetCoreMicroException(string message, params object[] args) : this(string.Empty, message, args)
        {

        }

        public NetCoreMicroException(string code, string message, params object[] args) : this(null, code, message, args)
        {

        }

        public NetCoreMicroException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {

        }

        public NetCoreMicroException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {

        }
    }
}
