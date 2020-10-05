using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTS.PL.Web.Blazor.Client.Utils.Services.Dialog
{
    public class DialogService : IDialogService
    {
        public event Action<DialogModel> OnShow;
        public event Action OnHide;

        public void ShowDialog(DialogModel dialogModel)
        {
            OnShow?.Invoke(dialogModel);
        }

        public void HideDialog()
        {
            OnHide?.Invoke();
        }
    }
}
