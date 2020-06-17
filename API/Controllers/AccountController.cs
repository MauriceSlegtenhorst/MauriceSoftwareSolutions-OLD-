using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using API.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SharedDependencyInterfaces.Interfaces;
using SharedLibrary.CustomExceptions;
using SharedLibrary.Data;
using SharedLibrary.Helpers;
using SharedLibrary.Models.Email;
using SharedLibrary.Models.User;

namespace API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route(Constants.APIControllers.ACCOUNT)]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<UserAccount> _userManager;
        private readonly IEmailSender _emailSender;

        public AccountController(
            IConfiguration configuration,
            UserManager<UserAccount> userManager,
            IEmailSender emailSender)
        {
            _configuration = configuration;
            _userManager = userManager;
            _emailSender = emailSender;
        }

        #region Scaffolding
        //// GET: account
        //[Authorize]
        //[HttpGet]
        //public async Task<ActionResult<UserAccount[]>> Get()
        //{
        //    var accounts = await _applicationDbContext.UserAccounts.ToArrayAsync();

        //    if (accounts.Any())
        //        return Ok(accounts);
        //    else
        //        return NotFound("No account were found");
        //}

        //// GET: account/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: account
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}
        #endregion

        // Account/getbyid
        [Route(Constants.AccountControllerEndpoints.GET_BY_ID)]
        [HttpGet]
        public async Task<ActionResult<UserAccount>> GetById([FromBody] string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        // Account/getbyemail
        [Route(Constants.AccountControllerEndpoints.GET_BY_EMAIL)]
        [HttpGet]
        public async Task<ActionResult<UserAccount>> GetByEmail([FromBody] string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        // Account/createbyaccount
        [Route(Constants.AccountControllerEndpoints.CREATE_BY_ACCOUNT)]
        [HttpPut]
        public async Task<ActionResult> CreateByAccount([FromBody] UserAccount userAccount)
        {
            IdentityResult result;

            if (ModelState.IsValid)
            {
                try
                {
                    result = await _userManager.CreateAsync(userAccount, userAccount.PasswordHash);
                    if (result != null && result.Succeeded)
                    {
                        //_logger.LogInformation("User created a new account with password.");

                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(userAccount);
                        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                        var callbackUrl = $"{Constants.WEBSERVER_BASE_ADDRESS}/Identity/Account/ConfirmEmail?area=Identity&userId={userAccount.Id}&code={code}&page=/Account/ConfirmEmail";

                        await _emailSender.SendEmailAsync(
                            userAccount.Email,
                            "Confirm your email",
                            $"Welcome to the Maurice Tech Community!\n" +
                            $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                        return new CreatedAtActionResult(
                            Constants.AccountControllerEndpoints.CREATE_BY_ACCOUNT,
                            Constants.APIControllers.ACCOUNT,
                            RouteData.Values,
                            userAccount.Id);
                    }
                    else
                    {
                        var errors = new string[result.Errors.Count()];
                        for (int i = 0; i < errors.Length; i++)
                        {
                            errors[i] = result.Errors.ElementAt(i).Description;
                        }

                        return StatusCode(500, errors);   
                    }
                }
                catch (Exception ex)
                {
                    return await HandleException(ex);
                }
            }
            else
            {
                return BadRequest("ModelState invalid");
            }
        }

        // Confirm email
        [Route(Constants.AccountControllerEndpoints.CONFIRM_EMAIL)]
        [HttpPut]
        public async Task<ActionResult> ConfirmEmail([FromBody] ConfirmEmailHolder confirmEmailHolder)
        {
            if (ModelState.IsValid)
            {
                var userAccount = await _userManager.FindByIdAsync(confirmEmailHolder.UserId);

                confirmEmailHolder.code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(confirmEmailHolder.code));
                var result = await _userManager.ConfirmEmailAsync(userAccount, confirmEmailHolder.code);

                return Ok(result.Succeeded ? "Succes! Thank you for confirming your email." : "Error confirming your email.");
            }
            else
            {
                return BadRequest("ModelState invalid");
            }
        }

        // Delete
        [Authorize]
        [Route(Constants.AccountControllerEndpoints.DELETE_BY_ID)]
        [HttpDelete]
        public void DeleteById([FromBody]int id)
        {
        }

        private async Task<ActionResult> HandleException(Exception ex)
        {
            LogWriter logWriter = new LogWriter(_configuration.GetValue<string>(WebHostDefaults.ContentRootKey));
            if (await logWriter.WriteLineAsync(Assembly.GetCallingAssembly().GetName().Name, ex))
            {
#if DEBUG
                return StatusCode(500, new APIException("Exception caught and logged.", ex));
#else
                return StatusCode(500, new APIException());
#endif
            }
            else
            {
#if DEBUG
                return StatusCode(500 , new APIException("Exception caught but writing to the log failed. See API trace for more details.", ex));
#else
                return StatusCode(500, new APIException());
#endif
            }
        }
    }
}
