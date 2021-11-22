using GRP.Services.WaterTankCalculator;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);
    var startup = new Startup(builder.Environment,builder.Configuration);
    startup.ConfigureServices(builder.Services);
    startup.ConfigureHost(builder.Host);
    Log.Information("Starting host...");
    var app = builder.Build();
    startup.Configure(app);
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