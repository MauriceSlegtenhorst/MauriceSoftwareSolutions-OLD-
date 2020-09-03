using System;

namespace MTS.PL.Web.Blazor.Client.Utils.Services
{
    public interface IEditPageService
    {
        event Action OnToggle;

        void ToggleEditMode();

        bool GetEditMode();
    }
}