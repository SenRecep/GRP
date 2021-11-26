using GRP.Services.WaterTankCalculator.Entities.Concrete.Defaults;
using GRP.Shared.DAL.Concrete.EntityFrameworkCore.Mapping.ExtensionMethods;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GRP.Services.WaterTankCalculator.DAL.Concrete.EntityFrameworkCore.Mapping;

public class ModuleDefaultMap : IEntityTypeConfiguration<ModuleDefault>
{
    public void Configure(EntityTypeBuilder<ModuleDefault> builder)
    {
        builder.EntityBaseMap();
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Dimensions).IsRequired();
        builder.Property(x => x.Key).IsRequired();
        builder.Property(x => x.Weight).IsRequired();
        builder.Property(x => x.Type).IsRequired();
        builder.Property(x => x.TotalOrders).IsRequired();
        builder.HasAlternateKey(x =>x.Key);
    }
}
