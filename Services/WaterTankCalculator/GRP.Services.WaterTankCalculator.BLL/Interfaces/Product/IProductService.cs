using GRP.Services.WaterTankCalculator.BLL.Models;

namespace GRP.Services.WaterTankCalculator.BLL.Interfaces;

public interface IProductService
{
    ProductGroup ProductsCalculate(ProductGroup productGroup,CalculateModel calculateModel,CalculatedEdgeModel calculatedEdgeModel,ModuleGroup moduleGroup,ConstantsModel constants,RATGroup ratGroup);
}
