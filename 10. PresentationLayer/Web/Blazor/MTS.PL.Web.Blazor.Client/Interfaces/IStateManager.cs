using System.Collections.Generic;

namespace MTS.PL.Web.Blazor.Client.Utils
{
    public interface IStateManager
    {
        IDictionary<string, object> StateData { get; set; }
        string Page { get; set; }
    }
}