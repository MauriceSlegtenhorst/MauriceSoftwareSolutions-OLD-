using Microsoft.AspNetCore.Identity;
using System;

namespace MTS.DAL.Infra.APILibrary
{
    public class UserToken : IdentityUserToken<string>
    {
        public DateTime Expiration { get; set; }

        public UserToken(
            string userId, 
            string loginProvider, 
            string userName,
            DateTime expiration,
            string jwtSecurityToken)
        {
            UserId = userId;
            LoginProvider = loginProvider;
            Name = userName;
            Expiration = expiration;
            Value = jwtSecurityToken;
        }
    }
}
