namespace SiKoperasi.Core.Data
{
    public abstract class BaseModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UsrCrt { get; set; }
        public DateTime DtmCrt { get; set; }
        public string UsrUpd { get; set; }
        public DateTime DtmUpd { get; set; }
    }
}
