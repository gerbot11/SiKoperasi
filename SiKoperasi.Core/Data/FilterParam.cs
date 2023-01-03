namespace SiKoperasi.Core.Data
{
    public class FilterParam
    {
        public string Field { get; set; } = null!;
        public string Opr { get; set; } = null!;
        public object Value { get; set; } = null!;
    }
}
