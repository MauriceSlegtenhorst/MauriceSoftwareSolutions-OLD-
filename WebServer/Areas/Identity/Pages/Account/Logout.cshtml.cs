using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SharedLibrary.Data;
using SharedLibrary.Helpers;
using SharedLibrary.Models.User;

namespace WebServer.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<UserAccount> _signInManager;

        public LogoutModel()
        {

        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            using (var client = new HttpAPIHandler())
            {
                await client.GetAsync(
                    $"{Constants.APIControllers.IDENTITY}/{Constants.IdentityControllerEndpoints.LOG_OUT}");

                await HttpContext.SignOutAsync();
            }

            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}
