using GRP.Services.WaterTankCalculator.Entities.Concrete.Defaults;
using GRP.Shared.DAL.Concrete.EntityFrameworkCore.Mapping.ExtensionMethods;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GRP.Services.WaterTankCalculator.DAL.Concrete.EntityFrameworkCore.Mapping;

public class ProductDefaultMap : IEntityTypeConfiguration<ProductDefault>
{
    public void Configure(EntityTypeBuilder<ProductDefault> builder)
    {
        builder.EntityBaseMap();
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.UnitPrice).IsRequired();
        builder.Property(x => x.Quantity).IsRequired();
        builder.Property(x => x.Key).IsRequired();
    }
}
