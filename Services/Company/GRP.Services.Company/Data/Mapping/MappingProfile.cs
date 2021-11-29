using AutoMapper;

using GRP.Services.Company.Models.DTO;

namespace GRP.Services.Company.Data.Mapping;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<Models.Company, ListDto>().ReverseMap();
        CreateMap<Models.Company, DeleteDto>().ReverseMap();
        CreateMap<Models.Company, CreateDto>().ReverseMap();
        CreateMap<Models.Company, UpdateDto>().ReverseMap();
    }
}
