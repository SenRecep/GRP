#nullable disable
namespace GRP.Services.WaterTankCalculator.BLL.Models;

public record MultipleCalculateModel
{
    public IEnumerable<CalculateModel> CalculateModels { get; set; }
    public Guid CompnyId { get; set; }
}
