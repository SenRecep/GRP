using GRP.Services.WaterTankCalculator.Entities.Concrete.History;
using GRP.Shared.DAL.Concrete.EntityFrameworkCore.Mapping.ExtensionMethods;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GRP.Services.WaterTankCalculator.DAL.Concrete.EntityFrameworkCore.Mapping;

public class ModuleHistoryMap : IEntityTypeConfiguration<ModuleHistory>
{
    public void Configure(EntityTypeBuilder<ModuleHistory> builder)
    {
        builder.EntityBaseMap();
        builder.Property(x => x.Cost).IsRequired();
        builder.Property(x => x.TotalOrders).IsRequired();
        builder.Property(x => x.TotalWeight).IsRequired();

        builder.HasOne(x => x.ModuleDefault)
            .WithMany(x => x.ModuleHistories)
            .HasForeignKey(x => x.ModuleDefaultKey)
            .HasPrincipalKey(x=>x.Key)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
