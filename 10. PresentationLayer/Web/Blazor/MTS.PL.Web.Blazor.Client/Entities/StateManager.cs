using MTS.PL.Web.Blazor.Client.Utils;
using System.Collections.Generic;

namespace MTS.PL.Web.Blazor.Client.Entities
{
    public class StateManager : IStateManager
    {
        public IDictionary<string, object> StateData { get; set; }
        public string Page { get; set; }

        public StateManager()
        {
            StateData = new Dictionary<string, object>();
        }
    }
}
