using GRP.Services.WaterTankCalculator.Entities.Concrete.History;
using GRP.Shared.DAL.Concrete.EntityFrameworkCore.Mapping.ExtensionMethods;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GRP.Services.WaterTankCalculator.DAL.Concrete.EntityFrameworkCore.Mapping;

public class ConstantsHistoryMap : IEntityTypeConfiguration<ConstantsHistory>
{
    public void Configure(EntityTypeBuilder<ConstantsHistory> builder)
    {
        builder.EntityBaseMap();
        builder.Property(x=>x.GRPKgPrice).IsRequired();
        builder.Property(x=>x.Transportation).IsRequired();
        builder.Property(x=>x.Dollar).IsRequired();
    }
}
