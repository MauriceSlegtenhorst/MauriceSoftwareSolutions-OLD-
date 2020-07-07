using MTS.PL.Infra.Interfaces.Standard;
using System;

namespace MTS.PL.Entities.Standard
{
    public class BLUserToken : IPLUserToken
    {
        public DateTime Expiration { get; set; }
        public string LoginProvider { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public string Value { get; set; }

        public BLUserToken(
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
