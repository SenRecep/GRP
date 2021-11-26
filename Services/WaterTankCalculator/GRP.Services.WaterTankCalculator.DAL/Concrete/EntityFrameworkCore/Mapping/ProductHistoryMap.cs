using GRP.Services.WaterTankCalculator.Entities.Concrete.History;
using GRP.Shared.DAL.Concrete.EntityFrameworkCore.Mapping.ExtensionMethods;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GRP.Services.WaterTankCalculator.DAL.Concrete.EntityFrameworkCore.Mapping;

public class ProductHistoryMap : IEntityTypeConfiguration<ProductHistory>
{
    public void Configure(EntityTypeBuilder<ProductHistory> builder)
    {
        builder.EntityBaseMap();
        builder.Property(x => x.Cost).IsRequired();
        builder.Property(x => x.Quantity).IsRequired();

        builder.HasOne(x => x.ProductDefault)
            .WithMany(x => x.ProductHistories)
            .HasForeignKey(x => x.ProductDefaultKey)
            .HasPrincipalKey(x => x.Key)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
