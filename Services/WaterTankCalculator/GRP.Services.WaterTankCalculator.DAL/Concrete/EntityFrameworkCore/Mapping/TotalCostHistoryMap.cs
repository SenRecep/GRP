using GRP.Services.WaterTankCalculator.Entities.Concrete.History;
using GRP.Shared.DAL.Concrete.EntityFrameworkCore.Mapping.ExtensionMethods;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GRP.Services.WaterTankCalculator.DAL.Concrete.EntityFrameworkCore.Mapping;

public class TotalCostHistoryMap : IEntityTypeConfiguration<TotalCostHistory>
{
    public void Configure(EntityTypeBuilder<TotalCostHistory> builder)
    {
        builder.EntityBaseMap();
        builder.Property(x => x.Subtotal).IsRequired();
        builder.Property(x => x.Financing).IsRequired();
        builder.Property(x => x.GoesInvisible).IsRequired();
        builder.Property(x => x.GrandTotal).IsRequired();
        builder.Property(x => x.Total).IsRequired();
        builder.Property(x => x.FullTotal).IsRequired();
    }
}
