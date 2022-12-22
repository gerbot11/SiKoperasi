using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.AppService.Dto.SubDistrict;
using SiKoperasi.Core.Common;
using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Dao;
using SiKoperasi.DataAccess.Models.MasterData;

namespace SiKoperasi.AppService.Services.Master
{
    public class SubDistrictService : BaseCrudService<SubDistrict, SubDistrictCreateDto, SubDistrictEditDto, SubDistrictDto, AppDbContext>, ISubDistrictService
    {
        public SubDistrictService(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task CreateSubDistrictAsync(SubDistrictCreateDto payload)
        {
            await BaseCreateAsync(payload);
        }

        public async Task EditSubDistrictAsync(SubDistrictEditDto payload)
        {
            await BaseEditAsync(payload.Id, payload);
        }

        public async Task DeleteSubDistrictAsync(string id)
        {
            await BaseDeleteAsync(id);
        }

        public SubDistrict GetSubDistrictModel(string id)
        {
            return BaseGetModelById(id);
        }

        public async Task<SubDistrictDto> GetSubDistrictAsync(string id)
        {
            return await BaseGetByIdAsync(id);
        }

        public async Task<PagingModel<SubDistrictDto>> GetSubDistrictPagingAsync(QueryParamDto queryParam)
        {
            return await BaseGetPagingDataDtoAsync(queryParam);
        }

        protected override SubDistrict CreateNewModel(SubDistrictCreateDto payload)
        {
            return mapper.Map<SubDistrict>(payload);
        }

        protected override DbSet<SubDistrict> GetAppDbSet()
        {
            return dbContext.SubDistricts;
        }

        protected override string SetDefaultOrderField()
        {
            return nameof(SubDistrict.Name);
        }

        protected override void SetModelValue(SubDistrict model, SubDistrictEditDto payload)
        {
            model.Name = payload.Name;
            model.Code = payload.Code;
            model.PostalCode = payload.PostalCode;
        }

        protected override IQueryable<SubDistrict> SetQueryable()
        {
            return dbContext.SubDistricts;
        }

        protected override void ValidateCreate(SubDistrict model)
        {
            if (dbContext.SubDistricts.Any(a => a.Code == model.Code))
                throw new Exception($"Sub District with Code {model.Code} already exist");
        }

        protected override void ValidateDelete(SubDistrict model)
        {
            if (dbContext.Addresses.Any(a => a.SubDistrictId == model.Id))
                throw new Exception("Cannot Delete, Reference to Address");
        }

        protected override void ValidateEdit(SubDistrict model)
        {
            if (dbContext.SubDistricts.Any(a => a.Code == model.Code && a.Id != model.Id))
                throw new Exception($"Sub District with Code {model.Code} already exist");
        }
    }
}
