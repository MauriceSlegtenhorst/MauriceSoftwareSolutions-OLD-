using System;
using System.Threading.Tasks;

namespace MTS.PL.Web.Blazor.Client.Utils.Services.Spinner
{
    public interface ISpinnerService
    {
        event Func<string, Task> OnShow;
        event Func<Task> OnHide;

        Task HideSpinner();
        Task ShowSpinner(string message = "Loading...");
    }
}