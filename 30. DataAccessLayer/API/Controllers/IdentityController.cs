using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MTS.PL.Entities.Standard;
using MTS.PL.API.Utils.ExceptionHandler;
using MTS.Core.GlobalLibrary;
using MTS.PL.Infra.Interfaces.Standard.DatabaseAdapter;

namespace MTS.PL.API.Controllers
{
    [Route(Constants.APIControllers.IDENTITY)]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityAdapter _identityAdapter;
        private readonly IExceptionHandler _exceptionHandler;

        public IdentityController(
            IIdentityAdapter identityAdapter,
            IExceptionHandler exceptionHandler)
        {
            _identityAdapter = identityAdapter;
            _exceptionHandler = exceptionHandler;
        }

        [AllowAnonymous]
        [Route(Constants.IdentityControllerEndpoints.LOG_IN)]
        [HttpPut]
        public async Task<IActionResult> LogInAsync([FromBody] CredentialHolder credentials)
        {
            if (!ModelState.IsValid)
                return _exceptionHandler.HandleException(new Exception("ModelState was invalid"), isServerSideException: false);

            var result = await _identityAdapter.LogIn(credentials);

            if(result.IsSucceeded == false)
            {
                StringBuilder stringBuilder = new StringBuilder();

                foreach (var error in result.Errors)
                {
                    stringBuilder.AppendLine(error);
                }

                return _exceptionHandler.HandleException(new Exception(stringBuilder.ToString()), isServerSideException: true);
            }

            return Ok(result.UserToken);
        }

        [Route(Constants.IdentityControllerEndpoints.LOG_OUT)]
        [HttpHead]
        public async Task<IActionResult> LogOutAsync()
        {
            var result = await _identityAdapter.LogOut();

            if (result)
            {
                return Ok();
            }
            else
            {
                return _exceptionHandler.HandleException(new Exception("Something went wrong while logging out. The account might not be logged out."), isServerSideException: true);
            }

        }
    }
}