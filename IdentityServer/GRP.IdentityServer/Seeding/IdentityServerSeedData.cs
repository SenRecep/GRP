using AutoMapper;

using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.EntityFramework.Mappers;

using GRP.IdentityServer.ExtensionMethods;
using GRP.IdentityServer.Models;
using GRP.Shared.Core.StringInfo;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GRP.IdentityServer.Seeding
{
    public static class IdentityServerSeedData
    {

        public static async Task SeedUserData(IServiceProvider serviceProvider)
        {
            await SeedRoles(serviceProvider);
            await SeedUsers(serviceProvider);
        }

        public static async Task SeedRoles(IServiceProvider serviceProvider)
        {
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            foreach (IdentityRole role in DefaultUsersAndRoles.GetRoles())
            {
                IdentityRole found = await roleManager.FindByNameAsync(role.Name);
                if (found != null) continue;

                IdentityResult result = await roleManager.CreateAsync(role);
                if (!result.Succeeded) throw new Exception(result.Errors.First().Description);
            }
        }



        public static async Task SeedUsers(IServiceProvider serviceProvider)
        {
            IMapper mapper = serviceProvider.GetRequiredService<IMapper>();
            UserManager<ApplicationUser> userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            foreach (SignUpViewModel model in DefaultUsersAndRoles.GetDevelopers())
            {
                ApplicationUser found = await userManager.FindByNameAsync(model.UserName);
                if (found != null) continue;

                ApplicationUser user = mapper.Map<ApplicationUser>(model);
                IdentityResult result = await userManager.CreateAsync(user, model.Password);

                if (!result.Succeeded) throw new Exception(result.Errors.First()?.Description);

                result = await userManager.AddToRoleAsync(user, RoleInfo.Admin);

                if (!result.Succeeded) throw new Exception(result.Errors.First()?.Description);
            }
        }


        public static async Task ClearConfiguration(ConfigurationDbContext context)
        {
            await context.Clients.ClearAsync();
            await context.ApiResources.ClearAsync();
            await context.ApiScopes.ClearAsync();
            await context.IdentityResources.ClearAsync();
        }

        public static async Task SeedConfiguration(ConfigurationDbContext context)
        {
            await ClearConfiguration(context);
            await Task.WhenAll(new List<Task>
            {
                context.Clients.AddRangeAsync(Config.Clients.Select(x => x.ToEntity())),
                context.ApiResources.AddRangeAsync(Config.ApiResources.Select(x => x.ToEntity())),
                context.ApiScopes.AddRangeAsync(Config.ApiScopes.Select(x => x.ToEntity())),
                context.IdentityResources.AddRangeAsync(Config.IdentityResources.Select(x => x.ToEntity()))
            });
            await context.SaveChangesAsync();
        }
    }

}
