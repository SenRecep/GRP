﻿using Duende.IdentityServer.EntityFramework.DbContexts;
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
            UserManager<ApplicationUser> userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            foreach (SignUpViewModel model in DefaultUsersAndRoles.GetDevelopers())
            {
                ApplicationUser found = await userManager.FindByNameAsync(model.UserName);
                if (found != null) continue;

                ApplicationUser user = new ApplicationUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                };
                IdentityResult result = await userManager.CreateAsync(user, model.Password);

                if (!result.Succeeded) throw new Exception(result.Errors.First()?.Description);

                result = await userManager.AddToRoleAsync(user, RoleInfo.Admin);

                if (!result.Succeeded) throw new Exception(result.Errors.First()?.Description);
            }
        }


        public static async Task SeedConfiguration(ConfigurationDbContext context)
        {
            List<Task> tasks = new List<Task>();

            if (context.Clients.Count() != Config.Clients.Count())
            {
                await context.Clients.ClearAsync();
                tasks.Add(context.Clients.AddRangeAsync(Config.Clients.Select(x => x.ToEntity())));
            }
            if (context.ApiResources.Count() != Config.ApiResources.Count())
            {
                await context.ApiResources.ClearAsync();
                tasks.Add(context.ApiResources.AddRangeAsync(Config.ApiResources.Select(x => x.ToEntity())));
            }

            if (context.ApiScopes.Count() != Config.ApiScopes.Count())
            {
                await context.ApiScopes.ClearAsync();
                tasks.Add(context.ApiScopes.AddRangeAsync(Config.ApiScopes.Select(x => x.ToEntity())));
            }

            if (context.IdentityResources.Count() != Config.IdentityResources.Count())
            {
                await context.IdentityResources.ClearAsync();
                tasks.Add(context.IdentityResources.AddRangeAsync(Config.IdentityResources.Select(x => x.ToEntity())));
            }

            await Task.WhenAll(tasks);
            await context.SaveChangesAsync();
        }
    }

}
