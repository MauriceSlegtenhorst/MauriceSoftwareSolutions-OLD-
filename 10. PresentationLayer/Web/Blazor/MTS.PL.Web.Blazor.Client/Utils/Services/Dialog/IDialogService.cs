using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTS.PL.Web.Blazor.Client.Utils.Services.Dialog
{
    public interface IDialogService
    {
        event Action<DialogModel> OnShow;
        event Action OnHide;

        void ShowDialog(DialogModel dialogModel);

        void HideDialog();
    }
}
