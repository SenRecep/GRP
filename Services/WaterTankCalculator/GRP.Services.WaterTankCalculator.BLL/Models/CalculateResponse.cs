namespace GRP.Services.WaterTankCalculator.BLL.Models;

public record CalculateResponse(
    CalculateModel CalculateModel,
    TotalCost TotalCost,
    ModuleGroup ModuleGroup,
    ProductGroup ProductGroup,
    RATGroup RATGroup,
    CalculatedEdgeModel CalculatedEdgeModel);
