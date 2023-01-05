using SiKoperasi.AppService.Dto.Loan;

namespace SiKoperasi.AppService.Dto.Approval
{
    public record ApprovalDto
    {
        public string Id { get; init; } = null!;
        public string TrxNo { get; init; } = null!;
        public string ApprovalSchemeName { get; init; } = null!;
        public string ApvType { get; init; } = null!;
        public string ReqBy { get; init; } = null!;
        public string ApvStat { get; init; } = null!;
        public DateTime RequestDate { get; init; }
        public ApprovalTaskDto? Task { get; init; }
    }

    public record ApprovalReqDto(string SchmeCode, string TrxNo, string? Notes, string ReqBy);
    public record ApprovalProcessDto(string TrxNo, string ApvStat, string? Notes, bool IsFinal);

    public record ApprovalLoanDetailDto
    {
        public string Id { get; init; } = null!;
        public string TrxNo { get; init; } = null!;
        public string ReqBy { get; init; } = null!;
        public string ApprovalSchemeName { get; init; } = null!;
        public string ApvType { get; init; } = null!;
        public LoanDto Loan { get; init; } = null!;
        public List<ApprovalHistDto>? ApprovalHists { get; init; }
    }

    public record ApprovalHistDto
    {
        public string? ClaimedBy { get; init; }
        public string? Notes { get; init; }
        public DateTime? ApproveDate { get; init; }
    }

    public record ApprovalTaskDto
    {
        public string ClaimedBy { get; init; } = null!;
        public bool IsClaimed { get; init; }
        public string TaskId { get; init; } = null!;
    }
}
