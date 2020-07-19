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
        public class MSS
        {
            public const string WHAT_IS_MSS =
                "Maurice Software Solutions is an \"attic project\" developed by Maurice to showcase the programming skills of Maurice. Aside from that there is actual functionality to be found like fully-fledged, unlimited cloud storage and a chatroom." +
                "Maurice is dedicated to improving Maurice Software Solutions as a whole regularly whilst adding new features.";

            public const string ABOUT_MAURICE_1 = 
                "I am an enthusiastic man with a strong passion for programming. People call me social, friendly and helpful. Those are also the things that give me energy besides coding of course.  " +
                "Although I was much more social in my early years, I still like it. Things that interest me are space, innovation in general, new technologies, extreme sports, shooting guns (for sports), computer parts and I like to go for a jog every now and then.";

            public const string ABOUT_MAURICE_2 =
                "Early in my childhood (I think I was thirteen) my older brother gave me a book called \"Coding in Visual Basic\" which sparked my interest in coding. " +
                "I started coding regularly but I didn’t have I clue what I was doing but I liked the feeling of creating things and making them work. Soon I created my very first program, a beautiful slot machine with cheat options for many things like infinite money. " +
                "At this point I didn’t know yet if I wanted to make this my main profession, I just liked it as a hobby.";

            public const string ABOUT_MAURICE_3 =
                "Thinking I like other things such as commerce and owning a store later, I headed this way starting a study called \"Ondernemer Detailhandel\" which translates to Retail entrepreneur and successfully completed it. " +
                "Next I started a new study called \"Commerciele Economie\" which translates into Commerce Economics. This one I didn’t finish. Personal problems prevented me from getting to the finish and I ended up stopping. " +
                "There were many reasons for this but most importantly it did not interest me enough to keep on going. ";

            public const string ABOUT_MAURICE_4 =
                "Whilst trying to fix my personal problems I started really liking programming and started to develop in Android Studio. I developed several android apps for myself and others learning more and more about Java, XML, SQLite and even some Kotling. ";

            public const string ABOUT_MAURICE_5 =
                "Now that some time has passed, I got referred to ITvitae. They could help me get into the software development world and possibly get me a job in this field. " +
                "A new time arrives for me when I pass all the tests and am allowed into ITvitae as a participant of the C# Software Development department. Liking it from the start I spend a lot of time on location to make projects and improve my C# development skills. " +
                "In one year, I have learned so incredibly much working like this and I still am.";

            public const string ABOUT_MAURICE_6 =
                "Now I have a good understanding of languages like C#, SQL, SQLite, HTML, XAML, XML, JavaScript, SCSS and CSS. But I must admit, I like C# and XAML the most out of all of these as they seem the most logically constructed to me. ";

            public const string ABOUT_MAURICE_7 =
                "That’s it. If you want to know more about me or Maurice Software Solutions, please navigate to the feedback or contact page. Have a good one!";
        }

        public class APIControllers
        {
            public const string ACCOUNT = "account";
            public const string IDENTITY = "identity";
            public const string CREDITS = "credits";
        }

        public class AccountControllerEndpoints
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
        public const string BLAZOR_WEB_BASE_ADDRESS = "https://localhost:44347";
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
    }
}
