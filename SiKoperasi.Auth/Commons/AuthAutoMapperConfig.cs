using AutoMapper;
using SiKoperasi.Auth.Dto;
using SiKoperasi.Auth.Models;

namespace SiKoperasi.Auth.Commons
{
    public class AuthAutoMapperConfig : Profile
    {
        public AuthAutoMapperConfig()
        {
            CreateMap<RoleDto, Role>().ReverseMap();
            CreateMap<RoleCreateDto, Role>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<UserCreateDto, User>().ReverseMap();
        }
    }
}
