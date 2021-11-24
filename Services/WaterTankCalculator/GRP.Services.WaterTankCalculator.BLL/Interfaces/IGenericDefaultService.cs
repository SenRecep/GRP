using GRP.Core.Interfaces;
using GRP.Services.WaterTankCalculator.Entities.Interfaces.Defaults;

namespace GRP.Services.WaterTankCalculator.BLL.Interfaces;

public interface IGenericDefaultService
{
    Task<T> GetGroupAsync<T, J, M>()
        where J : class, IEntityBase, IDefaultEntitiy, new()
        where M : class, new()
        where T : class, new();
}
