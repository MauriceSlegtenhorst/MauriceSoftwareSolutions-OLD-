using System;
using System.Threading.Tasks;

namespace MTS.PL.Web.Blazor.Client.Utils.Services.EditPage
{
    public interface IEditPageService
    {
        event Func<Task> OnToggle;

        Task ToggleEditMode();

        bool GetEditMode();
    }
}