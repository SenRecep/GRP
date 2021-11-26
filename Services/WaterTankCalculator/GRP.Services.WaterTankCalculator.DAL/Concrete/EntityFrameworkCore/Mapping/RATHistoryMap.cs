using GRP.Services.WaterTankCalculator.Entities.Concrete.History;
using GRP.Shared.DAL.Concrete.EntityFrameworkCore.Mapping.ExtensionMethods;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GRP.Services.WaterTankCalculator.DAL.Concrete.EntityFrameworkCore.Mapping;

public class RATHistoryMap : IEntityTypeConfiguration<RATHistory>
{
    public void Configure(EntityTypeBuilder<RATHistory> builder)
    {
        builder.EntityBaseMap();
        builder.Property(x => x.Cost).IsRequired();
        builder.Property(x => x.Quantity).IsRequired();

        builder.HasOne(x => x.RATDefault)
            .WithMany(x => x.RATHistories)
            .HasForeignKey(x=>x.RATDefaultKey)
            .HasPrincipalKey(x => x.Key)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
