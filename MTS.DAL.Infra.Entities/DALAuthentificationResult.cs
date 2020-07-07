using MTS.PL.Infra.Interfaces.Standard;
using System.Collections.Generic;

namespace MTS.PL.Entities.Core
{
    public sealed class DALAuthentificationResult : IAuthentificationResult
    {
        public bool IsSucceeded { get; set; }

        public IEnumerable<string> Errors { get; set; }

        public IBLUserToken UserToken { get; set; }
    }
}
