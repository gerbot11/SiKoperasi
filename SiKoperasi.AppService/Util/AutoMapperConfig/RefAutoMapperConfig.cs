using AutoMapper;
using SiKoperasi.AppService.Dto.Loan;
using SiKoperasi.DataAccess.Models.Loans;

namespace SiKoperasi.AppService.Util.AutoMapperConfig
{
    public class RefAutoMapperConfig : Profile
    {
        public RefAutoMapperConfig()
        {
            CreateMap<RefLoanDocCreateDto, RefLoanDocument>().ReverseMap();
            CreateMap<RefLoanDocDto, RefLoanDocument>().ReverseMap();
        }
    }
}
