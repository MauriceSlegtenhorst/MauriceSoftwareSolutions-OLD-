using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MTS.PL.Infra.Interfaces.Standard;
using MTS.PL.Web.Blazor.Client.Shared;
using MTS.PL.Web.Blazor.Client.Utils;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace MTS.PL.Web.Blazor.Client.Authentification
{
    public class AuthenticationHandler : DelegatingHandler
    {
        private readonly JWTAuthStateProvider _jwtAuthStateProvider;
        private readonly NavigationManager _navigationManager;

        [CascadingParameter(Name = nameof(MainLayout))]
        public MainLayout MainLayoutInstance { get; set; }

        public AuthenticationHandler(JWTAuthStateProvider jwtAuthStateProvider, NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
            _jwtAuthStateProvider = jwtAuthStateProvider;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var authState = await _jwtAuthStateProvider.GetAuthenticationStateAsync();

            if(authState.User.Identity.IsAuthenticated == true)
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _jwtAuthStateProvider.CurrentToken.Value);
            else
            {
                request.Headers.Authorization = null;
            }

            HttpResponseMessage response = null;

            response = await base.SendAsync(request, cancellationToken);
            
            
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                await _jwtAuthStateProvider.Logout();

                string returnUrl;

                if (_jwtAuthStateProvider.CurrentToken.Expiration < DateTime.UtcNow)
                    returnUrl = BlazorConstants.Pages.Authentication.TOKEN_EXPIRED;
                else
                    returnUrl = BlazorConstants.Pages.Authentication.UNAUTHORIZED;

                _navigationManager.NavigateTo(returnUrl);
            }

            return response;
        }
    }
}
