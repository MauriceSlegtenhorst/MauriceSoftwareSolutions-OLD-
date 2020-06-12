using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Data
{
    public static class Constants
    {
#if DEBUG
        public const string BASE_ADDRESS = "https://localhost:5001/";
#else
        public const string BASE_ADDRESS = "https://84.105.128.107/";
#endif
    }
}
