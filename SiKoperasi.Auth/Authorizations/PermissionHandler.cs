using Microsoft.AspNetCore.Authorization;

namespace SiKoperasi.Auth.Authorizations
{
    internal class PermissionHandler : AuthorizationHandler<AuthorizationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AuthorizationRequirement requirement)
        {
            throw new NotImplementedException();
        }
    }
}
