using GRP.Services.WaterTankCalculator.Entities.Concrete;
using GRP.Shared.DAL.Concrete.EntityFrameworkCore.Mapping.ExtensionMethods;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GRP.Services.WaterTankCalculator.DAL.Concrete.EntityFrameworkCore.Mapping;

public class ConstantsMap : IEntityTypeConfiguration<Constants>
{
    public void Configure(EntityTypeBuilder<Constants> builder)
    {
        builder.EntityBaseMap();
        builder.Property(x=>x.Transportation).IsRequired();
        builder.Property(x=>x.GRPKgPrice).IsRequired();
    }
}
