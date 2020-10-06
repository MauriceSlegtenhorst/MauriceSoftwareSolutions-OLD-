using Microsoft.AspNetCore.Components;
using System;

namespace MTS.PL.Web.Blazor.Client.Utils.Services.Dialog
{
    public interface IDialogService
    {
        event Action<DialogResult> OnClose;

        void Show<T>(string title, DialogParameters parameters) where T : ComponentBase;

        void Show<T>(string title, DialogParameters parameters = null, DialogOptions options = null) where T : ComponentBase;

        /// <exception cref="ArgumentException">Thrown if parameter "Type contentComponent" is not a Blazor component</exception>
        void Show(string title, Type contentComponent, DialogParameters parameters, DialogOptions options);

        void Close(DialogResult dialogResult);

        void Cancel();
    }
}
