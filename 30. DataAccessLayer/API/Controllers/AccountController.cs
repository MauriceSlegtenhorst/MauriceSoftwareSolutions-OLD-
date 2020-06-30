using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using MTS.BL.Infra.APILibrary;
using MTS.Core.GlobalLibrary;
using MTS.Core.GlobalLibrary.Utils;
using MTS.DAL.DatabaseAccess;
using MTS.DAL.Infra.Interfaces;
using Newtonsoft.Json.Linq;

namespace API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route(Constants.APIControllers.ACCOUNT)]
    public class AccountController : ControllerBase
    {
        private readonly IAccountAdapter _accountFunctions;

        public AccountController(IAccountAdapter accountFunctions)
        {
            _accountFunctions = accountFunctions;
        }

        #region Get
        //[Authorize(Roles =
        //    Constants.Security.ADMINISTRATOR + "," +
        //    Constants.Security.PRIVILEGED_EMPLOYEE)]
        [Route(Constants.AccountControllerEndpoints.GET_BY_ID)]
        [HttpGet]
        public async Task<ActionResult<UserAccount>> GetById([FromBody] string id)
        {
            UserAccount userAccount;
            try
            {
                userAccount =  await _accountFunctions.ReadByIdAsync(id);
            }
            catch(Exception ex)
            {
                return HandleException(ex);
            }

            if (userAccount == null)
                return HandleException(new Exception("Something weird happened when reading from the AccountAdapter. The UserAccount was null."));

            return Ok(userAccount);
        }

        //[Authorize(Roles =
        //    Constants.Security.ADMINISTRATOR + "," +
        //    Constants.Security.PRIVILEGED_EMPLOYEE)]
        [Route(Constants.AccountControllerEndpoints.GET_BY_EMAIL)]
        [HttpGet]
        public async Task<ActionResult<UserAccount>> GetByEmail([FromBody] string email)
        {
            UserAccount userAccount;
            try
            {
                userAccount = await _accountFunctions.ReadByEmailAsync(email);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }

            if (userAccount == null)
                return HandleException(new Exception("Something weird happened when reading from the AccountAdapter. The UserAccount was null."));

            return Ok(userAccount);
        }

        //[Authorize(Roles = Constants.Security.ADMINISTRATOR)]
        [Route(Constants.AccountControllerEndpoints.GET_ALL)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserAccount>>> GetAll()
        {
            IEnumerable<UserAccount> userAccounts;

            try
            {
                userAccounts = await _accountFunctions.ReadAllAsync();
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }

            return Ok(userAccounts);
        }
#endregion

        #region Create
        [Route(Constants.AccountControllerEndpoints.CREATE_BY_CREDENTIALS)]
        [HttpPut]
        public async Task<ActionResult> CreateByCredentials([FromBody] CredentialHolder credentialHolder)
        {
            if (!ModelState.IsValid)
                return HandleException(new Exception("ModelState was invalid"));

            try
            {
                UserAccount newUserAccount = await _accountFunctions.CreateByEmailAndPasswordAsync(credentialHolder.Email, credentialHolder.Password);

                if (newUserAccount != null && !String.IsNullOrEmpty(newUserAccount.Id))
                {
                    return new CreatedAtActionResult(
                            actionName: Constants.AccountControllerEndpoints.CREATE_BY_ACCOUNT,
                            controllerName: Constants.APIControllers.ACCOUNT,
                            routeValues: RouteData.Values,
                            value: newUserAccount.Id);
                }
                else
                {
                    throw new Exception("Creating account failed. The user account was null or had no id after an attempt to create it");
                }
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [Authorize(Roles =
            Constants.Security.ADMINISTRATOR + "," +
            Constants.Security.PRIVILEGED_EMPLOYEE + "," +
            Constants.Security.EMPLOYEE)]
        [Route(Constants.AccountControllerEndpoints.CREATE_BY_ACCOUNT)]
        [HttpPut]
        public async Task<ActionResult> CreateByAccount([FromBody] UserAccount userAccount)
        {
            if (!ModelState.IsValid)
                return HandleException(new Exception("ModelState invalid"));

            try
            {
                UserAccount newUserAccount = await _accountFunctions.CreateByAccountAsync(userAccount);

                if (newUserAccount != null && !String.IsNullOrEmpty(newUserAccount.Id))
                {
                    return new CreatedAtActionResult(
                            actionName: Constants.AccountControllerEndpoints.CREATE_BY_ACCOUNT,
                            controllerName: Constants.APIControllers.ACCOUNT,
                            routeValues: RouteData.Values,
                            value: newUserAccount.Id);
                }
                else
                {
                    throw new Exception("Creating account failed. The user account was null or had no id after an attempt to create it");
                }
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
        #endregion

        #region Update
        [Route(Constants.AccountControllerEndpoints.UPDATE_BY_ACCOUNT)]
        [HttpPatch]
        public async Task<ActionResult<bool>> UpdateByAccount([FromBody] UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                return await _accountFunctions.WriteAsync(userAccount);
            }
            else
            {
                return HandleException(new Exception("ModelState invalid"));
            }
        }
        #endregion

        #region Delete
        //[Authorize]
        [Route(Constants.AccountControllerEndpoints.DELETE_BY_ID)]
        [HttpDelete]
        public async Task<ActionResult> DeleteById([FromQuery] string id)
        {
            if (ModelState.IsValid)
            {
                bool result = false;
                try
                {
                    result = await _accountFunctions.DeleteById(id);
                    
                }
                catch (Exception ex)
                {

                    HandleException(ex);
                }

                if (result)
                {
                    return Ok("Account deleted");
                }
                else
                {
                    throw new Exception("Something went wrong during deletion. The account might still exist");
                }
            }
            else
            {
                return HandleException(new Exception("ModelState invalid"));
            }
        }
        #endregion

        // Confirm email
        [Route(Constants.AccountControllerEndpoints.CONFIRM_EMAIL)]
        [HttpPut]
        public async Task<ActionResult> ConfirmEmail([FromBody] ConfirmEmailHolder confirmEmailHolder)
        {
            if (ModelState.IsValid)
            {
                bool result = await _accountFunctions.ConfirmEmailAsync(confirmEmailHolder);

                if (result)
                    return Ok("Succes! Thank you for confirming your email.");
                else
                    return HandleException(new Exception("Something went wrong confirming the email"));
            }
            else
            {
                return BadRequest("ModelState invalid");
            }
        }

        private ActionResult HandleException(Exception ex)
        {
#if DEBUG
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Exception:");
            stringBuilder.AppendLine(ex.GetType().Name);
            stringBuilder.AppendLine($"Source application or object:");
            stringBuilder.AppendLine(ex.Source);
            stringBuilder.AppendLine($"Message:");
            stringBuilder.AppendLine(ex.Message);
            stringBuilder.AppendLine($"Stack trace:");
            stringBuilder.AppendLine(ex.StackTrace);

            if (ex.InnerException != null)
            {
                stringBuilder.AppendLine($"Inner exception:");
                stringBuilder.AppendLine(ex.InnerException.GetType().Name);
                stringBuilder.AppendLine($"Message:");
                stringBuilder.AppendLine(ex.InnerException.Message);
                stringBuilder.AppendLine($"Stack trace:");
                stringBuilder.AppendLine(ex.InnerException.StackTrace);
            }

            return StatusCode(500, stringBuilder.ToString());
#else
            return StatusCode(500, "Something went wrong on the server. Details are held secret");
#endif

        }
    }
}
