using Microsoft.AspNetCore.Components;
using MTS.PL.Infra.Interfaces.Standard;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MTS.PL.Web.Blazor.Client.Utils
{
    //public class StatusCodeHandler : DelegatingHandler
    //{
    //    private readonly ILoginService _loginService;
    //    private readonly NavigationManager _navigationManager;

    //    public StatusCodeHandler(
    //        HttpMessageHandler innerHandler, 
    //        ILoginService loginService, 
    //        NavigationManager navigationManager) : 
    //        base(innerHandler) 
    //    {
    //        _loginService = loginService;
    //        _navigationManager = navigationManager;
    //    }

    //    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    //    {
    //        HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

    //        if (response.StatusCode == HttpStatusCode.Unauthorized)
    //        {
    //            await _loginService.Logout();
    //            _navigationManager.NavigateTo(BlazorConstants.Pages.Authentication.UNAUTHORIZED);
    //        }

    //        return response;
    //    }

    //}
}
