using Microsoft.AspNetCore.Mvc;
using MTS.BL.Infra.Interfaces.Standard.DatabaseAdapter;
using MTS.BL.Infra.Interfaces.Standard.EditPageContent;
using MTS.Core.GlobalLibrary;
using MTS.DAL.API.Utils.ExceptionHandler;
using MTS.PL.Infra.Entities.Standard;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MTS.BL.API.Controllers
{
    [ApiController]
    [Route(Constants.APIControllers.EDIT_PAGE)]
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
        [Route(Constants.EditPageControllerEndpoints.GET_BY_PAGE_ROUTE)]
        [HttpPut]
        public async Task<IActionResult> GetByPageRoute([FromBody] string pageRoute)
        {
            if (string.IsNullOrEmpty(pageRoute))
                return _exceptionHandler.HandleException(new NullReferenceException("Parameter pageRoute is required. pageRoute  was null or empty."), isServerSideException: false);

            ICollection<IBLPageSection> blPageSections;

            try
            {
                blPageSections = await _editPageAdapter.ReadByPageRouteAsync(pageRoute);
            }
            catch (Exception ex)
            {
                return _exceptionHandler.HandleException(ex, isServerSideException: true);
            }

            ICollection<PLPageSection> plPageSections = new List<PLPageSection>(blPageSections.Count);

            foreach (IBLPageSection blPageSection in blPageSections)
            {
                ICollection<PLSectionPart> plSectionParts = new List<PLSectionPart>(blPageSection.Parts.Count);

                foreach (IBLSectionPart blSectionPart in blPageSection.Parts)
                {
                    plSectionParts.Add
                        (
                            new PLSectionPart
                            {
                                SectionPartId = blSectionPart.SectionPartId,
                                PageSectionId = blSectionPart.PageSectionFK,
                                Type = blSectionPart.Type,
                                Content = blSectionPart.Content
                            }
                        );
                }

                plPageSections.Add
                    (
                        new PLPageSection
                        {
                            PageSectionId = blPageSection.PageSectionId,
                            PageRoute = blPageSection.PageRoute,
                            PLSectionParts = plSectionParts
                        }
                    );
            }

            return Ok(plPageSections);
        }
        #endregion
    }
}
