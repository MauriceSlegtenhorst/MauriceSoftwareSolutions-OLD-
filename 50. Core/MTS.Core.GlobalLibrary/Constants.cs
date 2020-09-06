using System;

namespace MTS.Core.GlobalLibrary
{
    public class Constants
    {
        public class Colors
        {
            public const string HEX_BLUE_LIGHT = "#5baab3";
            public const string RGB_BLUE_LIGHT = "(91,170,179)";

            public const string HEX_BLUE = "#0366d6";
            public const string RGB_BLUE = "(3,102,214)";

            public const string HEX_BLACK = "#000000";
            public const string RGB_BLACK = "(0,0,0)";

            public const string HEX_SMOKE_WHITE = "#eeeeee";
            public const string RGB_SMOKE_WHITE = "(238,238,238)";
            
            public const string HEX_GRAY = "#393e46";
            public const string RGB_GRAY = "(57,62,70)";
        }

        // Insiration for desighn https://xd.adobe.com/ideas/principles/web-design/11-website-layouts-that-made-content-shine-in-2019/
        public sealed class MSS
        {
            //TODO Dit aanpasbaar maken voor admins op de pagina zelf. Content zou sws aanpasbaar moeten zijn en niet hardcoded! Voor nu even zo.
            public const string WHAT_IS_MSS =
                "Maurice Software Solutions was created to showcase my programming skills and to have some fun. Aside from that there is handy and fun functionality to be found like a fully-fledged, " +
                "unlimited personal cloud storage system and a chatroom. And those are just the things I am currently working on. " +
                "I am dedicated to improving Maurice Software Solutions as a whole regularly whilst adding cool new features.";

            public const string ABOUT_MAURICE_1 =
                "I am an enthusiastic man with a strong passion for programming. Social and friendly going. Coding has been my hobby from an early age. When I was 13, " +
                "I made my first program in Visual Basic. A slot machine where there were secret options to get infinite money for example. Later, around the age of 18, " +
                "I started working with Java, XML and Android Studio. With this I built a number of Android apps including an applocker. " +
                "This app allowed the user to choose which apps and services needed an additional password or fingerprint to be used.";

            public const string ABOUT_MAURICE_2 =
                "Friends and especially family regularly ask me for help with electronics and software related matters. " +
                "I think this is because I have been busy with software and hardware practically my whole life.";

            public const string ABOUT_MAURICE_3 =
                "Marketing and commerce seemed to be my career choice for a long time. During my higher professional education, Commercial Economics, I found out that this did not meet my expectations.";

            public const string ABOUT_MAURICE_4 =
                "At one point I ended up at ITvitae and started working on my C# programming skills. This went well for me because Java is similar in syntax to C#. " +
                "Here I have made several complicated programs with C# and related languages such as SQL, HTML XAML, JavaScript and CSS. At ITvitae I have greatly improved my software development skills. " +
                "After about a year I have successfully completed the process.";

            public const string ABOUT_MAURICE_5 =
                "My interests lie in the latest techniques in software development and electronics. In particular what advantages and disadvantages there are. " +
                "For example, I can get enthusiastic about developments such as Blazor. This offers such cool options within the internet landscape. " +
                "For example, the website can be installed as a local application and C# can be used instead of JavaScript! If I find something interesting, " +
                "I want to find out and test it. See what has gotten better or worse.";

            public const string ABOUT_MAURICE_6 =
                "Besides my passion for programming, I am also interested in hardware. For example, I have built my own PC and home server. That very server you are accessing right now.";

            public const string ABOUT_MAURICE_7 =
                "That’s it. If you want to know more about me or Maurice Software Solutions, please navigate to the feedback or contact page to ask your question";

            public const string MAURICE_SKILLS = "C#, JavaScript, SQL, HTML5, CSS3, XAML and XML";

            public const string ABOUT_MAURICE_SHORT = "Born on 27th of april 1991 and living in The Netherlands sinds then. Loves coding and fiddling with electronics. Likes to go for a jog or socialize";
        }

        public sealed class APIControllers
        {
            public const string ACCOUNT = "account";
            public const string IDENTITY = "identity";
            public const string CREDITS = "credits";
            public const string EDIT_PAGE = "editpage";
        }

        public sealed class EditPageControllerEndpoints
        {
            public const string GET_BY_PAGE_ROUTE = "getbypageroute";
            public const string UPDATE_BY_PAGE_SECTIONS = "UpdateByPageSections";
        }

        public sealed class CreditControllerEndPoints
        {
            public const string READ_ALL_CREDIT_CATEGORY = "readallcreditcategory";
        }

        public sealed class AccountControllerEndpoints
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
        
        public class IdentityControllerEndpoints
        {
            public const string LOG_IN = "login";
            public const string LOG_OUT = "logout";
        }

        public class MediaTypes
        {
            public const string JSON = "application/json";
            public const string FORM_URL_ENCODED = "application/x-www-form-urlencoded";
            public const string MULTIPART_FORM_DATA = "multipart/form-data";
        }

        public class Security
        {
            public const string STANDARD_USER = "standarduser";
            public const string PRIVILEGED_USER = "privilegeduser";
            public const string VOLENTEER = "volenteer";
            public const string EMPLOYEE = "employee";
            public const string PRIVILEGED_EMPLOYEE = "privilegedemployee";
            public const string ADMINISTRATOR = "administrator";
        }

#if DEBUG
        public const string API_BASE_ADDRESS = "https://localhost:5001";
        public const string BLAZOR_WEB_BASE_ADDRESS = "https://localhost:44326";
#else
        public const string API_BASE_ADDRESS = "https://84.105.128.107";
        public const string BLAZOR_WEB_BASE_ADDRESS = "N/A";
#endif

        [Flags]
        public enum Roles : byte
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
        public const byte NAME_MAX_LENGTH = 20;
        public const byte NAME_MIN_LENGTH = 1;

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

        public class Verification
        {
            public class Email
            {
                public const string STEP1 = "Step one: You click the confirmation link we send to your email";
                public const string STEP2 = "Step two: Request activation by a server administrator";
                public const string STEP3 = "Step three: A server administrator accepts your account as valid";
                public const string STEP4 = "Step four: Enjoy your account!";
                public static string[] EMAIL_VERIFICATION_STEPS = new string[] { STEP1, STEP2, STEP3, STEP4 };
            }
        }
    }
}
