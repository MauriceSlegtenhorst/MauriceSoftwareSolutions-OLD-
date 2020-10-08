using System;
using System.Threading.Tasks;

namespace MTS.PL.Web.Blazor.Client.Utils.Services.Spinner
{
    public sealed class SpinnerService : ISpinnerService
    {
        public event Func<string, Task> OnShow;
        public event Func<Task> OnHide;

        public async Task ShowSpinner(string message = "Loading...")
        {
            await OnShow?.Invoke(message);
        }

        public async Task HideSpinner()
        {
            await OnHide?.Invoke();
        }
    }
}
