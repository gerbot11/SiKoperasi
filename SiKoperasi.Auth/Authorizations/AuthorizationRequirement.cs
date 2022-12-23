using Microsoft.AspNetCore.Authorization;

namespace SiKoperasi.Auth.Authorizations
{
    public class AuthorizationRequirement : IAuthorizationRequirement
    {
        public AuthorizationRequirement(string permissionName)
        {
            PermissionName = permissionName;
        }

        public string PermissionName { get; }
    }
}
