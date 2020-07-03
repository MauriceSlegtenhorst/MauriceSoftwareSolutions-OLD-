using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MTS.DAL.API.Utils.ExceptionHandler;
using MTS.DAL.Infra.APILibrary;
using MTS.DAL.Infra.Interfaces;
using static MTS.Core.GlobalLibrary.Constants;

namespace MTS.DAL.API.Controllers
{
    [Route(APIControllers.IDENTITY)]
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
        [Route(IdentityControllerEndpoints.LOG_IN)]
        [HttpPut]
        public async Task<IActionResult> LogInAsync([FromBody] CredentialHolder credentials)
        {
            if (!ModelState.IsValid)
                return _exceptionHandler.HandleException(new Exception("ModelState was invalid"), isServerSideException: false);

            var result = await _identityAdapter.LogIn(credentials);

            if (result.IsSucceeded)
            {
                return Ok(result.UserToken);
            }
            else
            {
                StringBuilder stringBuilder = new StringBuilder();

                foreach (var error in result.Errors)
                {
                    stringBuilder.AppendLine(error);
                }

                return _exceptionHandler.HandleException(new Exception(stringBuilder.ToString()), isServerSideException: true);
            }
        }

        [Route(IdentityControllerEndpoints.LOG_OUT)]
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