﻿using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

using Duende.IdentityServer.Extensions;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;

using GRP.IdentityServer.Models;

using Microsoft.AspNetCore.Identity;

namespace GRP.IdentityServer.Services
{
    public class CustomProfileService : IProfileService
    {
        private readonly UserManager<ApplicationUser> userManager;

        public CustomProfileService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            string subId = context.Subject.GetSubjectId();
            ApplicationUser user = await userManager.FindByIdAsync(subId);
            IList<string> userRoles = await userManager.GetRolesAsync(user);

            List<Claim> claims = new List<Claim>()
            {
               new Claim(JwtRegisteredClaimNames.Email, user.Email),
               new Claim( "name", user.UserName),
            };

            foreach (string role in userRoles)
                claims.Add(new Claim("role", role));

            context.AddRequestedClaims(claims);

            context.IssuedClaims = claims;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            string subId = context.Subject.GetSubjectId();
            ApplicationUser user = await userManager.FindByIdAsync(subId);
            context.IsActive = user != null;
        }
    }
}

