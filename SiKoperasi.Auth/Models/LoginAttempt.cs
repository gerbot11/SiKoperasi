using SiKoperasi.Core.Data;

namespace SiKoperasi.Auth.Models
{
    public class LoginAttempt : BaseModel
    {
        public string Username { get; set; }
        public bool IsSuccess { get; set; }
        public string? FailReason { get; set; }
    }
}
