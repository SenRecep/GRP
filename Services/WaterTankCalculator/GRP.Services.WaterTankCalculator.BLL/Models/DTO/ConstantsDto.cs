using GRP.Core.Interfaces;

namespace GRP.Services.WaterTankCalculator.BLL.Models.DTO;

public class ConstantsDto:IDTO
{
    public Guid Id { get; set; }
    public float GRPKgPrice { get; set; }
    public float Transportation { get; set; }
}
