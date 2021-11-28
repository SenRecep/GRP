using GRP.Shared.Core.ExtensionMethods;

using IdentityModel.Client;

namespace GRP.Gateway.DelegateHandlers
{
    public class TokenExchangeDelegateHandler : DelegatingHandler
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment webHostEnvironment;
        private string _access_token = string.Empty;

        public TokenExchangeDelegateHandler(HttpClient httpClient, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            this.httpClient = httpClient;
            this.configuration = configuration;
            this.webHostEnvironment = webHostEnvironment;
        }
        private async Task<string> GetTokenAsync(string? requestToken)
        {
            if (!_access_token.IsEmpty()) return _access_token;

            var disco = await httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest()
            {
                Address = webHostEnvironment.GetApiUrl(configuration),
                Policy = new DiscoveryPolicy() { RequireHttps = false },
            });
            if (disco.IsError) throw disco.Exception;
            TokenExchangeTokenRequest tokenExchangeTokenRequest = new()
            {
                Address = disco.TokenEndpoint,
                ClientId = configuration["ClientId"],
                ClientSecret = configuration["ClientSecret"],
                GrantType = configuration["GrantType"],
                SubjectToken = requestToken,
                SubjectTokenType = "urn:ietf:params:oauth:token-type:access_token",
                Scope = "openid watertankcalculator_fullpermission"
            };
            //todo scope kismi diger taraftaki api izinleeri olacak
            var token_response = await httpClient.RequestTokenExchangeTokenAsync(tokenExchangeTokenRequest);
            if (token_response.IsError) throw token_response.Exception;
            _access_token = token_response.AccessToken;
            return _access_token;

        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string? requestToken = request.Headers.Authorization?.Parameter;
            if (requestToken.IsEmpty()) throw new ArgumentNullException(nameof(requestToken));
            var new_token = await GetTokenAsync(requestToken);
            request.SetBearerToken(new_token);
            return await SendAsync(request, cancellationToken);
        }
    }
}
