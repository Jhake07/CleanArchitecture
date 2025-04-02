using AutoMapper;
using CleanArchitectureSystem.Application.Features.AppUser.Queries.AppUser;
using CleanArchitectureSystem.Domain;

namespace CleanArchitectureSystem.Application.MappingProfiles
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            CreateMap<AppUserDto, AppUser>().ReverseMap();
        }
    }
}
