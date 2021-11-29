using GRP.Services.WaterTankCalculator.BLL.Models;

namespace GRP.Services.WaterTankCalculator.BLL.Interfaces
{
    public interface IHistoryService
    {
        Task SaveAsync(MultipleCalculateModel model, ICollection<CalculateResponse> calculateResponses);
    }
}
