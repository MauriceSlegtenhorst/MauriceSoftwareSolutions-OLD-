using Microsoft.AspNetCore.Mvc;
using MTS.BL.Infra.Interfaces.Standard.DatabaseAdapter;
using MTS.DAL.API.Utils.ExceptionHandler;
using MTS.PL.Infra.Interfaces.Standard;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MTS.BL.API.Controllers
{
    public class EditPageController : ControllerBase
    {
        private readonly IEditPageAdapter _editPageAdapter;
        private readonly IExceptionHandler _exceptionHandler;

        public EditPageController(
            IEditPageAdapter editPageAdapter,
            IExceptionHandler exceptionHandler)
        {
            _editPageAdapter = editPageAdapter;
            _exceptionHandler = exceptionHandler;
        }

        #region Read
        public async Task<IActionResult> GetByPageRoute([FromBody] string pageRoute)
        {
            if (string.IsNullOrEmpty(pageRoute))
                return _exceptionHandler.HandleException(new NullReferenceException("Parameter pageRoute is required. pageRoute  was null or empty."), isServerSideException: false);

            List<IPLSectionPart> plPageSections = new List<IPLSectionPart>();

            try
            {
                var blPageSections = await _editPageAdapter.ReadByPageRouteAsync(pageRoute);

                foreach (var item in blPageSections)
                {
                    IPLSectionPart plSectionPart = new 
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
