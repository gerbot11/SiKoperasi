using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.Member;
using SiKoperasi.Core.Common;
using SiKoperasi.DataAccess.Dao;
using SiKoperasi.DataAccess.Models.Members;

namespace SiKoperasi.AppService.Services.Members
{
    public class JobService : BaseCrudService<Job, JobCreateDto, JobEditDto, JobDto, AppDbContext>, IJobService
    {
        public JobService(AppDbContext dbContext, IMapper mapper, ILogger<Job> logger) : base(dbContext, mapper, logger)
        {
        }

        public JobDto GetJobByMember(string memberid)
        {
            Job? member = dbContext.Jobs.FirstOrDefault(a => a.MemberId == memberid);
            return mapper.Map<JobDto>(member);
        }

        public async Task CreateJobAsync(JobCreateDto payload)
        {
            await BaseCreateAsync(payload);
        }

        public async Task EditJobAsync(JobEditDto payload)
        {
            await BaseEditAsync(payload.Id, payload);
        }

        #region Abstract Impl
        protected override Job CreateNewModel(JobCreateDto payload)
        {
            return mapper.Map<Job>(payload);
        }

        protected override DbSet<Job> GetAppDbSet()
        {
            return dbContext.Jobs;
        }

        protected override string SetDefaultOrderField()
        {
            return nameof(Job.DtmCrt);
        }

        protected override void SetModelValue(Job model, JobEditDto payload)
        {
            model.JobName = payload.JobName;
            model.JobDescription= payload.JobDescription;
            model.StartDate = payload.StartDate;
            model.Company = payload.Company;
            model.JobPosition = payload.JobPosition;
        }

        protected override IQueryable<Job> SetQueryable()
        {
            return dbContext.Jobs;
        }

        protected override void ValidateCreate(Job model)
        {
            if (dbContext.Jobs.Any(a => a.MemberId == model.MemberId))
                throw new Exception("Cannot Add More then 1 Member Job");
        }

        protected override void ValidateDelete(Job model)
        {
            return;
        }

        protected override void ValidateEdit(Job model)
        {
            return;
        }

        protected override JobDto MappingToResultCrud(Job model)
        {
            return base.MappingToResult(model);
        }
        #endregion
    }
}
