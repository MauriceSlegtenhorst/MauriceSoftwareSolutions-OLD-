using Microsoft.AspNetCore.Identity;
using MTS.PL.Infra.InjectionLibrary;
using System;

namespace MTS.DAL.Infra.APILibrary
{
    public class UserToken : IdentityUserToken<string>, IUserToken
    {
        public DateTime Expiration { get; set; }
        public override string UserId { get => base.UserId; set => base.UserId = value; }
        public override string LoginProvider { get => base.LoginProvider; set => base.LoginProvider = value; }
        public override string Name { get => base.Name; set => base.Name = value; }
        public override string Value { get => base.Value; set => base.Value = value; }

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
