using Microsoft.AspNetCore.Components;
using MTS.PL.Infra.Interfaces.Standard;
using MTS.PL.Web.Blazor.Client.Utils;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MTS.PL.Web.Blazor.Client.Authentification
{
    public class AuthenticationHandler : DelegatingHandler
    {
        private readonly ILoginService _loginService;
        private readonly NavigationManager _navigationManager;

        public AuthenticationHandler(ILoginService loginService, NavigationManager navigationManager)
        {
            _loginService = loginService;
            _navigationManager = navigationManager;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);
            
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                await _loginService.Logout();
                _navigationManager.NavigateTo(BlazorConstants.Pages.Authentication.UNAUTHORIZED);
            }

            return response;
        }
    }
}
