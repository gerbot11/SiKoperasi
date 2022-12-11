using AutoMapper;
using SiKoperasi.AppService.Dto.Province;
using SiKoperasi.DataAccess.Models.MasterData;

namespace SiKoperasi.AppService.Util
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() 
        {
            CreateMap<ProvinceDto, Province>().ReverseMap();
        }
    }
}
