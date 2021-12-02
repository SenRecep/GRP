using GRP.Gateway.DelegateHandlers;
using GRP.Shared.Core.ExtensionMethods;

using Ocelot.DependencyInjection;
using Ocelot.Middleware;

using Serilog;
try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Host.ConfigureLogging(config =>
    {
        config.ClearProviders();
        config.AddSerilog(LoggerExtensionMethods.SerilogInit());
    });
    builder.Host.ConfigureAppConfiguration((context, config) =>
    {
        config
        .AddJsonFile($"configuration.{context.HostingEnvironment.EnvironmentName.ToLower()}.json")
        .AddEnvironmentVariables();
    });

    string identityUrl = builder.Environment.GetApiUrl(builder.Configuration);
    bool isDevelopment = builder.Environment.IsDevelopment();
    builder.Services.AddAuthentication()
               .AddJwtBearer("GatewayAuthanticationScheme", opt =>
               {
                   opt.Authority = identityUrl;
                   opt.Audience = "resource_gateway";
                   opt.RequireHttpsMetadata = false;
               });


    builder.Services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy", builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
    });

    builder.Services.AddHttpClient<TokenExchangeDelegateHandler>();
    //builder.Services.AddOcelot().AddDelegatingHandler<TokenExchangeDelegateHandler>();
    builder.Services.AddOcelot();
    var app = builder.Build();
    app.UseCors("CorsPolicy");
    app.UseCustomExceptionHandler();
    await app.UseOcelot();
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