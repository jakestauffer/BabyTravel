using Microsoft.AspNetCore.Components.WebAssembly.Http;

namespace BabyTravel.UI.Client.Auth
{
    public class CookieHandler : DelegatingHandler
    {
        public CookieHandler()// : base(new HttpClientHandler())
        { 
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
