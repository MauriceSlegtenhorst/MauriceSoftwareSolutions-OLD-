using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MTS.BL.Infra.APILibrary;
using MTS.Core.GlobalLibrary;
using MTS.Core.GlobalLibrary.Utils;
using MTS.BL.Infra.Interfaces;
using MTS.PL.Infra.InjectionLibrary;
using System.Linq;
using MTS.BL.API.Utils.ExceptionHandler;
using Microsoft.AspNetCore.Identity;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace MTS.BL.API.Controllers
{
    [ApiController]
    [Route(Constants.APIControllers.ACCOUNT)]
    public class AccountController : ControllerBase
    {
        private readonly IAccountAdapter _accountFunctions;
        private readonly IExceptionHandler _exceptionHandler;

        public AccountController(
            IAccountAdapter accountFunctions,
            IExceptionHandler exceptionHandler)
        {
            _accountFunctions = accountFunctions;
            _exceptionHandler = exceptionHandler;
        }

        #region Get
        //[Authorize(Roles =
        //    Constants.Security.ADMINISTRATOR + "," +
        //    Constants.Security.PRIVILEGED_EMPLOYEE)]
        [Route(Constants.AccountControllerEndpoints.GET_BY_ID)]
        [HttpGet]
        public async Task<IActionResult> GetByIdAsync([FromBody] string id)
        {
            if (String.IsNullOrEmpty(id))
                return _exceptionHandler.HandleException(new NullReferenceException("Parameter id is required. Id  was null or empty."), isServerSideException: false);

            IUserAccount userAccount;

            try
            {
                var efUserAccount = await _accountFunctions.ReadByIdAsync(id);

                userAccount = new UserAccount();

                PropertyCopier<IEFUserAccount, IUserAccount>.Copy(efUserAccount, userAccount);

                if (String.IsNullOrEmpty(userAccount.Id) || String.IsNullOrEmpty(userAccount.Email))
                    throw new NullReferenceException("UserAccount has either no Id or email. Probably something went wrong during copying or retreiving data.");
            }
            catch (Exception ex)
            {
                return _exceptionHandler.HandleException(ex, isServerSideException: true);
            }

            return Ok(userAccount);
        }

        //[Authorize(Roles =
        //    Constants.Security.ADMINISTRATOR + "," +
        //    Constants.Security.PRIVILEGED_EMPLOYEE)]
        [Route(Constants.AccountControllerEndpoints.GET_BY_EMAIL)]
        [HttpGet]
        public async Task<IActionResult> GetByEmailAsync([FromBody] string email)
        {
            IUserAccount userAccount;

            try
            {
                var efUserAccount = await _accountFunctions.ReadByEmailAsync(email);

                userAccount = new UserAccount();

                PropertyCopier<IEFUserAccount, IUserAccount>.Copy(efUserAccount, userAccount);

                if (String.IsNullOrEmpty(userAccount.Id) || String.IsNullOrEmpty(userAccount.Email))
                    throw new NullReferenceException("UserAccount has either no Id or email. Probably something went wrong during copying or retreiving data.");
            }
            catch (Exception ex)
            {
                return _exceptionHandler.HandleException(ex, isServerSideException: true);
            }

            return Ok(userAccount);
        }

        //[Authorize(Roles = Constants.Security.ADMINISTRATOR)]
        [Route(Constants.AccountControllerEndpoints.GET_ALL)]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            IEnumerable<IEFUserAccount> userAccounts;

            try
            {
                userAccounts = await _accountFunctions.ReadAllAsync();
            }
            catch (Exception ex)
            {
                return _exceptionHandler.HandleException(ex, isServerSideException: true);
            }

            return Ok(userAccounts);
        }
        #endregion

        #region Create
        [Route(Constants.AccountControllerEndpoints.CREATE_BY_CREDENTIALS)]
        [HttpPut]
        public async Task<IActionResult> CreateByCredentials([FromBody] CredentialHolder credentialHolder)
        {
            if (!ModelState.IsValid)
                return _exceptionHandler.HandleException(new Exception("ModelState was invalid"), isServerSideException: false);

            try
            {
                var newUserAccount = await _accountFunctions.CreateByEmailAndPasswordAsync(credentialHolder.Email, credentialHolder.Password);

                if (newUserAccount != null && !String.IsNullOrEmpty(newUserAccount.Id) && !String.IsNullOrEmpty(newUserAccount.Email))
                {
                    return new CreatedAtActionResult(
                            actionName: Constants.AccountControllerEndpoints.CREATE_BY_ACCOUNT,
                            controllerName: Constants.APIControllers.ACCOUNT,
                            routeValues: RouteData.Values,
                            value: newUserAccount.Id);
                }
                else
                {
                    throw new Exception("Creating account failed. The user account was null, Email was null or had no id after an attempt to create it");
                }
            }
            catch (Exception ex)
            {
                return _exceptionHandler.HandleException(ex, isServerSideException: true);
            }
        }

        [Authorize(Roles =
            Constants.Security.ADMINISTRATOR + "," +
            Constants.Security.PRIVILEGED_EMPLOYEE + "," +
            Constants.Security.EMPLOYEE)]
        [Route(Constants.AccountControllerEndpoints.CREATE_BY_ACCOUNT)]
        [HttpPut]
        public async Task<IActionResult> CreateByAccount([FromBody] UserAccount userAccount)
        {
            if (!ModelState.IsValid)
                return _exceptionHandler.HandleException(new Exception("ModelState invalid"), isServerSideException: false);

            try
            {
                var newUserAccount = await _accountFunctions.CreateByAccountAsync(userAccount);

                if (newUserAccount != null && !String.IsNullOrEmpty(newUserAccount.Id) && !String.IsNullOrEmpty(newUserAccount.Email))
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
                return _exceptionHandler.HandleException(ex, isServerSideException: true);
            }
        }
        #endregion

        #region Update
        [Route(Constants.AccountControllerEndpoints.UPDATE_BY_ACCOUNT)]
        [HttpPatch]
        public async Task<IActionResult> UpdateByAccount([FromBody] UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _accountFunctions.WriteAsync(userAccount));
            }
            else
            {
                return _exceptionHandler.HandleException(new Exception("ModelState invalid"), isServerSideException: false);
            }
        }
        #endregion

        #region Delete
        //[Authorize]
        [Route(Constants.AccountControllerEndpoints.DELETE_BY_ID)]
        [HttpDelete]
        public async Task<IActionResult> DeleteById([FromQuery] string id)
        {
            if (ModelState.IsValid)
            {
                bool result = false;
                try
                {
                    result = await _accountFunctions.DeleteByIdAsync(id);

                }
                catch (Exception ex)
                {
                    _exceptionHandler.HandleException(ex, isServerSideException: true);
                }

                if (result)
                {
                    return Ok("Account deleted");
                }
                else
                {
                    return _exceptionHandler.HandleException(new Exception("Something went wrong during deletion. The account might still exist"), isServerSideException: true);
                }
            }
            else
            {
                return _exceptionHandler.HandleException(new Exception("ModelState invalid"), isServerSideException: false);
            }
        }
        #endregion

        #region Roles
        [Authorize(Roles = Constants.Security.ADMINISTRATOR)]
        [Route(Constants.AccountControllerEndpoints.ADD_ROLES_TO_ACCOUNT)]
        [HttpPut]
        public async Task<IActionResult> AddRolesToAccountAsync([FromBody] UserRolePairHolder userRolePairHolder)
        {
            if (!ModelState.IsValid)
                return _exceptionHandler.HandleException(new Exception("ModelState was invalid"), isServerSideException: false);

            if (userRolePairHolder.Roles.Count() == 0)
                return _exceptionHandler.HandleException(new Exception("No role(s) to add were found"), isServerSideException: false);

            var result = new IdentityResult();

            try
            {
                result = await _accountFunctions.AddRolesToAccountAsync(userRolePairHolder);
            }
            catch (Exception ex)
            {
                return _exceptionHandler.HandleException(ex, isServerSideException: true);
            }

            if (result.Succeeded)
                return Ok("Role(s) added to account");
            else
            {
                StringBuilder stringBuilder = new StringBuilder();

                foreach (var error in result.Errors)
                {
                    stringBuilder.AppendLine(error.Description);
                }

                return _exceptionHandler.HandleException(new Exception($"Something went wrong during adding the role(s) to the account. {stringBuilder}"), isServerSideException: true);
            }
        }

        [Authorize]
        [Route(Constants.AccountControllerEndpoints.REMOVE_ROLES_FROM_ACCOUNT)]
        [HttpPut]
        public async Task<IActionResult> RemoveRolesFromAccountAsync(UserRolePairHolder userRolePairHolder)
        {
            if (!ModelState.IsValid)
                return _exceptionHandler.HandleException(new Exception("ModelState was invalid"), isServerSideException: false);

            if (userRolePairHolder.Roles.Count() == 0)
                return _exceptionHandler.HandleException(new Exception("No role(s) to add were found"), isServerSideException: false);

            var result = new IdentityResult();

            try
            {
                result = await _accountFunctions.RemoveRolesFromAccountAsync(userRolePairHolder);
            }
            catch(Exception ex)
            {
                return _exceptionHandler.HandleException(ex, isServerSideException: true);
            }

            if (result.Succeeded)
                return Ok("Role(s) removed from account");
            else
            {
                var stringBuilder = new StringBuilder();

                foreach (var error in result.Errors)
                {
                    stringBuilder.AppendLine(error.Description);
                }

                return _exceptionHandler.HandleException(new Exception($"Something went wrong during removing the role(s) from the account. {stringBuilder}"), isServerSideException: true);
            }
        }
        #endregion

        // Confirm email
        [Route(Constants.AccountControllerEndpoints.CONFIRM_EMAIL)]
        [HttpPut]
        public async Task<IActionResult> ConfirmEmail([FromBody] ConfirmEmailHolder confirmEmailHolder)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountFunctions.ConfirmEmailAsync(confirmEmailHolder);

                if (result.Succeeded)
                    return Ok("Email is confirmed");
                else
                {
                    var stringBuilder = new StringBuilder();

                    foreach (var error in result.Errors)
                    {
                        stringBuilder.AppendLine(error.Description);
                    }

                    return _exceptionHandler.HandleException(new Exception($"Something went wrong confirming the email. {stringBuilder}"), isServerSideException: true);
                } 
            }
            else
            {
                return _exceptionHandler.HandleException(new Exception("ModelState was invalid"), isServerSideException: false);
            }
        }
    }
}
