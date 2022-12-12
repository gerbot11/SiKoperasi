using SiKoperasi.AppService.Dto.Member;

namespace SiKoperasi.AppService.Contract
{
    public interface IJobService
    {
        Task CreateJobAsync(JobCreateDto payload);
        Task EditJobAsync(JobEditDto payload);
        JobDto GetJobByMember(string memberid);
    }
}
