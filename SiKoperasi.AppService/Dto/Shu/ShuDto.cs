namespace SiKoperasi.AppService.Dto.Shu
{
    public record ShuDto
    {
        public string Id { get; init; } = null!;
        public string ShuName { get; init; } = null!;
        public string? Descr { get; init; }
        public decimal AllocationAmt { get; init; }
        public bool IsExpense { get; init; }
    }

    public record ShuCreateDto(string ShuName, string? Descr, decimal AllocationAmt, bool IsExpense);
    public record ShuEditDto(string Id, string ShuName, string? Descr, decimal AllocationAmt, bool IsExpense);

    public record ShuTrxDto
    {
        public string Id { get; init; } = null!;
        public string ShuAllocationId { get; init; } = null!;
        public string TrxNo { get; init; } = null!;
        public DateTime TrxDate { get; init; }
        public decimal AllocationAmt { get; init; }
        public decimal AllocationPrcnt { get; init; }
    }
}
