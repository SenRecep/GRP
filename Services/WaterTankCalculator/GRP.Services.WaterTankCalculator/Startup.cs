using GRP.Shared.Core.ExtensionMethods;
using GRP.Shared.Core.Filters;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.OpenApi.Models;

using System.Reflection;

using Serilog;
using GRP.Services.WaterTankCalculator.BLL.Containers.MicrosoftIOC;

namespace GRP.Services.WaterTankCalculator;

public class Startup
{
    public IWebHostEnvironment Environment { get; }
    public IConfiguration Configuration { get; }
    public string IdentityServerUrl { get; init; }

    public Startup(IWebHostEnvironment environment, IConfiguration configuration)
    {
        Environment = environment;
        Configuration = configuration;
        IdentityServerUrl = Environment.GetIdentityServerUrl(Configuration);
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDependencies(Configuration, Environment);

        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
            {
                opt.Authority = IdentityServerUrl;
                opt.Audience = "resource_watertankcalculator";
                opt.RequireHttpsMetadata = !Environment.IsDevelopment();
            });

        services.AddHttpClient();

        //services.AddHttpClient<IImageService, ImageService>(opt =>
        //{
        //    opt.BaseAddress = new(Environment.GetWebApiUrl(Configuration));
        //});

        services.AddControllers(opt =>
        {
            opt.Filters.Add(new AuthorizeFilter());
            opt.Filters.Add<ValidateModelAttribute>();
        }).AddValidationDependencies();

        services.AddCustomValidationResponse();

        services.AddSwaggerGen(s =>
        {
            s.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = $"{this.GetType().Namespace}",
                Version = "v1",
                Description = "GRP Water Tank Calculator",
                License = new OpenApiLicense
                {
                    Name = "MIT",
                    Url = new Uri("https://github.com/SenRecep/GRP/blob/master/LICENSE")
                }
            });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            s.IncludeXmlComments(xmlPath);


            var jwtSecurityScheme = new OpenApiSecurityScheme
            {
                Scheme = "bearer",
                BearerFormat = "JWT",
                Name = "JWT Authentication",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };

            s.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

            s.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecurityScheme, Array.Empty<string>() }
                });
        });
    }

    public void Configure(IApplicationBuilder app)
    {
        if (Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{this.GetType().Namespace} v1"));

        app.UseCustomExceptionHandler();

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseCors("CorsPolicy");

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }

    public void ConfigureHost(IHostBuilder host)
    {
        host.ConfigureLogging(config =>
        {
            config.ClearProviders();
            config.AddSerilog(LoggerExtensionMethods.SerilogInit());
        }).ConfigureAppConfiguration(config =>
        {
            config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            config.AddJsonFile("modules.json");
            config.AddJsonFile("products.json");
            config.AddJsonFile("rats.json");
        });
    }
}

