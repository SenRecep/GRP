using GRP.Services.WaterTankCalculator.BLL.Models;
using GRP.Services.WaterTankCalculator.BLL.Models.DTO;

namespace GRP.Services.WaterTankCalculator.BLL.Interfaces
{
    public interface IDefaultService
    {
        Task<IEnumerable<ProductDto>> GetDefaultsProducts();
        Task<IEnumerable<RATDto>> GetDefaultsRAT();
        Task<ConstantsDto> GetDefaultsConstant();
        Task<IEnumerable<ModuleDto>> GetDefaultsModules();
    }
}
