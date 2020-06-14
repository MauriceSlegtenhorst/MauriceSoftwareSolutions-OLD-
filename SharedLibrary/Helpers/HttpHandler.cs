using SharedLibrary.Data;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SharedLibrary.Helpers
{
    public sealed class HttpAPIHandler : HttpClient
    {
        public HttpAPIHandler()
        {
            BaseAddress = new Uri(Constants.API_BASE_ADDRESS);
        }

        public HttpAPIHandler(string accessToken)
        {
            if (String.IsNullOrEmpty(accessToken))
                throw new ArgumentNullException("The access token was null");

            BaseAddress = new Uri(Constants.API_BASE_ADDRESS);

            DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }
    }
}
