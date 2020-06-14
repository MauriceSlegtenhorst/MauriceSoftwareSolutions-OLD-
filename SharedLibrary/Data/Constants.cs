using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Data
{
    public static class Constants
    {
        public static class APIControllers
        {
            public const string ACCOUNT = "account";
            public const string IDENTITY = "identity";
        }

        public static class AccountControllerMethods
        {
            public const string GET_BY_ID = "getbyid";
            public const string GET_BY_EMAIL = "getbyemail";
            public const string CREATE_BY_ACCOUNT = "createbyaccount";
            public const string DELETE_BY_ID = "deletebyid";
            public const string CONFIRM_EMAIL = "confirmemail";
        }

#if DEBUG
        public const string API_BASE_ADDRESS = "https://localhost:5001";
        public const string WEBSERVER_BASE_ADDRESS = "https://localhost:44347";
#else
        public const string API_BASE_ADDRESS = "https://84.105.128.107";
        public const string WEBSERVER_BASE_ADDRESS = "N/A";
#endif
    }
}
