using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.District;
using SiKoperasi.Core.Common;
using SiKoperasi.DataAccess.Dao;
using SiKoperasi.DataAccess.Models.MasterData;

namespace SiKoperasi.AppService.Services.Master
{
    public class DistrictService : BaseCrudService<District, DistrictCreateDto, DistrictEditDto, DistrictDto, AppDbContext>, IDistrictService
    {
        public DistrictService(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public Task CreateDistrictAsync(DistrictCreateDto dto)
        {
            throw new NotImplementedException();
        }

        public District GetDistrictModel(string id)
        {
            throw new NotImplementedException();
        }

        #region Abstract Implementation
        protected override District CreateNewModel(DistrictCreateDto payload)
        {
            throw new NotImplementedException();
        }

        protected override DbSet<District> GetAppDbSet()
        {
            throw new NotImplementedException();
        }

        protected override void SetModelValue(District model, DistrictEditDto payload)
        {
            throw new NotImplementedException();
        }

        protected override IQueryable<District> SetQueryable()
        {
            throw new NotImplementedException();
        }

        protected override void ValidateCreate(District model)
        {
            throw new NotImplementedException();
        }

        protected override void ValidateDelete(District model)
        {
            throw new NotImplementedException();
        }

        protected override void ValidateEdit(District model)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
