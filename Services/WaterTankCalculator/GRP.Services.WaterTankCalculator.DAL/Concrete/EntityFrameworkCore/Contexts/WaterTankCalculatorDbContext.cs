#nullable disable
using GRP.Services.WaterTankCalculator.DAL.Concrete.EntityFrameworkCore.Mapping;
using GRP.Services.WaterTankCalculator.Entities.Concrete;
using GRP.Services.WaterTankCalculator.Entities.Concrete.Defaults;
using GRP.Services.WaterTankCalculator.Entities.Concrete.History;

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

    public DbSet<Constants> Constants { get; set; }
    public DbSet<ProductDefault> ProductDefaults { get; set; }
    public DbSet<ModuleDefault> ModuleDefaults { get; set; }
    public DbSet<RATDefault> RATDefaults { get; set; }
    public DbSet<ModuleHistory> ModuleHistories { get; set; }
    public DbSet<ProductHistory> ProductHistories { get; set; }
    public DbSet<RATHistory> RATHistories { get; set; }
    public DbSet<CalculationHistory> CalculationHistories { get; set; }
    public DbSet<TotalCostHistory> TotalCostHistories { get; set; }
}
