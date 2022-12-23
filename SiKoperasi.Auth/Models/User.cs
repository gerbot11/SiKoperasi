using SiKoperasi.Core.Data;

namespace SiKoperasi.Auth.Models
{
    public class User : BaseModel
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public string Username { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
