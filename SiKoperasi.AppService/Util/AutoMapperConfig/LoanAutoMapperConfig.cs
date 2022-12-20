using AutoMapper;
using SiKoperasi.AppService.Dto.Loan;
using SiKoperasi.DataAccess.Models.Loans;

namespace SiKoperasi.AppService.Util.AutoMapperConfig
{
    public class LoanAutoMapperConfig : Profile
    {
        public LoanAutoMapperConfig()
        {
            CreateMap<LoanCreateDto, Loan>().ReverseMap();
            CreateMap<LoanDto, Loan>().ReverseMap();
            CreateMap<InstSchdlDto, InstalmentSchedule>().ReverseMap();
        }
    }
}
