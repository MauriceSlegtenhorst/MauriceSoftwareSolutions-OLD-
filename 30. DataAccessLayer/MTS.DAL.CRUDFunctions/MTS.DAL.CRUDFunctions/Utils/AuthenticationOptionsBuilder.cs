using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace MTS.DAL.DatabaseAccess.Utils
{
    public sealed class AuthenticationOptionsBuilder : AuthenticationOptions
    {

        public AuthenticationOptionsBuilder()
        {
            DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }


        //internal static AuthenticationOptions Build()
        //{
        //    return new AuthenticationOptions
        //    {
        //        DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme,
        //        DefaultScheme = JwtBearerDefaults.AuthenticationScheme,
        //        DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme,
        //        Def
        //    };
        //}
    }
}
