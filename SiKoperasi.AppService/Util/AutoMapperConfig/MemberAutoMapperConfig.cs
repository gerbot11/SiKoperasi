using AutoMapper;
using SiKoperasi.AppService.Dto.Member;
using SiKoperasi.DataAccess.Models.Members;

namespace SiKoperasi.AppService.Util.AutoMapperConfig
{
    public class MemberAutoMapperConfig : Profile
    {
        public MemberAutoMapperConfig()
        {
            CreateMap<MemberDto, Member>().ReverseMap();
            CreateMap<MemberCreateDto, Member>().ReverseMap();

            CreateMap<JobCreateDto, Job>().ReverseMap();
            CreateMap<JobDto, Job>().ReverseMap();

            CreateMap<AddressCreateDto, Address>().ReverseMap();
            CreateMap<AddressDto, Address>().ReverseMap();
        }
    }
}
