using Duende.IdentityServer.Models;

using IdentityModel;

namespace GRP.IdentityServer.Services
{
    public class ProfileWithRoleIdentityResource : IdentityResources.Profile
    {
        public ProfileWithRoleIdentityResource()
        {
            UserClaims.Add(JwtClaimTypes.Role);
        }
    }
}
