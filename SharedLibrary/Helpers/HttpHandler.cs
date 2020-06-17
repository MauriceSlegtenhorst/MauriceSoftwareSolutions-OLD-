using SharedLibrary.Data;
using System;
using System.Collections;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SharedLibrary.Helpers
{
    public sealed class HttpAPIHandler : HttpClient
    {
        public static class MediaTypes
        {
            public const string JSON = "application/json";
            public const string FORM_URL_ENCODED = "application/x-www-form-urlencoded";
            public const string MULTIPART_FORM_DATA = "multipart/form-data";
        }

        public enum Status
        {
            Success,
            Danger,
            Warning,
            Info
        }

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
