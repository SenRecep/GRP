#nullable disable
using GRP.Core.Concrete;

namespace GRP.Services.WaterTankCalculator.Entities.Concrete.History;

public class ConstantsHistory : EntityBase
{
    public float GRPKgPrice { get; set; }
    public float Dollar { get; set; }
    public float Transportation { get; set; }


    public Guid? CalculationHistoryId { get; set; }
    public CalculationHistory CalculationHistory { get; set; }
}
