namespace MTS.Core.GlobalLibrary
{
    public static class Constants
    {
        public static class APIControllers
        {
            public const string ACCOUNT = "account";
            public const string IDENTITY = "identity";
            public const string CREDITS = "credits";
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

        public static class MediaTypes
        {
            public const string JSON = "application/json";
            public const string FORM_URL_ENCODED = "application/x-www-form-urlencoded";
            public const string MULTIPART_FORM_DATA = "multipart/form-data";
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

                    default:
                        return UNAUTHORIZED_USER;
                }
            }
        }

#if DEBUG
        public const string API_BASE_ADDRESS = "https://localhost:5001";
        public const string BLAZOR_WEB_BASE_ADDRESS = "https://localhost:44347";
#else
        public const string API_BASE_ADDRESS = "https://84.105.128.107";
        public const string BLAZOR_WEB_BASE_ADDRESS = "N/A";
#endif

        public enum AccessLevel
        {
            StandardUser,
            PrivilegedUser,
            Volenteer,
            Employee,
            PrivilegedEmployee,
            Administrator
        }
    }
}
