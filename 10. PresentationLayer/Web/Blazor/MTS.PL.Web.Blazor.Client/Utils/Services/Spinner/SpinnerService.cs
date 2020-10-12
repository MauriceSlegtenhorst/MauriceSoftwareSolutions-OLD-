using System;
using System.Threading.Tasks;

namespace MTS.PL.Web.Blazor.Client.Utils.Services.Spinner
{
    public sealed class SpinnerService : ISpinnerService
    {
        public event Func<string, Task> OnShow;
        public event Func<Task> OnHide;
        public event Func<string, Task> OnSetSpinnerLabel;

        public async Task ShowSpinnerAsync(string message = "Loading...")
        {
            await OnShow?.Invoke(message);
        }

        public async Task HideSpinnerAsync()
        {
            await OnHide?.Invoke();
        }

        public async Task SetSpinnerLabelAsync(string message)
        {
            await OnSetSpinnerLabel?.Invoke(message);
        }
    }
}
