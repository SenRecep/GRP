using GRP.Shared.DAL.Concrete.EntityFrameworkCore.Mapping.ExtensionMethods;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GRP.Services.Company.Data.Mapping
{
    public class CompanyMap : IEntityTypeConfiguration<Models.Company>
    {
        public void Configure(EntityTypeBuilder<Models.Company> builder)
        {
            builder.EntityBaseMap();
            builder.Property(x=>x.Address).IsRequired(false);
            builder.Property(x=>x.AuthorizedPerson).IsRequired(false);
            builder.Property(x=>x.TaxAdministration).IsRequired(false);
            builder.Property(x=>x.Fax).IsRequired(false);
            builder.Property(x=>x.GSM).IsRequired(false);
            builder.Property(x=>x.Title).IsRequired(false);
            builder.Property(x=>x.Phone).IsRequired(false);
            builder.Property(x=>x.Mail).IsRequired(false);
            builder.Property(x=>x.TaxNumber).IsRequired(false);
        }
    }
}
