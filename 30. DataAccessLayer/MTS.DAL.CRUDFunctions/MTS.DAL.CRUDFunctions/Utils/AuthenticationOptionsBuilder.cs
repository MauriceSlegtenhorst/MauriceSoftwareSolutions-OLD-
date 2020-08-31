using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace MTS.DAL.DatabaseAccess.Utils
{
    internal sealed class AuthenticationOptionsBuilder
    {
        internal string DefaultAuthenticateScheme { get; private set; }
        internal string DefaultChallengeScheme { get; private set; }


        internal AuthenticationOptionsBuilder()
        {
            DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }
    }
}
