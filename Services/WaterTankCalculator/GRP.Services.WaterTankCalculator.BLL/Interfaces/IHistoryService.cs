using GRP.Services.WaterTankCalculator.BLL.Models;

namespace GRP.Services.WaterTankCalculator.BLL.Interfaces
{
    public interface IHistoryService
    {
        Task<Guid> SaveAsync(MultipleCalculateModel model,ConstantsModel constantsModel, ICollection<CalculateResponse> calculateResponses);
    }
}
