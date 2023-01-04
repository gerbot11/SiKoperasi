using SiKoperasi.Auth.Dto;
using System.Security.Claims;

namespace SiKoperasi.Auth.Commons
{
    public class UserIdentity : ClaimsPrincipal
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public List<string> Roles { get; set; }

        public bool HasPermission(string permission)
        {
            return true;
        }
    }
}
