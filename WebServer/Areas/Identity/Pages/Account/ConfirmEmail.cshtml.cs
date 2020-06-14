using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using SharedLibrary.Data;
using SharedLibrary.Helpers;
using SharedLibrary.Models.Email;
using SharedLibrary.Models.User;

namespace WebServer.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ConfirmEmailModel : PageModel
    {
        public ConfirmEmailModel()
        {
        }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(string userId, string code)
        {
            if (String.IsNullOrEmpty(userId) || String.IsNullOrEmpty(code))
            {
                StatusMessage = "Error confirming your email.";
            }

            var confirmEmailHolder = new ConfirmEmailHolder { UserId = userId, code = code };

            try
            {
                using (var client = new HttpAPIHandler())
                {
                    var stringContent = new StringContent(JsonConvert.SerializeObject(confirmEmailHolder), Encoding.UTF8, "application/json");

                    var response = await client.PutAsync($"{Constants.APIControllers.ACCOUNT}/{Constants.AccountControllerMethods.CONFIRM_EMAIL}", stringContent);

                    if (response.IsSuccessStatusCode)
                    {
                        StatusMessage = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Page();
        }
    }
}
