using Syncfusion.Blazor.Notifications;
using System;

namespace MTS.PL.Web.Blazor.Client.Utils.Services
{
    public interface IToastService
    {
        event Action OnHide;
        event Action<ToastModel> OnShow;

        void HideToast();
        void ShowExceptionToast(Exception exception);
        void ShowSuccessToast(string message, string title = "Success!");
        void ShowToast(ToastModel toastModel);
    }
}