using GRP.Services.WaterTankCalculator.Entities.Concrete.History;
using GRP.Shared.DAL.Concrete.EntityFrameworkCore.Mapping.ExtensionMethods;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GRP.Services.WaterTankCalculator.DAL.Concrete.EntityFrameworkCore.Mapping;

public class CalculateModelHistoryMap : IEntityTypeConfiguration<CalculateModelHistory>
{
    public void Configure(EntityTypeBuilder<CalculateModelHistory> builder)
    {
        builder.EntityBaseMap();
        builder.Property(x => x.Length).IsRequired();
        builder.Property(x => x.Width).IsRequired();
        builder.Property(x => x.Height).IsRequired();
        builder.Property(x => x.Quantity).IsRequired();
        builder.Property(x => x.PlinthType).IsRequired();

        builder.HasMany(x => x.ProductHistories)
            .WithOne(x => x.CalculateModelHistory)
            .HasForeignKey(x => x.CalculateModelHistoryId)
            .OnDelete(DeleteBehavior.NoAction);


        builder.HasMany(x => x.RATHistories)
           .WithOne(x => x.CalculateModelHistory)
           .HasForeignKey(x => x.CalculateModelHistoryId)
            .OnDelete(DeleteBehavior.NoAction);


        builder.HasMany(x => x.ModuleHistories)
           .WithOne(x => x.CalculateModelHistory)
           .HasForeignKey(x => x.CalculateModelHistoryId)
            .OnDelete(DeleteBehavior.NoAction);


        builder.HasOne(x => x.TotalCostHistory)
            .WithOne(x => x.CalculateModelHistory)
            .HasForeignKey<TotalCostHistory>(x => x.CalculateModelHistoryId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.EdgeModelHistory)
            .WithOne(x => x.CalculateModelHistory)
            .HasForeignKey<EdgeModelHistory>(x => x.CalculateModelHistoryId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
