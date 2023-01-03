namespace SiKoperasi.Core.Data
{
    public class BaseDtoModel
    {
        public string Id { get; set; } = null!;
        public string UsrCrt { get; set; } = null!;
        public DateTime DtmCrt { get; set; }
        public string UsrUpd { get; set; } = null!;
        public DateTime DtmUpd { get; set; }
    }
}
