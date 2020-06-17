using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using SharedLibrary.Data;
using SharedLibrary.Helpers;
using SharedLibrary.Models.User;

namespace WebServer.Areas.Identity.Pages.Administrator
{
    public class AdministratorPanelModel : PageModel
    {
        [BindProperty]
        public List<UserAccount> UserAccounts { get; set; } = new List<UserAccount>();

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public AdministratorPanelModel()
        {

        }

        public async void OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            ReturnUrl = returnUrl;

        }

        public async void OnPostAsync()
        {
            using (var client = new HttpAPIHandler())
            {
                using (HttpResponseMessage response = await client.GetAsync(
                    $"{Constants.APIControllers.ACCOUNT}/{Constants.AccountControllerEndpoints.GET_ALL}"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        UserAccounts = JsonConvert.DeserializeObject<List<UserAccount>>(await response.Content.ReadAsStringAsync());
                    }
                    else
                    {
                        ModelState.AddModelError(String.Empty, await response.Content.ReadAsStringAsync());
                    }
                }
            }
        }
    }
}
