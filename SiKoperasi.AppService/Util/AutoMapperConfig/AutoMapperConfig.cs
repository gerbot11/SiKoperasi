using AutoMapper;
using SiKoperasi.AppService.Dto.CashBank;
using SiKoperasi.AppService.Dto.City;
using SiKoperasi.AppService.Dto.District;
using SiKoperasi.AppService.Dto.Province;
using SiKoperasi.AppService.Dto.Shu;
using SiKoperasi.AppService.Dto.SubDistrict;
using SiKoperasi.DataAccess.Models.MasterData;
using SiKoperasi.DataAccess.Models.Payments;
using SiKoperasi.DataAccess.Models.Shu;

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

            CreateMap<CashBankAccDto, CashBankAccount>().ReverseMap();
            CreateMap<CashBankAccCreateDto, CashBankAccount>().ReverseMap();

            CreateMap<ShuDto, ShuAllocation>().ReverseMap();
            CreateMap<ShuCreateDto, ShuAllocation>().ReverseMap();
        }
    }
}
