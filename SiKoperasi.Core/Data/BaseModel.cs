namespace SiKoperasi.Core.Data
{
    public abstract class BaseModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UsrCrt { get; set; } = null!;
        public DateTime DtmCrt { get; set; }
        public string UsrUpd { get; set; } = null!;
        public DateTime DtmUpd { get; set; }
    }
}
