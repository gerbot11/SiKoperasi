using SiKoperasi.Core.Data;

namespace SiKoperasi.DataAccess.Models.Commons
{
    public class WorkerSetting : BaseModel
    {
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string RunningInterval { get; set; } = null!;
        public int IntervalValue { get; set; }
        public string StartTime { get; set; } = null!;
    }
}
