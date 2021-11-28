using GRP.Gateway.DelegateHandlers;
using GRP.Shared.Core.ExtensionMethods;

using Microsoft.AspNetCore.Authentication.JwtBearer;

using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
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
               opt.RequireHttpsMetadata = !isDevelopment;
           });

builder.Services.AddHttpClient<TokenExchangeDelegateHandler>();
builder.Services.AddOcelot().AddDelegatingHandler<TokenExchangeDelegateHandler>();
var app = builder.Build();
app.UseCustomExceptionHandler();
await app.UseOcelot();
await app.RunAsync();
