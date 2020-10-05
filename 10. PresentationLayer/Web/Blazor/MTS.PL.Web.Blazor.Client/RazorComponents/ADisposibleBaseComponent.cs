using Microsoft.AspNetCore.Components;
using System;

namespace MTS.PL.Web.Blazor.Client.RazorComponents
{
    // Only here because of the limitiations of .razor inheritens. .razor files can only inherit from one interface or class
    public abstract class ADisposibleBaseComponent : ComponentBase, IDisposable
    {
        public abstract void Dispose();
    }
}
