using SiKoperasi.Core.Data;
using SiKoperasi.Core.Enums;

namespace SiKoperasi.AppService.Dto.Common
{
    public class QueryParamDto : IQueryParam
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get => size; set => size = value > maxSize ? maxSize : value; }
        public string? OrderBy { get; set; }
        public OrderBehaviour? OrderBehavior { get; set; }
        public string? SearchQuery { get; set; }

        private const int maxSize = 200;
        private int size = 10;
    }
}
