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
            CreateMap<InstSchdlMinimalDto, InstalmentSchedule>().ReverseMap();
            CreateMap<LoanPaymentCreateDto, LoanPayment>().ReverseMap();
            CreateMap<LoanPaymentDto, LoanPayment>().ReverseMap();
            CreateMap<LoanSchemeDto, LoanScheme>().ReverseMap();
            CreateMap<LoanGuaranteeDto, LoanGuarantee>().ReverseMap();
            CreateMap<LoanGuaranteeCreateDto, LoanGuarantee>().ReverseMap();
        }
    }
}
