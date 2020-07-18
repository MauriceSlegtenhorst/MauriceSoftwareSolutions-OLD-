using Microsoft.AspNetCore.Components;
using System;

namespace MTS.PL.Web.Blazor.Client.RazorComponents.Alerts.Abstract
{
    // Only here because of the limitiations of .razor inheritens. .razor files can only inherit from one interface or class
    public abstract class AToastServiceComponent : ComponentBase, IDisposable
    {
        public abstract void Dispose();
    }
}
