namespace SiKoperasi.AppService.Dto.Member
{
    public record JobDto
    (
        string MemberId,
        string JobName,
        string? JobPosition,
        string? JobDescription,
        string? JobDepartment,
        DateTime StartDate
    );

    public record JobEditDto
    (
        string Id,
        string MemberId,
        string JobName,
        string Company,
        string? JobPosition,
        string? JobDescription,
        string? JobDepartment,
        DateTime StartDate
    );

    public record JobCreateDto
    (
        string JobName,
        string Company,
        string? JobPosition,
        string? JobDescription,
        string? JobDepartment,
        DateTime StartDate
    );
}
