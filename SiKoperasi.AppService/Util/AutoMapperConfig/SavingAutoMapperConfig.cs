using AutoMapper;
using SiKoperasi.AppService.Dto.Saving;
using SiKoperasi.DataAccess.Models.Savings;

namespace SiKoperasi.AppService.Util.AutoMapperConfig
{
    public class SavingAutoMapperConfig : Profile
    {
        public SavingAutoMapperConfig()
        {
            CreateMap<SavingMinimalDto, Saving>().ReverseMap();

            CreateMap<SavingTransactionDto, SavingTransaction>().ReverseMap();
        }
    }
}
