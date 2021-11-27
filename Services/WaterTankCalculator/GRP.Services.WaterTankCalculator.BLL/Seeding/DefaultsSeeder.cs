using GRP.Services.WaterTankCalculator.DAL.Concrete.EntityFrameworkCore.Contexts;

namespace GRP.Services.WaterTankCalculator.BLL.Seeding;

public class DefaultsSeeder
{
    private readonly WaterTankCalculatorDbContext context;
    private readonly DefaultRecords defaultRecords;

    public DefaultsSeeder(
        WaterTankCalculatorDbContext waterTankCalculatorDbContext,
        DefaultRecords defaultRecords)
    {
        this.context = waterTankCalculatorDbContext;
        this.defaultRecords = defaultRecords;
    }
    public async Task SeedAsync()
    {
        var defaultProducts = defaultRecords.GetProducts();
        var defaultModules = defaultRecords.GetModules();
        var defaultRATs = defaultRecords.GetRATs();
        if (!context.ProductDefaults.Any())
            await context.AddRangeAsync(defaultProducts);

        if (!context.ModuleDefaults.Any())
            await context.AddRangeAsync(defaultModules);

        if (!context.RATDefaults.Any())
            await context.AddRangeAsync(defaultRATs);

        if (!context.Constants.Any())
            await context.AddRangeAsync(defaultRecords.GetConstants());

        await context.SaveChangesAsync();
    }
}
