using SiKoperasi.Core.Data;

namespace SiKoperasi.DataAccess.Models.MasterData
{
    public class MasterSequence : BaseModel
    {
        public string MasterSeqCode { get; set; }
        public string MasterSeqName { get; set; }
        public int SeqNo { get; set; }
        public string Prefix { get; set; }
        public string Sufix { get; set; }
        public int NumLength { get; set; }
        public string RessetFlag { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }

        public const string MEMBER_CODE = "MEM";
        public const string LOAN_CODE = "LOS";

        public const int MAX_NUM_LENGTH = 10;
        public const int MIN_NUM_LENGTH = 4;

        public const string RESET_FLAG_YEAR = "Y";
        public const string RESET_FLAG_MONTH = "M";
    }
}
