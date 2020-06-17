﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SharedDependencyInterfaces.Interfaces;
using SharedLibrary.CustomExceptions;
using SharedLibrary.Data;
using SharedLibrary.Helpers;
using SharedLibrary.Models.User;

namespace WebServer.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            //ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<ActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            #region OldCode
            //ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            //if (ModelState.IsValid)
            //{
            //    var user = new UserAccount { UserName = Input.Email, Email = Input.Email };
            //    var result = await _userManager.CreateAsync(user, Input.Password);
            //    if (result.Succeeded)
            //    {
            //        _logger.LogInformation("User created a new account with password.");

            //        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            //        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            //        var callbackUrl = Url.Page(
            //            "/Account/ConfirmEmail",
            //            pageHandler: null,
            //            values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
            //            protocol: Request.Scheme);

            //        await _emailSender.SendEmailAsync(Input.Email, "Confirm your account",
            //            $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            //        if (_userManager.Options.SignIn.RequireConfirmedAccount)
            //        {
            //            return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
            //        }
            //        else
            //        {
            //            await _signInManager.SignInAsync(user, isPersistent: false);
            //            return LocalRedirect(returnUrl);
            //        }
            //    }
            //    foreach (var error in result.Errors)
            //    {
            //        ModelState.AddModelError(string.Empty, error.Description);
            //    }
            //}
            #endregion

            if (ModelState.IsValid)
            {
                try
                {
                    using (var client = new HttpAPIHandler())
                    {
                        var user = new UserAccount 
                        {
                            UserName = Input.Email,
                            Email = Input.Email, 
                            PasswordHash = Input.Password
                        };

                        var stringContent = new StringContent(
                            JsonConvert.SerializeObject(user), 
                            Encoding.UTF8, 
                            HttpAPIHandler.MediaTypes.JSON);

                        using (HttpResponseMessage response = await client.PutAsync(
                            $"{Constants.APIControllers.ACCOUNT}/{Constants.AccountControllerEndpoints.CREATE_BY_ACCOUNT}",
                            stringContent))
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                            }
                            else
                            {
                                var apiErrors = JsonConvert.DeserializeObject<string[]>(await response.Content.ReadAsStringAsync());
                                for (int i = 0; i < apiErrors.Length; i++)
                                {
                                    ModelState.AddModelError(i.ToString(), apiErrors[i]);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}