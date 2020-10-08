using Microsoft.AspNetCore.Authorization;
using MTS.Core.GlobalLibrary;
using System;
using System.Threading.Tasks;

namespace MTS.PL.Web.Blazor.Client.Utils.Services.EditPage
{
    [Authorize(Roles =
        Constants.Security.ADMINISTRATOR + "," +
        Constants.Security.PRIVILEGED_EMPLOYEE + "," +
        Constants.Security.EMPLOYEE)]
    public sealed class EditPageService : IEditPageService
    {
        public event Func<Task> OnToggle;
        private bool IsInEditMode;

        public async Task ToggleEditMode()
        {
            if (OnToggle == null)
                return;

            IsInEditMode = !IsInEditMode;
            await OnToggle.Invoke();
        }

        public bool GetEditMode() => IsInEditMode;
    }
}
