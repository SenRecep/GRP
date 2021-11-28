using GRP.Services.Company.Models;
using GRP.Services.Company.Settings;
using GRP.Shared.Core.StringInfo;

namespace GRP.Services.Company.Seeding;

public class Defaults
{
    private readonly IServiceProvider serviceProvider;

    public Defaults(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public IEnumerable<Models.Company> GetData()
    {
        var data = serviceProvider.GetRequiredService<CompanySetting>();
        var userId = Guid.Parse(SystemUserInfo.SystemUserId);
        return data
            .Companies
            .Select(x =>
            {
                x.CreatedUserId= userId;
                return x;
            });
    }
}
