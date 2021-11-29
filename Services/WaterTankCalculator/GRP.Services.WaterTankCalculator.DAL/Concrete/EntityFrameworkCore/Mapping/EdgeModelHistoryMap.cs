using GRP.Services.WaterTankCalculator.Entities.Concrete.History;
using GRP.Shared.DAL.Concrete.EntityFrameworkCore.Mapping.ExtensionMethods;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GRP.Services.WaterTankCalculator.DAL.Concrete.EntityFrameworkCore.Mapping;

public class EdgeModelHistoryMap : IEntityTypeConfiguration<EdgeModelHistory>
{
    public void Configure(EntityTypeBuilder<EdgeModelHistory> builder)
    {
        builder.EntityBaseMap();
        builder.Property(x=>x.Capacity).IsRequired();
        builder.Property(x=>x.Edge_Bottom).IsRequired();
        builder.Property(x=>x.Edge_Side).IsRequired();
        builder.Property(x=>x.Edge_Top).IsRequired();
        builder.Property(x=>x.Interior_Bottom).IsRequired();
        builder.Property(x=>x.Interior_Side).IsRequired();
        builder.Property(x=>x.Interior_Top).IsRequired();
        builder.Property(x=>x.Outside_Bottom).IsRequired();
        builder.Property(x=>x.Outside_Side).IsRequired();
        builder.Property(x=>x.Outside_Top).IsRequired();
    }
}
