using Microsoft.AspNetCore.Identity;
using MTS.PL.Infra.Interfaces.Standard;
using System;

namespace MTS.PL.Entities.Core
{
    public class DLUserToken : IdentityUserToken<string>, IBLUserToken
    {
        public DateTime Expiration { get; set; }

        public DLUserToken(
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
