using GRP.Services.WaterTankCalculator.BLL.Interfaces;
using GRP.Services.WaterTankCalculator.BLL.Models;
using GRP.Shared.Core.ExtensionMethods;

namespace GRP.Services.WaterTankCalculator.BLL.Managers;

public abstract class ProductManager : IProductService
{
    public ProductGroup ProductsCalculate(
        ProductGroup productGroup,
        CalculateModel calculateModel,
        CalculatedEdgeModel calculatedEdgeModel,
        ModuleGroup moduleGroup,
        ConstantsModel constants,
        RATGroup ratGroup)
    {
        FM(productGroup.FM, moduleGroup, constants);
        MM(productGroup.MM, moduleGroup, constants);
        C360(productGroup.C360, calculateModel, moduleGroup, constants);
        M1045GC(productGroup.M1045GC, calculatedEdgeModel, constants);
        M1045KC(productGroup.M1045KC, calculatedEdgeModel, constants);
        M1045GS(productGroup.M1045GS, productGroup.M1045GC, productGroup.M1045KC, constants);
        M1045GP(productGroup.M1045GP, calculatedEdgeModel, productGroup.M1045KC, constants);
        M1045PC(productGroup.M1045PC, calculatedEdgeModel, constants);
        M10PS(productGroup.M10PS, productGroup.M1045PC, constants);
        M10PP(productGroup.M10PP, productGroup.M1045PC, constants);
        M12120PGS(productGroup.M12120PGS, constants, ratGroup);
        M12GS(productGroup.M12GS, productGroup.M12120PGS, constants);
        M12GGP(productGroup.M12GGP, productGroup.M12120PGS, constants);
        M12US(productGroup.M12US, calculateModel, constants);
        M12PS(productGroup.M12PS, constants, ratGroup);
        DBS(productGroup.DBS, calculatedEdgeModel.Capacity, constants);
        G502(productGroup.G502, productGroup.DBS, constants);
        DBRP(productGroup.DBRP, constants);
        DBRPVC(productGroup.DBRPVC, constants);
        SGM(productGroup.SGM, constants);
        DMG(productGroup.DMG, constants);
        DMP(productGroup.DMP, constants);
        IM(productGroup.IM, calculateModel, constants);
        PPRCD(productGroup.PPRCD, calculatedEdgeModel, calculateModel, constants);
        PK(productGroup.PK, calculateModel, constants);
        productGroup.GetType().GetProperties().ToList().ForEach(x =>
        {
            if (x.PropertyType != typeof(Product)) return;
            var module = x.GetValue(productGroup).Cast<Product>();
            if (module == null) return;
            if (x.Name is not (nameof(ProductGroup.FM) or nameof(ProductGroup.MM)))
                CostCalculate(module,constants);
            productGroup.TotalCost += module.Cost;
        });
        return productGroup;
    }
    protected virtual Product CostCalculate(Product product, ConstantsModel constants)
    {
        product.Cost = product.UnitPrice * product.Quantity / constants.Dollar;
        return product;
    }
    protected virtual Product FM(Product product, ModuleGroup moduleGroup, ConstantsModel constants)
    {
        var total = moduleGroup.Modules().Sum(x => x.TotalOrders);
        product.Cost = product.UnitPrice * total / constants.Dollar;
        return product;
    }
    protected virtual Product MM(Product product, ModuleGroup moduleGroup, ConstantsModel constants)
    {
        var total = moduleGroup.Modules().Sum(x => x.TotalOrders);
        product.Cost = product.UnitPrice * total / constants.Dollar;
        return product;
    }
    protected abstract Product C360(Product product, CalculateModel calculateModel, ModuleGroup moduleGroup, ConstantsModel constants);
    protected abstract Product M1045GC(Product product, CalculatedEdgeModel calculatedEdgeModel, ConstantsModel constants);
    protected abstract Product M1045GS(Product product, Product M1045GC, Product M1045KC, ConstantsModel constants);
    protected abstract Product M1045GP(Product product, CalculatedEdgeModel calculatedEdgeModel, Product M1045KC, ConstantsModel constants);
    protected abstract Product M1045PC(Product product, CalculatedEdgeModel calculatedEdgeModel, ConstantsModel constants);
    protected abstract Product M10PS(Product product, Product M1045PC, ConstantsModel constants);
    protected abstract Product M10PP(Product product, Product M1045PC, ConstantsModel constants);
    protected abstract Product M1045KC(Product product, CalculatedEdgeModel calculatedEdgeModel, ConstantsModel constants);
    protected abstract Product M12120PGS(Product product, ConstantsModel constants, RATGroup ratGroup);
    protected abstract Product M12GS(Product product, Product M12120PGS, ConstantsModel constants);
    protected abstract Product M12GGP(Product product, Product M12120PGS, ConstantsModel constants);
    protected abstract Product M12US(Product product, CalculateModel calculateModel, ConstantsModel constants);
    protected abstract Product M12PS(Product product, ConstantsModel constants, RATGroup ratGroup);
    protected abstract Product DBS(Product product, Capacity capacity, ConstantsModel constants);
    protected abstract Product G502(Product product, Product DBS, ConstantsModel constants);
    protected abstract Product DBRP(Product product, ConstantsModel constants);
    protected abstract Product DBRPVC(Product product, ConstantsModel constants);
    protected abstract Product SGM(Product product, ConstantsModel constants);
    protected abstract Product DMG(Product product, ConstantsModel constants);
    protected abstract Product DMP(Product product, ConstantsModel constants);
    protected abstract Product IM(Product product, CalculateModel calculateModel, ConstantsModel constants);
    protected abstract Product PPRCD(Product product, CalculatedEdgeModel calculatedEdgeModel, CalculateModel calculateModel, ConstantsModel constants);
    protected abstract Product PK(Product product, CalculateModel calculateModel, ConstantsModel constants);
}
