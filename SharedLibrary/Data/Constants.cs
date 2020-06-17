using SharedLibrary.Security;
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

        public static class AccountControllerEndpoints
        {
            public const string GET_BY_ID = "getbyid";
            public const string GET_BY_EMAIL = "getbyemail";
            public const string GET_ALL = "getall";
            public const string CREATE_BY_ACCOUNT = "createbyaccount";
            public const string DELETE_BY_ID = "deletebyid";
            public const string CONFIRM_EMAIL = "confirmemail";
        }

        public static class IdentityControllerEndpoints
        {
            public const string LOG_IN = "login";
            public const string LOG_OUT = "logout";
        }

        public static class CookieConfigurations
        {
            public const string DEFAULT_SCHEME = "mts_cookies";
            public const string DEFAULT_CHALLENGE_SHEME = "oidc";
        }

        public static class Security
        {
            public const string UNAUTHORIZED_USER = "UnauthorizedUser";
            public const string STANDARD_USER = "StandardUser";
            public const string PRIVILEGED_USER = "PrivilegedUser";
            public const string VOLENTEER = "Volenteer";
            public const string EMPLOYEE = "Employee";
            public const string PRIVILEGED_EMPLOYEE = "PrivilegedEmployee";
            public const string ADMINISTRATOR = "Administrator";

            public static string GetAccessLevelString(AccessLevel accessLevel)
            {
                switch (accessLevel)
                {
                    default:
                        return UNAUTHORIZED_USER;

                    case AccessLevel.StandardUser:
                        return STANDARD_USER;

                    case AccessLevel.PrivilegedUser:
                        return PRIVILEGED_USER;

                    case AccessLevel.Volenteer:
                        return VOLENTEER;

                    case AccessLevel.Employee:
                        return EMPLOYEE;

                    case AccessLevel.PrivilegedEmployee:
                        return PRIVILEGED_EMPLOYEE;

                    case AccessLevel.Administrator:
                        return ADMINISTRATOR;
                }
            }
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
