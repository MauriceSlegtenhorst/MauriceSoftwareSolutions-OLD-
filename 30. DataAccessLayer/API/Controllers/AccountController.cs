using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MTS.Core.GlobalLibrary;
using MTS.Core.GlobalLibrary.Utils;
using System.Linq;
using MTS.PL.API.Utils.ExceptionHandler;
using Microsoft.AspNetCore.Identity;
using System.Text;
using System.Security.Claims;
using MTS.PL.Infra.Interfaces.Standard;
using MTS.PL.Infra.Interfaces.Standard.DatabaseAdapter;
using MTS.PL.Infra.Entities.Standard;
using MTS.PL.Entities.Core;
using MTS.PL.Entities.Standard;

namespace MTS.PL.API.Controllers
{
    [ApiController]
    [Route(Constants.APIControllers.ACCOUNT)]
    public class AccountController : ControllerBase
    {
        private readonly IAccountAdapter _accountAdapter;
        private readonly IExceptionHandler _exceptionHandler;

        public AccountController(
            IAccountAdapter accountFunctions,
            IExceptionHandler exceptionHandler)
        {
            _accountAdapter = accountFunctions;
            _exceptionHandler = exceptionHandler;
        }

        #region Get
        [Authorize(
            Constants.Security.ADMINISTRATOR + "," +
            Constants.Security.PRIVILEGED_EMPLOYEE + "," +
            Constants.Security.EMPLOYEE
            )]
        [Route(Constants.AccountControllerEndpoints.GET_BY_ID)]
        [HttpGet]
        public async Task<IActionResult> GetByIdAsync([FromBody] string id)
        {
            if (string.IsNullOrEmpty(id))
                return _exceptionHandler.HandleException(new NullReferenceException("Parameter id is required. Id  was null or empty."), isServerSideException: false);

            IPLUserAccount userAccount;

            try
            {
                var efUserAccount = await _accountAdapter.ReadByIdAsync(id);

                userAccount = new PLUserAccount();

                PropertyCopier<DALUserAccount, PLUserAccount>.Copy((DALUserAccount)efUserAccount, (PLUserAccount)userAccount);

                if (string.IsNullOrEmpty(userAccount.Id) || string.IsNullOrEmpty(userAccount.Email))
                    throw new NullReferenceException("UserAccount has either no Id or email. Probably something went wrong during copying or retreiving data.");
            }
            catch (Exception ex)
            {
                return _exceptionHandler.HandleException(ex, isServerSideException: true);
            }

            return Ok(userAccount);
        }

        [Authorize]
        [Route(Constants.AccountControllerEndpoints.GET_BY_EMAIL)]
        [HttpGet]
        public async Task<IActionResult> GetByEmailAsync([FromBody] ICredentialHolder credentialHolder)
        {
            if (!ModelState.IsValid)
                return _exceptionHandler.HandleException(new NullReferenceException("ModelState was invalid"), isServerSideException: false);

            IPLUserAccount plUserAccount;

            try
            {
                var dalUserAccount = await _accountAdapter.ReadByEmailAsync(credentialHolder);

                plUserAccount = new PLUserAccount();

                PropertyCopier<DALUserAccount, PLUserAccount>.Copy((DALUserAccount)dalUserAccount, (PLUserAccount)plUserAccount);

                if (string.IsNullOrEmpty(plUserAccount.Id))
                    throw new NullReferenceException("UserAccount has either no Id . Probably something went wrong during copying or retreiving data.");

                if(string.IsNullOrEmpty(plUserAccount.Email))
                    throw new NullReferenceException("UserAccount has either no email. Probably something went wrong during copying or retreiving data.");
            }
            catch (Exception ex)
            {
                return _exceptionHandler.HandleException(ex, isServerSideException: true);
            }

            return Ok(plUserAccount);
        }

        [Authorize(
            Roles =
            Constants.Security.ADMINISTRATOR + "," +
            Constants.Security.PRIVILEGED_EMPLOYEE)]
        [Route(Constants.AccountControllerEndpoints.GET_ALL)]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            IEnumerable<IBLUserAccount> dalUserAccounts;

            try
            {
                dalUserAccounts = await _accountAdapter.ReadAllAsync();

                if (dalUserAccounts.Any() == false)
                    throw new Exception("No accounts found");
            }
            catch (Exception ex)
            {
                return _exceptionHandler.HandleException(ex, isServerSideException: true);
            }

            return Ok(dalUserAccounts);
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
                var newUserAccount = await _accountAdapter.CreateByEmailAndPasswordAsync(credentialHolder.Email, credentialHolder.Password);

                if (newUserAccount != null && !string.IsNullOrEmpty(newUserAccount.Id) && !string.IsNullOrEmpty(newUserAccount.Email))
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
        public async Task<IActionResult> CreateByAccount([FromBody] PLUserAccount userAccount)
        {
            if (!ModelState.IsValid)
                return _exceptionHandler.HandleException(new Exception("ModelState invalid"), isServerSideException: false);

            try
            {
                var newUserAccount = await _accountAdapter.CreateByAccountAsync(userAccount);

                if (newUserAccount != null && !string.IsNullOrEmpty(newUserAccount.Id) && !string.IsNullOrEmpty(newUserAccount.Email))
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
        public async Task<IActionResult> UpdateByAccount([FromBody] PLUserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _accountAdapter.WriteAsync(userAccount));
            }
            else
            {
                return _exceptionHandler.HandleException(new Exception("ModelState invalid"), isServerSideException: false);
            }
        }
        #endregion

        #region Delete
        [Authorize]
        [Route(Constants.AccountControllerEndpoints.DELETE_BY_ID)]
        [HttpDelete]
        public async Task<IActionResult> DeleteById([FromQuery] string id)
        {
            if (!ModelState.IsValid)
                return _exceptionHandler.HandleException(new Exception("ModelState invalid"), isServerSideException: false);

            IdentityResult result = new IdentityResult();

            try
            {
                result = await _accountAdapter.DeleteByIdAsync(id, User.FindFirst(ClaimTypes.Email).Value);
            }
            catch (Exception ex)
            {
                _exceptionHandler.HandleException(ex, isServerSideException: true);
            }

            if (result.Succeeded)
            {
                return Ok("Account deleted");
            }
            else
            {
                return _exceptionHandler.HandleException(new Exception("Something went wrong during deletion. The account might still exist."), isServerSideException: true);
            }
        }
        #endregion

        #region Roles
        [Authorize(Roles = Constants.Security.ADMINISTRATOR)]
        [Route(Constants.AccountControllerEndpoints.ADD_ROLES_TO_ACCOUNT)]
        [HttpPatch]
        public async Task<IActionResult> AddRolesToAccountAsync([FromBody] UserRolePairHolder userRolePairHolder)
        {
            if (!ModelState.IsValid)
                return _exceptionHandler.HandleException(new Exception("ModelState was invalid"), isServerSideException: false);

            IdentityResult result;
            try
            {
                result = await _accountAdapter.AddRolesToAccountAsync(userRolePairHolder.Id, userRolePairHolder.Roles);
            }
            catch (Exception ex)
            {
                return _exceptionHandler.HandleException(ex, isServerSideException: true);
            }

            if (result.Succeeded)
                return Ok("Role(s) added to account.");
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

        [Authorize(Roles = Constants.Security.ADMINISTRATOR)]
        [Route(Constants.AccountControllerEndpoints.REMOVE_ROLES_FROM_ACCOUNT)]
        [HttpPatch]
        public async Task<IActionResult> RemoveRolesFromAccountAsync([FromBody] UserRolePairHolder userRolePairHolder)
        {
            if (!ModelState.IsValid)
                return _exceptionHandler.HandleException(new Exception("ModelState was invalid"), isServerSideException: false);

            IdentityResult result;

            try
            {
                result = await _accountAdapter.RemoveRolesFromAccountAsync(userRolePairHolder.Id, userRolePairHolder.Roles);
            }
            catch (Exception ex)
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
                var result = await _accountAdapter.ConfirmEmailAsync(confirmEmailHolder.UserId, confirmEmailHolder.Code);

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
