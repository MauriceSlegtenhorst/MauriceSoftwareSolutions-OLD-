using System.Collections.Generic;

namespace MTS.DAL.Infra.APILibrary
{
    public sealed class AuthentificationResult
    {
        public bool IsSucceeded { get; set; }

        public IEnumerable<string> Errors { get; set; }

        public UserToken UserToken { get; set; }
    }
}
