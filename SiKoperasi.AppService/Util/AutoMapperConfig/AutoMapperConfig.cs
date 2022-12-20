using AutoMapper;
using SiKoperasi.AppService.Dto.City;
using SiKoperasi.AppService.Dto.District;
using SiKoperasi.AppService.Dto.Loan;
using SiKoperasi.AppService.Dto.Member;
using SiKoperasi.AppService.Dto.Province;
using SiKoperasi.AppService.Dto.SubDistrict;
using SiKoperasi.DataAccess.Models.Loans;
using SiKoperasi.DataAccess.Models.MasterData;
using SiKoperasi.DataAccess.Models.Members;

namespace SiKoperasi.AppService.Util.AutoMapperConfig
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ProvinceDto, Province>().ReverseMap();
            CreateMap<ProvinceCreateDto, Province>().ReverseMap();

            CreateMap<CityDto, City>().ReverseMap();
            CreateMap<CityCreateDto, City>().ReverseMap();

            CreateMap<DistrictCreateDto, District>().ReverseMap();
            CreateMap<DistrictDto, District>().ReverseMap();

            CreateMap<SubDistrictCreateDto, SubDistrict>().ReverseMap();
            CreateMap<SubDistrictDto, SubDistrict>().ReverseMap();
        }
    }
}
