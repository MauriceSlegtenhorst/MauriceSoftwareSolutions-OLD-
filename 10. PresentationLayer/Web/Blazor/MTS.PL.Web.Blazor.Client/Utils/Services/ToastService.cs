using Syncfusion.Blazor.Notifications;
using System;
using System.Text;

namespace MTS.PL.Web.Blazor.Client.Utils.Services
{
    public sealed class ToastService : IToastService
    {
        public event Action<ToastModel> OnShow;
        public event Action OnHide;

        public void ShowToast(ToastModel toastModel)
        {
            toastModel.ShowCloseButton = true;
            OnShow?.Invoke(toastModel);
        }

        public void HideToast()
        {
            OnHide?.Invoke();
        }

        public void ShowSuccessToast(string message, string title = "Success!")
        {
            ToastModel toastModel;

            toastModel = new ToastModel
            {
                CssClass = "e-toast-success",
                Icon = "e-success toast-icons",
                Title = title,
                Content = message,
                ShowProgressBar = true,
                ShowCloseButton = true
            };

            ShowToast(toastModel);
        }

        public void ShowExceptionToast(Exception exception)
        {
            ToastModel toastModel;

#if DEBUG
            var contentBuilder = new StringBuilder();

            contentBuilder.AppendLine($"{exception.GetType().Name}:");
            contentBuilder.Append(exception.Message);
            contentBuilder.AppendLine();
            contentBuilder.AppendLine("Stack trace:");
            contentBuilder.Append(exception.StackTrace);

            if (exception.InnerException != null)
            {
                contentBuilder.AppendLine($"{exception.InnerException.GetType().Name}:");
                contentBuilder.Append(exception.InnerException.Message);
                contentBuilder.AppendLine("Stack trace:");
                contentBuilder.Append(exception.InnerException.StackTrace);
            }

            toastModel = new ToastModel
            {
                CssClass = "e-toast-danger",
                Icon = "e-error toast-icons",
                Title = "An Exception has occurred",
                Content = contentBuilder.ToString(),
                ShowCloseButton = true,
                TimeOut = 0
            };
#else
    toastModel = new ToastModel
    {
        CssClass = "e-toast-danger",
        Title = "An error has occured ;(",
        Content = "Detail are held secret",
        ShowCloseButton = true,
        TimeOut = 0,
        Width = "40%"
    };
#endif

            ShowToast(toastModel);
        }
    }
}
