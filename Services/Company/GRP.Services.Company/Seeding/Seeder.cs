using GRP.Services.Company.Data;
using GRP.Shared.DAL.Interfaces;

namespace GRP.Services.Company.Seeding;

public class Seeder
{
    private readonly IGenericCommandRepository<Models.Company> repo;
    private readonly CompanyDbContext companyDbContext;
    private readonly Defaults defaults;

    public Seeder(IGenericCommandRepository<Models.Company> repo,CompanyDbContext companyDbContext, Defaults defaults)
    {
        this.repo = repo;
        this.companyDbContext = companyDbContext;
        this.defaults = defaults;
    }
    public async Task SeedAsync()
    {
        if (!companyDbContext.Companies.Any())
        {
            var data = defaults.GetData();
            await repo.AddRangeAsync(data);
            await repo.Commit();
        }
    }
}
