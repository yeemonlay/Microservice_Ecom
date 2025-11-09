using AutoMapper;
using Ecom.Services.AuthAPI.Models;
using Ecom.Shared.CommonService.Dtos;

namespace Ecom.Services.AuthAPI.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterUserDto, User>();
            CreateMap<User, UserDto>();
        }
    }
}
