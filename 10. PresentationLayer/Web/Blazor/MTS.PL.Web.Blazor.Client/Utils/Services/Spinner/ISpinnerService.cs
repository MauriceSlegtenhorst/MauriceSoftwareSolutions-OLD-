using System;
using System.Threading.Tasks;

namespace MTS.PL.Web.Blazor.Client.Utils.Services.Spinner
{
    public interface ISpinnerService
    {
        event Func<string, Task> OnShow;
        event Func<Task> OnHide;
        event Func<string, Task> OnSetSpinnerLabel;

        Task HideSpinnerAsync();
        Task ShowSpinnerAsync(string message = "Loading...");
        Task SetSpinnerLabelAsync(string message);
    }
}