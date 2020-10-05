using Microsoft.AspNetCore.Authorization;
using MTS.Core.GlobalLibrary;
using System;

namespace MTS.PL.Web.Blazor.Client.Utils.Services.EditPage
{
    [Authorize(Roles =
        Constants.Security.ADMINISTRATOR + "," +
        Constants.Security.PRIVILEGED_EMPLOYEE + "," +
        Constants.Security.EMPLOYEE)]
    public sealed class EditPageService : IEditPageService
    {
        public event Action OnToggle;
        private bool IsInEditMode;

        public void ToggleEditMode()
        {
            if (OnToggle == null)
                return;

            IsInEditMode = !IsInEditMode;
            OnToggle.Invoke();
        }

        public bool GetEditMode() => IsInEditMode;
    }
}
