using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTS.PL.Web.Blazor.Client.Utils.Services.Dialog
{
    public class DialogService : IDialogService
    {
        public event Action<DialogResult> OnClose;
        internal event Action CloseDialog;
        internal event Action<string, RenderFragment, DialogParameters, DialogOptions> OnShow;

        private Type dialogType;

        public void Cancel()
        {
            CloseDialog?.Invoke();
            OnClose?.Invoke(DialogResult.Cancel(dialogType));
        }

        public void Close(DialogResult dialogResult)
        {
            dialogResult.DialogType = dialogType;
            CloseDialog?.Invoke();
            OnClose?.Invoke(dialogResult);
        }

        public void Show<T>(string title, DialogParameters parameters) where T : ComponentBase
        {
            Show<T>(title, parameters, new DialogOptions());
        }

        public void Show<T>(string title, DialogParameters parameters = null, DialogOptions options = null) where T : ComponentBase
        {
            Show(title, typeof(T), parameters, options);
        }

        /// <exception cref="ArgumentException">Thrown if parameter "Type contentComponent" is not a Blazor component</exception>
        public void Show(string title, Type contentComponent, DialogParameters parameters, DialogOptions options)
        {
            if (typeof(ComponentBase).IsAssignableFrom(contentComponent) == false)
                throw new ArgumentException($"Parameter {nameof(contentComponent)} is not a Blazor component. Please provide a legitimate Blazor(.razor) component");

            var dialogContent = new RenderFragment(renderTreeBuilder => 
            {
                renderTreeBuilder.OpenComponent(1, contentComponent); 
                renderTreeBuilder.CloseComponent(); 
            });

            dialogType = contentComponent;

            OnShow?.Invoke(title, dialogContent, parameters, options);
        }
    }
}
