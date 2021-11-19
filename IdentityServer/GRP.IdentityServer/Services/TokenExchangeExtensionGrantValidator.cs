using Duende.IdentityServer.Models;
using Duende.IdentityServer.Validation;

using GRP.Shared.Core.ExtensionMethods;

using System.Linq;
using System.Threading.Tasks;

namespace GRP.IdentityServer.Services
{
    public class TokenExchangeExtensionGrantValidator : IExtensionGrantValidator
    {
        public string GrantType => "urn:ietf:params:oauth:grant-type:token-exchange";
        private readonly ITokenValidator _tokenValidator;

        public TokenExchangeExtensionGrantValidator(ITokenValidator tokenValidator)
        {
            _tokenValidator = tokenValidator;
        }

        public async Task ValidateAsync(ExtensionGrantValidationContext context)
        {
            var requestRaw = context.Request.Raw;
            var token = requestRaw.Get("subject_token");
            if (token.IsEmpty())
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidRequest,"token missing");
                return;
            }
            var validateResult=await _tokenValidator.ValidateAccessTokenAsync(token);
            if (validateResult.IsError)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "token invalid");
                return;
            }
            var subClaim = validateResult.Claims.FirstOrDefault(x=>x.Type=="sub");
            if (subClaim.IsNull())
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "token must contain sub value");
                return;
            }

            context.Result=new GrantValidationResult(subClaim.Value,"access_token",validateResult.Claims);
        }
    }
}
