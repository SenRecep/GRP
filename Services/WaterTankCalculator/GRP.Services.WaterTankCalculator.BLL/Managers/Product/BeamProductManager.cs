using GRP.Services.WaterTankCalculator.BLL.Interfaces;
using GRP.Services.WaterTankCalculator.BLL.Models;

namespace GRP.Services.WaterTankCalculator.BLL.Managers;

public class BeamProductManager : ProductManager, IBeamProductService
{
    protected override Product C360(Product product, CalculateModel calculateModel, ModuleGroup moduleGroup, Constants constants)
    {
        var constant = moduleGroup.ADTT.TotalOrders * 4.1f / 2 + calculateModel.Height * 4 * 2;
        var sum_YIC = (moduleGroup.YIC21.TotalOrders + moduleGroup.YIC25.TotalOrders + moduleGroup.YIC22.TotalOrders + moduleGroup.YIC28.TotalOrders + moduleGroup.YIC13.TotalOrders);
        product.Quantity = calculateModel.Height switch
        {
            3 => moduleGroup.YIC21.TotalOrders * 3.2f + moduleGroup.YIC25.TotalOrders * 4.2f + (moduleGroup.YIC13.TotalOrders - calculateModel.Width) * 3.1f + moduleGroup.ATB.TotalOrders * 4.1f + calculateModel.Height * 8,
            1 or 1.5f or 2 => sum_YIC * 4.2f + constant,
            2.5f => (sum_YIC - moduleGroup.YIC21.TotalOrders) * 4.2f + constant,
            _ => moduleGroup.YIC25.TotalOrders * 11.6f + constant
        };
        product.Quantity *= calculateModel.Height switch
        {
            not 3 => 1.01f,
            _ => 1
        };
        
        return product;
    }
    protected override Product M1045GC(Product product, CalculatedEdgeModel calculatedEdgeModel, Constants constants)
    {
        product.Quantity = (
            (calculatedEdgeModel.Outside.Side + calculatedEdgeModel.Interior.Side + calculatedEdgeModel.Interior.Bottom + calculatedEdgeModel.Outside.Bottom) * 2 +
            calculatedEdgeModel.Outside.Top + calculatedEdgeModel.Interior.Top) * 4 * 1.01f;
        
        return product;
    }
    protected override Product M1045GS(Product product, Product M1045GC, Product M1045KC, Constants constants)
    {
        product.Quantity = M1045GC.Quantity + 4;
        
        return product;
    }
    protected override Product M1045GP(Product product, CalculatedEdgeModel calculatedEdgeModel, Product M1045KC, Constants constants)
    {
        product.Quantity = (
            (calculatedEdgeModel.Outside.Side + calculatedEdgeModel.Interior.Side * 2 + calculatedEdgeModel.Interior.Bottom * 2 + calculatedEdgeModel.Outside.Bottom) * 8 + M1045KC.Quantity) * 1.01f;
        
        return product;
    }
    protected override Product M1045PC(Product product, CalculatedEdgeModel calculatedEdgeModel, Constants constants)
    {
        product.Quantity = 0;
        
        return product;
    }
    protected override Product M10PS(Product product, Product M1045PC, Constants constants)
    {
        product.Quantity = 0;
        
        return product;
    }
    protected override Product M10PP(Product product, Product M1045PC, Constants constants)
    {
        product.Quantity = 0;
        
        return product;
    }
    protected override Product M1045KC(Product product, CalculatedEdgeModel calculatedEdgeModel, Constants constants)
    {
        product.Quantity = 0;
        
        return product;
    }
    protected override Product M12120PGS(Product product, Constants constants, RATGroup ratGroup)
    {
        product.Quantity = ratGroup.DGKG.Quantity * 2;
        
        return product;
    }
    protected override Product M12GS(Product product, Product M12120PGS, Constants constants)
    {
        product.Quantity = M12120PGS.Quantity * 2;
        
        return product;
    }
    protected override Product M12GGP(Product product, Product M12120PGS, Constants constants)
    {
        product.Quantity = M12120PGS.Quantity;
        
        return product;
    }
    protected override Product M12US(Product product, CalculateModel calculateModel, Constants constants)
    {
        product.Quantity = calculateModel switch
        {
            { Width: var w } when w > 4 => MathF.Floor(calculateModel.Length - 1) + MathF.Floor(calculateModel.Width - 1),
            { Length: var w } when w > 4 => MathF.Floor(calculateModel.Width - 1),
            _ => 0
        };
        
        return product;
    }
    protected override Product M12PS(Product product, Constants constants, RATGroup ratGroup)
    {
        product.Quantity = ratGroup.IGK.Quantity * 2;
        return product;
    }
    protected override Product DBS(Product product, Capacity capacity, Constants constants)
    {
        product.Quantity = capacity.Value < 12 ? 1 : MathF.Ceiling(capacity.Value / 10);
        
        return product;
    }
    protected override Product G502(Product product, Product DBS, Constants constants)
    {
        product.Quantity = MathF.Ceiling(DBS.Quantity * 5.1f);
        
        return product;
    }
    protected override Product DBRP(Product product, Constants constants)
    {
        
        return product;
    }
    protected override Product DBRPVC(Product product, Constants constants)
    {
        
        return product;
    }
    protected override Product SGM(Product product, Constants constants)
    {
        
        return product;
    }
    protected override Product DMG(Product product, Constants constants)
    {
        
        return product;
    }
    protected override Product DMP(Product product, Constants constants)
    {
        
        return product;
    }
    protected override Product IM(Product product, CalculateModel calculateModel, Constants constants)
    {
        product.Quantity = calculateModel.Height > 1 ? 1 : 0;
        
        return product;
    }
    protected override Product PPRCD(Product product, CalculatedEdgeModel calculatedEdgeModel, CalculateModel calculateModel, Constants constants)
    {
        product.Quantity = calculatedEdgeModel.Capacity.Value <= 12 ? 0 : (calculateModel.Width - 1) * (calculateModel.Length - 1);
        return product;
    }
    protected override Product PK(Product product, CalculateModel calculateModel, Constants constants)
    {
        product.Quantity = calculateModel.Width * (calculateModel.Length + 1) + calculateModel.Length * (calculateModel.Width + 1);
        product.UnitPrice = 60;
        return product;
    }
}
