using SiKoperasi.Core.Data;

namespace SiKoperasi.DataAccess.Models.MasterData
{
    public class MasterSequence : BaseModel
    {
        public string MasterSeqCode { get; set; } = null!;
        public string MasterSeqName { get; set; } = null!;
        public int SeqNo { get; set; }
        public string Prefix { get; set; } = null!;
        public string Sufix { get; set; } = null!;
        public int NumLength { get; set; }
        public string RessetFlag { get; set; } = null!;
        public int Year { get; set; }
        public int Month { get; set; }

        public const int MAX_NUM_LENGTH = 10;
        public const int MIN_NUM_LENGTH = 4;

        public const string RESET_FLAG_YEAR = "Y";
        public const string RESET_FLAG_MONTH = "M";
    }
}
