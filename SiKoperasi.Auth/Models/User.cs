using SiKoperasi.Core.Data;

namespace SiKoperasi.Auth.Models
{
    public class User : BaseModel
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public string Username { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public bool IsActive { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
