using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Duende.IdentityServer.EntityFramework.DbContexts;

using GRP.IdentityServer.Data;
using GRP.IdentityServer.Seeding;
using GRP.Shared.Core.ExtensionMethods;

using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Serilog;


namespace GRP.IdentityServer
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            try
            {
                IHost host = CreateHostBuilder(args).Build();

                using IServiceScope serviceScope = host.Services.CreateScope();

                IServiceProvider services = serviceScope.ServiceProvider;

                ConfigurationDbContext configurationDbContext = services.GetRequiredService<ConfigurationDbContext>();
                ApplicationDbContext applicationDbContext = services.GetRequiredService<ApplicationDbContext>();
                PersistedGrantDbContext persistedGrantDbContext = services.GetRequiredService<PersistedGrantDbContext>();

                await Task.WhenAll(new List<Task>() {
                     applicationDbContext.Database.MigrateAsync(),
                     configurationDbContext.Database.MigrateAsync(),
                     persistedGrantDbContext.Database.MigrateAsync()
                });


                await Task.WhenAll(new List<Task>()
                {
                    IdentityServerSeedData.SeedConfiguration(configurationDbContext),
                    IdentityServerSeedData.SeedUserData(services)
                });

                Log.Information("Starting host...");
                await host.RunAsync();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly.");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>()
                        .ConfigureLogging((hostingContext, config) =>
                        {
                            config.ClearProviders();
                            config.AddSerilog(LoggerExtensionMethods.SerilogInit());
                        });
                    }).ConfigureAppConfiguration((context, config) =>
                    {
                        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                    });
    }
}