using SharedLibrary.Data;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SharedLibrary.Helpers
{
    public sealed class HttpHandler : HttpClient
    {
        public HttpHandler()
        {
            BaseAddress = new Uri(Constants.BASE_ADDRESS);
        }

        public HttpHandler(string accessToken)
        {
            if (String.IsNullOrEmpty(accessToken))
                throw new ArgumentNullException("The access token was null");

            BaseAddress = new Uri(Constants.BASE_ADDRESS);

            DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }
    }
}
