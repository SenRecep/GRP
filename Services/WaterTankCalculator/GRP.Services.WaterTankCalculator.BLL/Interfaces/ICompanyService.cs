using GRP.Services.WaterTankCalculator.BLL.Models;

namespace GRP.Services.WaterTankCalculator.BLL.Interfaces;

public interface ICompanyService
{
    Task<Company> GetByIdAsync(Guid id);
    Task<IEnumerable<Company>> GetCompanies();
}
