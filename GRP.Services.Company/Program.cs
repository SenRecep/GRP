
using GRP.Services.Company;
using GRP.Services.Company.Data;
using GRP.Services.Company.Seeding;

using Microsoft.EntityFrameworkCore;

using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);
    var startup = new Startup(builder.Environment, builder.Configuration);
    startup.ConfigureServices(builder.Services);
    startup.ConfigureHost(builder.Host);
    Log.Information("Starting host...");
    var app = builder.Build();
    startup.Configure(app);
    using IServiceScope serviceScope = app.Services.CreateScope();
    IServiceProvider services = serviceScope.ServiceProvider;
    CompanyDbContext context = services.GetRequiredService<CompanyDbContext>();
    Seeder seeder = services.GetRequiredService<Seeder>();
    await context.Database.MigrateAsync();
    await seeder.SeedAsync();
    await app.RunAsync();
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