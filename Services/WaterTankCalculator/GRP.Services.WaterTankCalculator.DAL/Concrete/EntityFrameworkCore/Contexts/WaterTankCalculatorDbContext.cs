#nullable disable
using GRP.Services.WaterTankCalculator.DAL.Concrete.EntityFrameworkCore.Mapping;
using GRP.Services.WaterTankCalculator.Entities.Concrete.Defaults;

using Microsoft.EntityFrameworkCore;

namespace GRP.Services.WaterTankCalculator.DAL.Concrete.EntityFrameworkCore.Contexts;

public class WaterTankCalculatorDbContext:DbContext
{
    public WaterTankCalculatorDbContext(DbContextOptions<WaterTankCalculatorDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductDefaultMap).Assembly);
    }

    public DbSet<ProductDefault> ProductDefaults { get; set; }
    public DbSet<ModuleDefault> ModuleDefaults { get; set; }
    public DbSet<RATDefault> RATDefaults { get; set; }
}
