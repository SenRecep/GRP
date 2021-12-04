
using System.Threading.Tasks;

using GRP.Shared.Core.Models;
using GRP.Shared.Core.Response;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using Serilog;

namespace GRP.Shared.Core.ExtensionMethods
{
    public static class AppBuilderExtensions
    {
        public static void UseCustomExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = "application/json";
                    IExceptionHandlerPathFeature error = context.Features.Get<IExceptionHandlerPathFeature>();

                    if (error != null)
                    {
                        System.Exception ex = error.Error;
                        Response<NoContent> response = Response<NoContent>.Fail(
                            statusCode: StatusCodes.Status500InternalServerError,
                            isShow: ex is CustomException,
                            path: error.Path,
                            ex.Message
                            );
                        Log.Error(ex.Message);
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
                    }

                });
            });
        }

        public static void UseDelayRequestDevelopment(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                await Task.Delay(1000);
                await next.Invoke();
            });
        }
    }
}
