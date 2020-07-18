using System;

namespace MTS.PL.Web.Blazor.Client.Utils.Services
{
    public interface ISpinnerService
    {
        event Action<string> OnShow;
        event Action OnHide;
        
        void HideSpinner();
        void ShowSpinner(string message = "Loading...");
    }
}