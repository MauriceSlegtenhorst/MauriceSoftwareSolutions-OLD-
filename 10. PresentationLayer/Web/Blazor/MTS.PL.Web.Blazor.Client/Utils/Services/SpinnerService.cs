using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTS.PL.Web.Blazor.Client.Utils.Services
{
    public sealed class SpinnerService : ISpinnerService
    {
        public event Action<string> OnShow;
        public event Action OnHide;

        public void ShowSpinner(string message = "Loading...")
        {
            OnShow?.Invoke(message);
        }

        public void HideSpinner()
        {
            OnHide?.Invoke();
        }
    }
}
