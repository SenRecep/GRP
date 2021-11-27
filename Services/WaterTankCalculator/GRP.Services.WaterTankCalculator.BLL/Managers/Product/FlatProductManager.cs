using GRP.Services.WaterTankCalculator.BLL.Interfaces;
using GRP.Services.WaterTankCalculator.BLL.Models;

namespace GRP.Services.WaterTankCalculator.BLL.Managers;

public class FlatProductManager:ProductManager,IFlatProductService
{
    protected override Product C360(Product product, CalculateModel calculateModel, ModuleGroup moduleGroup, ConstantsModel constants)
    {
        var constant = moduleGroup.ADTT.TotalOrders * 4.1f / 2 + calculateModel.Height * 4 * 2;
        var sum_YIC = (moduleGroup.YIC21.TotalOrders + moduleGroup.YIC25.TotalOrders + moduleGroup.YIC22.TotalOrders + moduleGroup.YIC28.TotalOrders + moduleGroup.YIC13.TotalOrders);
        product.Quantity = calculateModel.Height switch
        {
            3 => moduleGroup.YIC21.TotalOrders * 3.2f + moduleGroup.YIC25.TotalOrders * 4.2f + (moduleGroup.YIC13.TotalOrders - calculateModel.Width) * 3.1f + constant,
            1 or 1.5f or 2 => sum_YIC * 4.2f + constant,
            2.5f => ((sum_YIC - moduleGroup.YIC21.TotalOrders) * 4.2f + constant) * calculateModel.Height,
            _ => moduleGroup.YIC25.TotalOrders * 11.6f + constant
        };
        product.Quantity *= calculateModel.Height switch
        {
            not 3 => 1.01f,
            _ => 1
        };
        
        return product;
    }
    protected override Product M1045GC(Product product, CalculatedEdgeModel calculatedEdgeModel, ConstantsModel constants)
    {
        product.Quantity = (
            (calculatedEdgeModel.Outside.Side + calculatedEdgeModel.Interior.Side) * 2 +
            calculatedEdgeModel.Outside.Top + calculatedEdgeModel.Interior.Top) * 4 * 1.01f;
        
        return product;
    }
    protected override Product M1045GS(Product product, Product M1045GC, Product M1045KC, ConstantsModel constants)
    {
        product.Quantity = M1045GC.Quantity + M1045KC.Quantity + 4;
        
        return product;
    }
    protected override Product M1045GP(Product product, CalculatedEdgeModel calculatedEdgeModel, Product M1045KC, ConstantsModel constants)
    {
        product.Quantity = (
            (calculatedEdgeModel.Outside.Side + calculatedEdgeModel.Interior.Side * 2) * 8 + M1045KC.Quantity) * 1.01f;
        
        return product;
    }
    protected override Product M1045PC(Product product, CalculatedEdgeModel calculatedEdgeModel, ConstantsModel constants)
    {
        product.Quantity = calculatedEdgeModel.Interior.Bottom * 8;
        
        return product;
    }
    protected override Product M10PS(Product product, Product M1045PC, ConstantsModel constants)
    {
        product.Quantity = M1045PC.Quantity;
        
        return product;
    }
    protected override Product M10PP(Product product, Product M1045PC, ConstantsModel constants)
    {
        product.Quantity = M1045PC.Quantity * 2;
        
        return product;
    }
    protected override Product M1045KC(Product product, CalculatedEdgeModel calculatedEdgeModel, ConstantsModel constants)
    {
        product.Quantity = calculatedEdgeModel.Outside.Bottom * 8;
        
        return product;
    }
    protected override Product M12120PGS(Product product, ConstantsModel constants, RATGroup ratGroup)
    {
        product.Quantity = ratGroup.DGKG.Quantity * 2;
        
        return product;
    }
    protected override Product M12GS(Product product, Product M12120PGS, ConstantsModel constants)
    {
        product.Quantity = M12120PGS.Quantity * 2;
        
        return product;
    }
    protected override Product M12GGP(Product product, Product M12120PGS, ConstantsModel constants)
    {
        product.Quantity = M12120PGS.Quantity;
        
        return product;
    }
    protected override Product M12US(Product product, CalculateModel calculateModel, ConstantsModel constants)
    {
        product.Quantity = calculateModel switch
        {
            { Width: var w } when w > 4 => MathF.Floor(calculateModel.Length - 1) + MathF.Floor(calculateModel.Width - 1),
            { Length: var w } when w > 4 => MathF.Floor(calculateModel.Width - 1),
            _ => 0
        };
        
        return product;
    }
    protected override Product M12PS(Product product, ConstantsModel constants, RATGroup ratGroup)
    {
        product.Quantity = ratGroup.IGK.Quantity * 2;
        
        return product;
    }
    protected override Product DBS(Product product, Capacity capacity, ConstantsModel constants)
    {
        product.Quantity = capacity.Value < 12 ? 1 : MathF.Ceiling(capacity.Value / 10);
        
        return product;
    }
    protected override Product G502(Product product, Product DBS, ConstantsModel constants)
    {
        product.Quantity = DBS.Quantity * 4;
        
        return product;
    }
    protected override Product DBRP(Product product, ConstantsModel constants)
    {
        
        return product;
    }
    protected override Product DBRPVC(Product product, ConstantsModel constants)
    {
        
        return product;
    }
    protected override Product SGM(Product product, ConstantsModel constants)
    {
        
        return product;
    }
    protected override Product DMG(Product product, ConstantsModel constants)
    {
        
        return product;
    }
    protected override Product DMP(Product product, ConstantsModel constants)
    {
        
        return product;
    }
    protected override Product IM(Product product, CalculateModel calculateModel, ConstantsModel constants)
    {
        product.Quantity = calculateModel.Height > 1 ? 1 : 0;
        return product;
    }
    protected override Product PPRCD(Product product, CalculatedEdgeModel calculatedEdgeModel, CalculateModel calculateModel, ConstantsModel constants)
    {
        product.Quantity = calculatedEdgeModel.Capacity.Value <= 12 ? 0 : calculateModel.Width + calculateModel.Length - 2;
        return product;
    }
    protected override Product PK(Product product, CalculateModel calculateModel, ConstantsModel constants)
    {
        product.Quantity = calculateModel.Width * calculateModel.Length * 4;
        product.UnitPrice= 2.5f;
        return product;
    }
}
