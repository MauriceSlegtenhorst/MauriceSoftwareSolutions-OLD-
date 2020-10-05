using Syncfusion.Blazor.Notifications;
using System;

namespace MTS.PL.Web.Blazor.Client.Utils.Services.Toast
{
    public interface IToastService
    {
        event Action OnHide;
        event Action<ToastModel> OnShow;

        void HideToast();
        void ShowToast(ToastModel toastModel);
        void ShowExceptionToast(Exception exception);
        void ShowSuccessToast(string message, string title = "Success!");
    }
}