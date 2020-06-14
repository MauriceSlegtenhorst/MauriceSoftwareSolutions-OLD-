using Microsoft.AspNetCore.Authorization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using SharedLibrary.Models.User;
using SharedDependencyInterfaces.Interfaces;
using SharedLibrary.Helpers;
using SharedLibrary.Data;
using System.Net.Http;
using Newtonsoft.Json;
using System;

namespace WebServer.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterConfirmationModel : PageModel
    {
        public RegisterConfirmationModel()
        {

        }

        public string Email { get; set; }

        public bool DisplayConfirmAccountLink { get; set; }

        public string EmailConfirmationUrl { get; set; }

        public async Task<IActionResult> OnGetAsync(string email, string returnUrl = null)
        {
            if (email == null)
            {
                return RedirectToPage("/Index");
            }

            UserAccount userAccount = new UserAccount();

            try
            {
                using (var client = new HttpAPIHandler())
                {
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri($"{Constants.APIControllers.ACCOUNT}/{Constants.AccountControllerMethods.GET_BY_EMAIL}", UriKind.Relative),
                        Content = new StringContent(JsonConvert.SerializeObject(email), Encoding.UTF8, "application/json")
                    };

                    var response = await client.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        userAccount = JsonConvert.DeserializeObject<UserAccount>(await response.Content.ReadAsStringAsync());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (userAccount == null)
            {
                return NotFound($"Unable to load user with email '{email}'.");
            }

            Email = email;

            return Page();
        }
    }
}
