using MTS.PL.Infra.InjectionLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTS.PL.Infra.BlazorLibrary
{
    public class UserToken : IUserToken
    {
        public DateTime Expiration { get; set; }
        public string LoginProvider { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public string Value { get; set; }
    }
}
