
using AutoMapper;

using GRP.IdentityServer.Dtos;
using GRP.IdentityServer.Models;

namespace GRP.IdentityServer.Mapping.AutoMapper
{
    public class ApplicationUserMapProfile : Profile
    {
        public ApplicationUserMapProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserDto>().ReverseMap();
            CreateMap<ApplicationUser, SignUpViewModel>().ReverseMap();
        }
    }
}
