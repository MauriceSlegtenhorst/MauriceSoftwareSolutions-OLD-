using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Net.Http;
using System.Net.Http.Headers;
using MTS.PL.Web.Blazor.Client.Utils;
using Newtonsoft.Json;
using MTS.PL.Infra.Interfaces.Standard;
using MTS.PL.Infra.Entities.Standard;
using Microsoft.AspNetCore.Components;
using System.Diagnostics;

namespace MTS.PL.Web.Blazor.Client.Authentification
{
    public class JWTAuthStateProvider : AuthenticationStateProvider, ILoginService
    {
        private readonly IJSRuntime _js;
        private readonly HttpClient _httpClient;
        private static readonly string TOKENKEY = "TOKENKEY";
        private readonly NavigationManager _navigationManager;

        private AuthenticationState Anonymous => new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

        public JWTAuthStateProvider(IJSRuntime js, HttpClient httpClient, NavigationManager navigationManager)
        {
            _js = js;
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _js.GetFromLocalStorage(TOKENKEY);

            if (string.IsNullOrEmpty(token))
            {
                return Anonymous;
            }

            var authState = BuildAuthenticationState(token);

            if(authState.User.Identity.IsAuthenticated == false)
            {
                await Logout();
                _navigationManager.NavigateTo(BlazorConstants.Pages.Authentication.LOGIN);
            }

            return authState;
        }

        public async Task Login(string token)
        {
            await _js.SetInLocalStorage(TOKENKEY, token);
            var authState = BuildAuthenticationState(token);
            NotifyAuthenticationStateChanged(Task.FromResult(authState));
        }

        public async Task Logout()
        {
            _httpClient.DefaultRequestHeaders.Authorization = null;
            await _js.RemoveItem(TOKENKEY);
            NotifyAuthenticationStateChanged(Task.FromResult(Anonymous));
        }

        private AuthenticationState BuildAuthenticationState(string token)
        {
            var authState = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt")));

            var tokenObject = JsonConvert.DeserializeObject<PLUserToken>(token);

            // TODO Is this really working --> expecting true if token has expired. Looks like the opposite.
            if (tokenObject.Expiration > DateTime.Now)
                return new AuthenticationState(new ClaimsPrincipal());
            

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenObject.Value);

            return authState;
        }

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var claims = new List<Claim>();

            var payload = jwt.Split('.');

            var jsonBytes = ParseBase64WithoutPadding(payload[2]);
            var keyValuePairs = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);

            if (roles != null)
            {
                if (roles.ToString().Trim().StartsWith("["))
                {
                    var parsedRoles = JsonConvert.DeserializeObject<string[]>(roles.ToString());

                    foreach (var parsedRole in parsedRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, parsedRole));
                    }
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
                }

                keyValuePairs.Remove(ClaimTypes.Role);
            }

            claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));

            return claims;
        }

        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }

            return Convert.FromBase64String(base64);
        }

    }
}
