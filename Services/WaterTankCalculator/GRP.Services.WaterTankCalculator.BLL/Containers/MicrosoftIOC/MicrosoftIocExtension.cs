using FluentValidation.AspNetCore;

using GRP.Shared.BLL.Interfaces;
using GRP.Shared.BLL.Managers;
using GRP.Shared.Core.ExtensionMethods;
using GRP.Shared.DAL.Concrete.EntityFrameworkCore.Repositories;
using GRP.Shared.DAL.Interfaces;

using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System.Reflection;

namespace GRP.Services.WaterTankCalculator.BLL.Containers.MicrosoftIOC;

public static class MicrosoftIocExtension
{

    public static void AddDependencies(
        this IServiceCollection services,
        IConfiguration configuration, 
        IWebHostEnvironment environment)
    {
        string connectionString = configuration.GetCustomConnectionString(environment.GetConnectionType());
        string migrationName = "GRP.Services.WaterTankCalculator";

        //services.AddTransient<DbContext, DietPlannerDbContext>();

        //services.AddDbContext<DietPlannerDbContext>(opt =>
        //    opt.UseSqlServer(connectionString, sqlOpt =>
        //        sqlOpt.MigrationsAssembly(migrationName)
        //        )
        //);

        services.AddHttpContextAccessor();


        #region Services
        services.AddTransient(typeof(IGenericQueryService<>), typeof(GenericQueryManager<>));
        services.AddTransient(typeof(IGenericCommandService<>), typeof(GenericCommandManager<>));
        #endregion

        #region Repositoryies
        services.AddTransient(typeof(IGenericCommandRepository<>), typeof(EfGenericCommandRepository<>));
        services.AddTransient(typeof(IGenericQueryRepository<>), typeof(EfGenericQueryRepository<>));
        #endregion

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<ICustomMapper, CustomMapper>();


        //services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
        //services.AddSingleton<IMailSettings>(sp => sp.GetRequiredService<IOptions<MailSettings>>().Value);


    }

    public static void AddValidationDependencies(this IMvcBuilder mvcBuilder)
    {
        mvcBuilder.AddFluentValidation(opt => { }
            //opt.RegisterValidatorsFromAssemblyContaining<ValidationLayer>()
        );
    }
}
