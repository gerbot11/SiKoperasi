using SiKoperasi.AppService.Contract;
using SiKoperasi.DataAccess.Dao;
using SiKoperasi.DataAccess.Models.MasterData;

namespace SiKoperasi.AppService.Services.Master
{
    public class MasterSequenceService : IMasterSequenceService
    {
        private readonly AppDbContext context;
        public MasterSequenceService(AppDbContext context)
        {
            this.context = context;
        }

        public string GenerateNo(string seqCode)
        {
            MasterSequence ms = context.MasterSequences.First(a => a.MasterSeqCode == seqCode);
            DateTime dtNow = DateTime.Now;

            if (dtNow.Year != ms.Year)
            {
                ms.Year = dtNow.Year;
            }

            if (dtNow.Month != ms.Month)
            {
                ms.Month = dtNow.Month;
                ms.SeqNo = 1;
            }

            if (ms.SeqNo <= 0)
            {
                ms.SeqNo = 1;
            }

            string no = ms.Month + ms.Prefix + ms.Year + ms.SeqNo.ToString().PadLeft(ms.NumLength, '0');

            ms.SeqNo += 1;

            context.Update(ms);

            return no;
        }
    }
}
