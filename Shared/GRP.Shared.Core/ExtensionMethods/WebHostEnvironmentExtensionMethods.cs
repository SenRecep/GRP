using System;


using GRP.Shared.Core.Models;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace GRP.Shared.Core.ExtensionMethods
{
    public static class WebHostEnvironmentExtensionMethods
    {
        public static ConnectionType GetConnectionType(this IWebHostEnvironment environment, bool test = false)
        {
            bool con = environment.IsDevelopment();
            if (test) con = !con;
            return con ? ConnectionType.Local : ConnectionType.Server;
        }


        public static string GetCustomConnectionString(this IConfiguration configuration, ConnectionType type)
        {
            string mechineName = Environment.MachineName;
            string connectionTypeName = Enum.GetName(typeof(ConnectionType), type);
            string result = type switch
            {
                ConnectionType.Server => configuration.GetConnectionString(connectionTypeName),
                ConnectionType.Local => configuration.GetSection($"LocalConnectionStrings:{mechineName}").Get<string>(),
                _ => throw new NotImplementedException(),
            };
            if (type == ConnectionType.Local && result.IsEmpty())
                result = configuration.GetSection($"LocalConnectionStrings:Default").Get<string>();
            return result;
        }



        public static string GetApiUrl(this IWebHostEnvironment environment, IConfiguration configuration,string apiName= "IdentityServer", bool test = false)
        {
            ConnectionType conType = environment.GetConnectionType(test);
            string connectionTypeName = Enum.GetName(typeof(ConnectionType), conType);
            string result = configuration.GetSection($"{apiName}:{connectionTypeName}").Get<string>();
            return result;
        }
    }
}
