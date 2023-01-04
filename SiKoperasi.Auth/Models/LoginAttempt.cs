using SiKoperasi.Core.Data;

namespace SiKoperasi.Auth.Models
{
    public class LoginAttempt : BaseModel
    {
        public string Username { get; set; } = null!;
        public bool IsSuccess { get; set; }
        public DateTime LoginTime { get; set; }
        public string? FailReason { get; set; }
        public string? Token { get; set; }
        public DateTime? ValidUntil { get; set; }
    }
}
