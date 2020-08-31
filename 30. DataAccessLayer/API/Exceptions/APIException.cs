using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTS.DAL.API.Exceptions
{
    public sealed class APIException : Exception
    {
        public APIException() : base("Something went wrong on the server.") { }

        public APIException(string message) : base(message) { }

        public APIException(string message, Exception innerException) : base(message, innerException) { }
    }
}
