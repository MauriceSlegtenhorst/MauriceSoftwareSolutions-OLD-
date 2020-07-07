using MTS.PL.Infra.Interfaces.Standard;
using System.Collections.Generic;

namespace MTS.PL.Infra.Interfaces.Standard
{
    public interface IAuthentificationResult
    {
        IEnumerable<string> Errors { get; set; }
        bool IsSucceeded { get; set; }
        IBLUserToken UserToken { get; set; }
    }
}