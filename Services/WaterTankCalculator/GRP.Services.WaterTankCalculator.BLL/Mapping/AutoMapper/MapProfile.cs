using AutoMapper;

using GRP.Services.WaterTankCalculator.BLL.Models;
using GRP.Services.WaterTankCalculator.BLL.Models.DTO;
using GRP.Services.WaterTankCalculator.Entities.Concrete;
using GRP.Services.WaterTankCalculator.Entities.Concrete.Defaults;
using GRP.Services.WaterTankCalculator.Entities.Concrete.History;

namespace GRP.Services.WaterTankCalculator.BLL.Mapping.AutoMapper;

public class MapProfile:Profile
{
    public MapProfile()
    {
        CreateMap<ProductDefault,Product>().ReverseMap();
        CreateMap<ModuleDefault,Module>().ReverseMap();
        CreateMap<RATDefault,RAT>().ReverseMap();


        CreateMap<RATDefault,RATDto>().ReverseMap();
        CreateMap<ProductDefault,ProductDto>().ReverseMap();
        CreateMap<Constants, ConstantsDto>().ReverseMap();
        CreateMap<ModuleDefault, ModuleDto>().ReverseMap();

        CreateMap<TotalCost, TotalCostHistory>().ReverseMap();
        CreateMap<CalculateModel, CalculateModelHistory>().ReverseMap();
        CreateMap<ConstantsModel, ConstantsHistory>().ReverseMap();
        CreateMap<Product, ProductHistory>().ReverseMap();
        CreateMap<Module, ModuleHistory>().ReverseMap();
        CreateMap<RAT, RATHistory>().ReverseMap();




    }
}
