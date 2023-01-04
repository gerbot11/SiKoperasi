using Newtonsoft.Json;
using SiKoperasi.Core.Data;
using SiKoperasi.Core.Enums;

namespace SiKoperasi.Auth.Dto
{
    public class QueryParamDto : IQueryParam
    {
        [JsonProperty("page_index")]
        public int PageIndex { get; set; } = 1;
        [JsonProperty("page_size")]
        public int PageSize { get => size; set => size = value > maxSize ? maxSize : value; }
        [JsonProperty("order_by")]
        public string? OrderBy { get; set; }
        [JsonProperty("order_behaviour")]
        public OrderBehaviour? OrderBehavior { get; set; }
        [JsonProperty("search_qeury")]
        public string? SearchQuery { get; set; }
        [JsonProperty("search_filter")]
        public string? SearchFilter { get; set; }

        private const int maxSize = 200;
        private int size = 10;
    }
}
