using MTS.BL.Infra.Interfaces.Standard;
using System.Collections.Generic;

namespace MTS.DAL.Entities.Core
{
    public sealed class DALAuthentificationResult : IAuthentificationResult
    {
        public bool IsSucceeded { get; set; }

        public IEnumerable<string> Errors { get; set; }

        public IBLUserToken UserToken { get; set; }
    }
}
