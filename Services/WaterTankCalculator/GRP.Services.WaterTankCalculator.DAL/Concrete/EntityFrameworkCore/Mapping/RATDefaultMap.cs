using GRP.Services.WaterTankCalculator.Entities.Concrete.Defaults;
using GRP.Shared.DAL.Concrete.EntityFrameworkCore.Mapping.ExtensionMethods;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GRP.Services.WaterTankCalculator.DAL.Concrete.EntityFrameworkCore.Mapping;

public class RATDefaultMap : IEntityTypeConfiguration<RATDefault>
{
    public void Configure(EntityTypeBuilder<RATDefault> builder)
    {
        builder.EntityBaseMap();
        builder.Property(x => x.Key).IsRequired();
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Weight).IsRequired();
        builder.Property(x => x.DKPS).IsRequired();
        builder.Property(x => x.LC).IsRequired();
        builder.Property(x => x.DIP).IsRequired();
        builder.Property(x => x.RUB).IsRequired();
        builder.Property(x => x.Quantity).IsRequired();
    }
}
