using Microsoft.EntityFrameworkCore;

namespace GRP.Services.Company.Data
{
    public class CompanyDbContext:DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CompanyDbContext).Assembly);
        }

        public DbSet<Constants> Constants { get; set; }
    }
}
