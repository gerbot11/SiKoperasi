using SiKoperasi.AppService.Dto.City;
using SiKoperasi.AppService.Dto.District;
using SiKoperasi.AppService.Dto.Province;
using SiKoperasi.AppService.Dto.SubDistrict;

namespace SiKoperasi.AppService.Dto.Member
{
    public record AddressDto
    (
        string MemberId,
        string AddressType,
        string Description,
        string Rt,
        string Rw,
        ProvinceDto Province,
        CityDto City,
        DistrictDto District,
        SubDistrictDto SubDistrict
    );

    public record AddressCreateDto
    (
        string AddressType,
        string Description,
        string Rt,
        string Rw,
        string ProvinceId,
        string CityId,
        string DistrictId,
        string SubDistrictId
    );

    public record AddressEditDto
    (
        string Id,
        string MemberId,
        string AddressType,
        string Description,
        string Rt,
        string Rw,
        string ProvinceId,
        string CityId,
        string DistrictId,
        string SubDistrictId
    );
}
