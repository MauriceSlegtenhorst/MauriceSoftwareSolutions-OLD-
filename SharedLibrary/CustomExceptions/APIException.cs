using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.CustomExceptions
{
    public sealed class APIException: Exception
    {
        public APIException() : base("Something went wrong on the server.") { }

        public APIException(string message) : base(message) { }

        public APIException(string message, Exception innerException) : base(message, innerException) { }
    }
}
