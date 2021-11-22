using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace GRP.Shared.Core.ExtensionMethods
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCustomValidationResponse(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(opt =>
            {
                opt.InvalidModelStateResponseFactory = context =>
                {
                    return context.GetBadRequestResultErrorDtoForModelState();
                };
            });
        }
        public static void AddSetting<T>(this IServiceCollection services,IConfiguration configuration, string jsonName) where T:class,new()
        {
            services.Configure<T>(configuration.GetSection(jsonName));
            services.AddTransient(sp => sp.GetRequiredService<IOptions<T>>().Value);
        }

    }
}
