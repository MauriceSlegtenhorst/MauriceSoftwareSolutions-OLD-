using MTS.PL.Infra.Interfaces.Standard;
using MTS.PL.Infra.Interfaces.Standard;
using System.Collections.Generic;

namespace MTS.PL.Entities.Standard
{
    public sealed class AuthentificationResult : IAuthentificationResult
    {
        public bool IsSucceeded { get; set; }

        public IEnumerable<string> Errors { get; set; }

        public IBLUserToken UserToken { get; set; }
    }
}
