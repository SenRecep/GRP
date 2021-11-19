using FluentValidation.AspNetCore;

using GRP.Services.WaterTankCalculator.BLL.Interfaces;
using GRP.Services.WaterTankCalculator.BLL.Managers;
using GRP.Shared.BLL.Interfaces;
using GRP.Shared.BLL.Managers;
using GRP.Shared.Core.ExtensionMethods;
using GRP.Shared.DAL.Concrete.EntityFrameworkCore.Repositories;
using GRP.Shared.DAL.Interfaces;

using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

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
        string migrationName = nameof(GRP.Services.WaterTankCalculator);

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

        services.AddScoped<IEdgeService, EdgeManager>();
        services.AddScoped<IModuleService, ModuleManager>();
        #endregion

        #region Repositoryies
        services.AddTransient(typeof(IGenericCommandRepository<>), typeof(EfGenericCommandRepository<>));
        services.AddTransient(typeof(IGenericQueryRepository<>), typeof(EfGenericQueryRepository<>));
        #endregion

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<ICustomMapper, CustomMapper>();


        services.Configure<ModuleGroup>(configuration.GetSection("ModuleGroup"));
        services.AddScoped(sp => sp.GetRequiredService<IOptions<ModuleGroup>>().Value);


    }

    public static void AddValidationDependencies(this IMvcBuilder mvcBuilder)
    {
        mvcBuilder.AddFluentValidation(opt => { }
            //opt.RegisterValidatorsFromAssemblyContaining<ValidationLayer>()
        );
    }
}
