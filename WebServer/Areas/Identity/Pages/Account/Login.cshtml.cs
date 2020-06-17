using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SharedLibrary.Models.User;
using System.Net.Http;
using SharedLibrary.Helpers;
using IdentityModel.Client;
using System;
using System.Diagnostics;
using SharedLibrary.Security;
using Newtonsoft.Json;
using System.Text;
using SharedLibrary.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace WebServer.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        public LoginModel()
        {

        }

        [BindProperty]
        public CredentialHolder CredentialHolder { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public void OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                //TODO hash password first

                using (var client = new HttpAPIHandler())
                {
                    var stringContent = new StringContent(
                           JsonConvert.SerializeObject(CredentialHolder),
                           Encoding.UTF8,
                           HttpAPIHandler.MediaTypes.JSON);

                    using (HttpResponseMessage response = await client.PutAsync(
                        $"{Constants.APIControllers.IDENTITY}/{Constants.IdentityControllerEndpoints.LOG_IN}",
                        stringContent))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var claimsString = JsonConvert.DeserializeObject<string[]>(await response.Content.ReadAsStringAsync());

                            Claim[] claims = new Claim[]
                            {
                                new Claim(ClaimTypes.Name, claimsString[0]),
                                new Claim("FullName", claimsString[1]),
                                new Claim(ClaimTypes.Role, claimsString[2]),
                            };

                            //HttpContext.User = new ClaimsPrincipal(
                            //        new ClaimsIdentity(
                            //            claims: claims,
                            //            authenticationType: ""));

                            var claimsIdentity = new ClaimsIdentity(claims, Constants.CookieConfigurations.DEFAULT_SCHEME);
                            
                            var authProperties = new AuthenticationProperties
                            {
                                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10)
                            };

                            // TODO use AuthenticationProperties
                            await HttpContext.SignInAsync(
                                scheme: Constants.CookieConfigurations.DEFAULT_SCHEME,
                                principal: new ClaimsPrincipal(claimsIdentity),
                                properties: authProperties);

                            return LocalRedirect(returnUrl);
                        }
                        else
                        {
                            ModelState.AddModelError(String.Empty, await response.Content.ReadAsStringAsync());
                        }
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
