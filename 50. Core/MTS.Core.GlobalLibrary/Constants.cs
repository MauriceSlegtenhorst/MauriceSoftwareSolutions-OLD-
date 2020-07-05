using System;

namespace MTS.Core.GlobalLibrary
{
    public static class Constants
    {
        public static class MTS
        {
            public const string WHAT_IS_MTS = "Maurice Tech Solutions was developed to showcase the programming skills of Maurice.";
        }

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
            public const string CREATE_BY_CREDENTIALS = "createbycredentials";
            public const string CREATE_BY_ACCOUNT = "createbyaccount";
            public const string UPDATE_BY_ACCOUNT = "updatebyaccount";
            public const string DELETE_BY_ID = "deletebyid";
            public const string CONFIRM_EMAIL = "confirmemail";
            public const string CONFIRM_EMAIL_ADMIN = "confirmemailadmin";
            public const string ADD_ROLES_TO_ACCOUNT = "addrolestoaccount";
            public const string REMOVE_ROLES_FROM_ACCOUNT = "removerolesfromaccount";
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
        public const string BLAZOR_WEB_BASE_ADDRESS = "https://localhost:44347";
#else
        public const string API_BASE_ADDRESS = "https://84.105.128.107";
        public const string BLAZOR_WEB_BASE_ADDRESS = "N/A";
#endif

        [Flags]
        public enum AccessLevel : byte
        {
            Nonexistent         = 0,
            StandardUser        = 1,
            PrivilegedUser      = 2,
            Volenteer           = 4,
            Employee            = 8,
            PrivilegedEmployee  = 16,
            Administrator       = 32
        }

        public static string[] VALID_EMAIL_DOMAINS = new string[] { "gmail", "yahoo", "hotmail", "outlook", "icloud", "me", "mac",  "aol", "msn", "wanadoo", "comcast", "live", "rediffmail", "outlook", "googlemail", "tiscali", "t-online", "telenet" };

        /// <summary>
        /// At least one upper case English letter,     (?=.*?[A-Z])
        /// At least one lower case English letter,     (?=.*?[a - z])
        /// At least one digit,                         (?=.*?[0 - 9])
        /// At least one special character,             (?=.*?[#?!@$%^&*-])
        /// Minimum eight in length.{8,}                (with the anchors) 
        /// </summary>
        public const string VALID_PASSWORD_PATTERN = "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$";
        public static string[] VALID_PASSWORD_REQUIREMENTS = new[]
        {
            "Contain one upper case letter",
            "Contain one lower case letter",
            "Contain one diget",
            "Contain one special character",
            "Have a length of 8"
        };
        public const string PASSWORD_ERROR_MESSAGE = "This password does not meet the requirements";
    }
}
