using GRP.Services.WaterTankCalculator.Entities.Concrete.History;
using GRP.Shared.DAL.Concrete.EntityFrameworkCore.Mapping.ExtensionMethods;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GRP.Services.WaterTankCalculator.DAL.Concrete.EntityFrameworkCore.Mapping;

public class CalculationHistoryMap : IEntityTypeConfiguration<CalculationHistory>
{
    public void Configure(EntityTypeBuilder<CalculationHistory> builder)
    {
        builder.EntityBaseMap();

        builder.Property(x=>x.ConstantsHistoryId).IsRequired(false);
        builder.Property(x=>x.ModuleHistoryId).IsRequired(false);
        builder.Property(x=>x.ProductHistoryId).IsRequired(false);
        builder.Property(x=>x.RATHistoryId).IsRequired(false);
        builder.Property(x=>x.TotalCostHistoryId).IsRequired(false);
        builder.Property(x=>x.CalculateModelHistories).IsRequired(false);

        builder.HasOne(x=>x.ConstantsHistory)
            .WithOne(x=>x.CalculationHistory)
            .HasForeignKey<CalculationHistory>(x=>x.ConstantsHistoryId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.ModuleHistory)
            .WithOne(x => x.CalculationHistory)
            .HasForeignKey<CalculationHistory>(x => x.ConstantsHistoryId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.ProductHistory)
            .WithOne(x => x.CalculationHistory)
            .HasForeignKey<CalculationHistory>(x => x.ConstantsHistoryId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.RATHistory)
            .WithOne(x => x.CalculationHistory)
            .HasForeignKey<CalculationHistory>(x => x.ConstantsHistoryId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.TotalCostHistory)
            .WithOne(x => x.CalculationHistory)
            .HasForeignKey<CalculationHistory>(x => x.ConstantsHistoryId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(x => x.CalculateModelHistories)
            .WithOne(x => x.CalculationHistory)
            .HasForeignKey(x => x.CalculationHistoryId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
