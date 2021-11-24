using AutoMapper;

using GRP.Services.WaterTankCalculator.BLL.Models;
using GRP.Services.WaterTankCalculator.Entities.Concrete.Defaults;

namespace GRP.Services.WaterTankCalculator.BLL.Mapping.AutoMapper;

public class MapProfile:Profile
{
    public MapProfile()
    {
        CreateMap<ProductDefault,Product>().ReverseMap();
        CreateMap<ModuleDefault,Module>().ReverseMap();
        CreateMap<RATDefault,RAT>().ReverseMap();
    }
}
