using MTS.BL.Infra.Interfaces.Standard;
using System.Collections.Generic;

namespace MTS.BL.Entities.Standard
{
    public sealed class BLAuthentificationResult : IAuthentificationResult
    {
        public bool IsSucceeded { get; set; }

        public IEnumerable<string> Errors { get; set; }

        public IBLUserToken UserToken { get; set; }
    }
}
