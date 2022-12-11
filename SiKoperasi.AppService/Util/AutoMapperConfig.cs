using AutoMapper;
using SiKoperasi.AppService.Dto.City;
using SiKoperasi.AppService.Dto.District;
using SiKoperasi.AppService.Dto.Member;
using SiKoperasi.AppService.Dto.Province;
using SiKoperasi.DataAccess.Models.MasterData;
using SiKoperasi.DataAccess.Models.Members;

namespace SiKoperasi.AppService.Util
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() 
        {
            CreateMap<ProvinceDto, Province>().ReverseMap();
            CreateMap<CityDto, City>().ReverseMap();
            CreateMap<DistrictDto, District>().ReverseMap();
            CreateMap<MemberDto, Member>().ReverseMap();
        }
    }
}
