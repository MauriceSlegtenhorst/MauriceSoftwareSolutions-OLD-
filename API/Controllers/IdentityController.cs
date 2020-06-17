using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SharedLibrary.Data;
using SharedLibrary.Models.User;
using SharedLibrary.Security;

namespace API.Controllers
{
    [Route(Constants.APIControllers.IDENTITY)]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<UserAccount> _userManager;
        private readonly SignInManager<UserAccount> _signInManager;

        public IdentityController(
            IConfiguration configuration,
            UserManager<UserAccount> userManager,
            SignInManager<UserAccount> signInManager)
        {
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [Route(Constants.IdentityControllerEndpoints.LOG_IN)]
        [HttpPut]
        public async Task<ActionResult> LogIn([FromBody] CredentialHolder credentials)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid credentials");

            UserAccount userAccount = await _userManager.FindByEmailAsync(credentials.Email);
            if (userAccount == null)
            {
                return Unauthorized("Invalid login.");
            }

            if (!userAccount.EmailConfirmed)
            {
                return Unauthorized("Email not yet confirmed");
            }


            //await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            var result = await _signInManager.PasswordSignInAsync(credentials.Email, credentials.Password, isPersistent: credentials.RememberMe, lockoutOnFailure: true);
            if (!result.Succeeded)
            {
                return Unauthorized("Invalid login");
            }
            
            //var claims2 = new List<Claim>
            //        {
            //            new Claim(ClaimTypes.Name, userAccount.Email),
            //            new Claim("FullName", $"{userAccount.FirstName}{(String.IsNullOrEmpty(userAccount.Affix) ? String.Empty : $" {userAccount.Affix}") } {userAccount.LastName}"),
            //            new Claim(ClaimTypes.Role, userAccount.AccesLevel.ToString()),
            //        };

            string[] claims = new string[]
            {
                 userAccount.Email,
                 $"{userAccount.FirstName}{(String.IsNullOrEmpty(userAccount.Affix) ? String.Empty : $" {userAccount.Affix}") } {userAccount.LastName}",
                 Enum.GetName(typeof(AccessLevel), userAccount.AccessLevel)
            };
        
            return Accepted("Login succesfull. Cookie created", claims);
        }

        [Route(Constants.IdentityControllerEndpoints.LOG_OUT)]
        [HttpGet]
        public async Task<ActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();

            return Ok("Logout succesfull");
        }
    }
}