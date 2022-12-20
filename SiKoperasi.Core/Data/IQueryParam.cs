using SiKoperasi.Core.Enums;

namespace SiKoperasi.Core.Data
{
    public interface IQueryParam
    {
        int PageIndex { get; set; }
        int PageSize { get; set; }
        string? OrderBy { get; set; }
        OrderBehaviour? OrderBehavior { get; set; }
        string? SearchQuery { get; set; }
        string? SearchFilter { get; set; }
    }
}
