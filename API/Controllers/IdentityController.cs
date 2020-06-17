using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        private readonly SignInManager<UserAccount> _signInManager;

        public IdentityController(
            IConfiguration configuration, 
            SignInManager<UserAccount> signInManager)
        {
            _configuration = configuration;
            _signInManager = signInManager;
        }

        [HttpGet] 
        public IActionResult Get()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }

        //[AllowAnonymous]
        //[Route(Constants.IdentityControllerEndpoints.LOG_IN)]
        //[HttpGet]
        //public async Task<ActionResult> LogIn([FromBody] CredentialHolder credentials)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(credentials.Email, credentials.Password, credentials.RememberMe, lockoutOnFailure: true);
        //        if (result.Succeeded)
        //        {
        //            return Accepted(_signInManager.);
        //        }
        //        if (result.RequiresTwoFactor)
        //        {
        //            return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
        //        }
        //        if (result.IsLockedOut)
        //        {
        //            _logger.LogWarning("User account locked out.");
        //            return RedirectToPage("./Lockout");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        //            return Page();
        //        }
        //    }
        //}
    }
}