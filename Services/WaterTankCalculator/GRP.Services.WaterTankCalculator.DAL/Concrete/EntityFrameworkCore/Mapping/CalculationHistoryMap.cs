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

        builder.Property(x=>x.CompnyId).IsRequired();
        builder.Property(x=>x.Total).IsRequired();
        builder.Property(x=>x.PaymentType).IsRequired();
        builder.Property(x=>x.KDV).IsRequired();
        builder.Property(x=>x.FullTotal).IsRequired();

        builder.HasOne(x=>x.ConstantsHistory)
            .WithOne(x=>x.CalculationHistory)
            .HasForeignKey<CalculationHistory>(x=>x.ConstantsHistoryId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(x => x.CalculateModelHistories)
            .WithOne(x => x.CalculationHistory)
            .HasForeignKey(x => x.CalculationHistoryId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
