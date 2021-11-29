#nullable disable
using GRP.Services.WaterTankCalculator.Entities.Enums;

namespace GRP.Services.WaterTankCalculator.BLL.Models;

public record MultipleCalculateModel
{
    public IEnumerable<CalculateModel> CalculateModels { get; set; }
    public Guid? CompnyId { get; set; }
    public PaymentType PaymentType { get; set; }
}
