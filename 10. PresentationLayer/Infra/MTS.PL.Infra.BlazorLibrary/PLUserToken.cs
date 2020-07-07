using MTS.PL.Infra.Interfaces.Standard;
using System;

namespace MTS.PL.Infra.Entities.Standard
{
    public class PLUserToken : IPLUserToken
    {
        public DateTime Expiration { get; set; }
        public string LoginProvider { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public string Value { get; set; }
    }
}
