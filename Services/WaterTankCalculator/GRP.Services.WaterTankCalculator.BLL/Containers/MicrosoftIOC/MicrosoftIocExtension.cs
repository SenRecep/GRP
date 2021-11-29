using FluentValidation.AspNetCore;

using GRP.Services.WaterTankCalculator.BLL.Interfaces;
using GRP.Services.WaterTankCalculator.BLL.Managers;
using GRP.Services.WaterTankCalculator.BLL.Models;
using GRP.Services.WaterTankCalculator.BLL.Seeding;
using GRP.Services.WaterTankCalculator.BLL.Settings;
using GRP.Services.WaterTankCalculator.DAL.Concrete.EntityFrameworkCore.Contexts;
using GRP.Services.WaterTankCalculator.Entities.Concrete;
using GRP.Shared.BLL.Interfaces;
using GRP.Shared.BLL.Managers;
using GRP.Shared.Core.ExtensionMethods;
using GRP.Shared.Core.Services;
using GRP.Shared.Core.Services.Interfaces;
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
        string migrationName = "GRP.Services.WaterTankCalculator";

        services.AddTransient<DbContext, WaterTankCalculatorDbContext>();

        services.AddDbContext<WaterTankCalculatorDbContext>(opt =>
            opt.UseSqlServer(connectionString, sqlOpt =>
                sqlOpt.MigrationsAssembly(migrationName)
                )
        );

        services.AddHttpContextAccessor();

        #region Repositoryies
        services.AddTransient(typeof(IGenericCommandRepository<>), typeof(EfGenericCommandRepository<>));
        services.AddTransient(typeof(IGenericQueryRepository<>), typeof(EfGenericQueryRepository<>));
        #endregion
        #region Services
        services.AddTransient(typeof(IGenericQueryService<>), typeof(GenericQueryManager<>));
        services.AddTransient(typeof(IGenericCommandService<>), typeof(GenericCommandManager<>));

        services.AddScoped<IEdgeService, EdgeManager>();

        services.AddScoped<IFlatModuleService, FlatModuleManager>();
        services.AddScoped<IBeamModuleService, BeamModuleManager>();

        services.AddScoped<IFlatProductService, FlatProductManager>();
        services.AddScoped<IBeamProductService, BeamProductManager>();

        services.AddScoped<IFlatRATService, FlatRATManager>();
        services.AddScoped<IBeamRATService, BeamRATManager>();

        services.AddScoped<ITotalCostService, TotalCostManager>();

        services.AddScoped<IGenericDefaultService, GenericDefaultManager>();

        services.AddScoped<DefaultRecords>();
        services.AddScoped<DefaultsSeeder>();

        services.AddScoped<ICalculateService, CalculateManager>();
        services.AddScoped<ITransportationService, TransportationManager>();
        services.AddScoped<IHistoryService, HistoryManager>();

        services.AddScoped<ISharedIdentityService, SharedIdentityService>();

        #endregion


        

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<ICustomMapper, CustomMapper>();

        services.AddSetting<ModuleGroup>(configuration, "ModuleGroup");
        services.AddSetting<ProductGroup>(configuration, "Products");
        services.AddSetting<RATGroup>(configuration, "rats");
        services.AddSetting<ConstantsSetting>(configuration, "constants");

        services.AddHttpClient<IExchangeService, ExcahangeManager>(conf => conf.BaseAddress = new Uri("https://api.genelpara.com/embed/doviz.json"));
    }

    public static void AddValidationDependencies(this IMvcBuilder mvcBuilder)
    {
        mvcBuilder.AddFluentValidation(opt => { }
        //opt.RegisterValidatorsFromAssemblyContaining<ValidationLayer>()
        );
    }
}
