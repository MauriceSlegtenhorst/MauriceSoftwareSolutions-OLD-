using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using static MTS.Core.GlobalLibrary.Constants;

namespace MTS.BL.Infra.APILibrary
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
