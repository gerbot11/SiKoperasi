using SiKoperasi.AppService.Dto.Member;
using SiKoperasi.DataAccess.Models.Members;

namespace SiKoperasi.AppService.Contract
{
    public interface IAddressService
    {
        Task CreateAddressAsync(AddressCreateDto payload);
        Task DeleteAddressAsync(string id);
        Task EditAddressAsync(AddressEditDto payload);
        Task<AddressDto> GetAddressAsync(string id);
        Task<AddressDto?> GetAddressDtoByMemberAsync(string memberId);
    }
}
