using GRP.IdentityServer.Models;
using GRP.Shared.Core.StringInfo;

using Microsoft.AspNetCore.Identity;

using System.Collections.Generic;

namespace GRP.IdentityServer.Seeding
{
    public static class DefaultUsersAndRoles
    {
        public static IEnumerable<SignUpViewModel> GetDevelopers()
        {
            yield return new SignUpViewModel()
            {
                UserName = "Daniga",
                Email = "me@senrecep.com",
                Password = "Password12*"
            };
        }
        public static IEnumerable<IdentityRole> GetRoles()
        {
            yield return new IdentityRole(RoleInfo.Admin);
            yield return new IdentityRole(RoleInfo.User);
        }
    }

}
