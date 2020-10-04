using Microsoft.AspNetCore.Mvc;
using MTS.BL.Infra.Interfaces.Standard.Credit;
using MTS.BL.Infra.Interfaces.Standard.DatabaseAdapter;
using MTS.Core.GlobalLibrary;
using MTS.DAL.API.Utils.ExceptionHandler;
using MTS.DAL.Entities.Core.Credit;
using MTS.PL.Infra.Entities.Standard.Credit;
using MTS.PL.Infra.Interfaces.Standard.Credit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MTS.BL.API.Controllers
{
    [ApiController]
    [Route(Constants.APIControllers.CREDITS)]
    public sealed class CreditController : ControllerBase
    {
        private readonly IExceptionHandler _exceptionHandler;
        private readonly ICreditAdapter _creditAdapter;
        public CreditController(
            IExceptionHandler exceptionHandler, 
            ICreditAdapter creditAdapter)
        {
            _exceptionHandler = exceptionHandler;
            _creditAdapter = creditAdapter;
        }

        #region Create
        [Route(Constants.CreditControllerEndPoints.CREATE_BY_EXISTING_CATEGORY)]
        [HttpPut]
        public async Task<IActionResult> CreateByExistingCategory(IPLCredit credit, string categoryTitle)
        {
            if(ModelState.IsValid == false)
                return _exceptionHandler.HandleException(new Exception("ModelState was invalid"), isServerSideException: false);

            IBLCredit blCredit = new DALCredit
            {
                Title = credit.Title,
                SubTitle = credit.SubTitle,
                Description = credit.Description,
                GotFrom = credit.GotFrom,
                MadeBy = credit.MadeBy,
                LinkToImage = credit.LinkToImage
            };

            try
            {
                await _creditAdapter.CreateByExistingCategory(blCredit, categoryTitle);
            }
            catch (ArgumentException ex)
            {
                return _exceptionHandler.HandleException(ex, isServerSideException: false);
            }
            catch (Exception ex)
            {
                return _exceptionHandler.HandleException(ex, isServerSideException: true);
            }

            return new CreatedAtActionResult(
                            actionName: Constants.CreditControllerEndPoints.CREATE_BY_EXISTING_CATEGORY,
                            controllerName: Constants.APIControllers.CREDITS,
                            routeValues: RouteData.Values,
                            value: credit.Title);
        }
        #endregion

        #region Read
        [Route(Constants.CreditControllerEndPoints.READ_ALL_CREDIT_CATEGORY)]
        [HttpGet]
        public async Task<IActionResult> ReadAllCreditCategoryAsync()
        {
            ICollection<IBLCreditCategory> blCategories = await _creditAdapter.ReadAllAsync();

            ICollection<PLCreditCategory> plCreditCategories = new List<PLCreditCategory>();

            foreach (IBLCreditCategory blCategory in blCategories)
            {
                ICollection<PLCredit> plCredits = new List<PLCredit>();

                foreach (IBLCredit blCredit in blCategory.Credits)
                {
                    plCredits.Add
                        (
                            new PLCredit
                            {
                                Title = blCredit.Title,
                                SubTitle = blCredit.SubTitle,
                                Description = blCredit.Description,
                                GotFrom = blCredit.GotFrom,
                                MadeBy = blCredit.MadeBy,
                                LinkToImage = blCredit.LinkToImage,
                            }
                        );
                }

                plCreditCategories.Add
                    (
                        new PLCreditCategory
                        {
                            Title = blCategory.Title,
                            SubTitle = blCategory.SubTitle,
                            Description = blCategory.Description,
                            PLCredits = plCredits
                        }
                    );
            }

            return Ok(plCreditCategories);
        }
        #endregion

        #region Update

        #endregion

        #region Delete

        #endregion
    }
}
