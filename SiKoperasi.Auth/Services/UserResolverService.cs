using Microsoft.AspNetCore.Http;
using SiKoperasi.Core.Common;
using SiKoperasi.Core.Data;
using System.Security.Claims;

namespace SiKoperasi.Auth.Services
{
    public class UserResolverService : IUserResolverService
    {
        private readonly IHttpContextAccessor context;
        public UserResolverService(IHttpContextAccessor context)
        {
            this.context = context;
        }

        public UserIdentity GetCurrentUser()
        {
            var claimContext = context.HttpContext.User.Claims;
            UserIdentity userIdentity = new();
            if (claimContext.Any())
            {
                foreach (var item in claimContext)
                {
                    switch (item.Type)
                    {
                        case ClaimTypes.Name:
                            userIdentity.FullName = item.Value;
                            break;
                        case ClaimTypes.Email:
                            userIdentity.Email = item.Value;
                            break;
                        case ClaimTypes.NameIdentifier:
                            userIdentity.Id = item.Value;
                            break;
                        case ClaimTypes.GivenName:
                            userIdentity.Username = item.Value;
                            break;
                        case ClaimTypes.MobilePhone:
                            userIdentity.Phone = item.Value;
                            break;
                        default:
                            break;
                    }
                }
            }

            return userIdentity;
        }

        public UserIdentity GetCurrentUserRole()
        {
            var claimContext = context.HttpContext.User.Claims.Where(a => a.Type == ClaimTypes.Role && a.Type == ClaimTypes.NameIdentifier);
            UserIdentity userIdentity = new();
            foreach (var item in claimContext)
            {
                if (item.Type == ClaimTypes.Role)
                    userIdentity.Roles.Add(item.Value);
                else
                    userIdentity.Id = item.Value;
            }

            return userIdentity;
        }

        public string? GetCurrentUserId()
        {
            return context.HttpContext.User.Claims.Where(a => a.Type == ClaimTypes.NameIdentifier).Select(a => a.Value).FirstOrDefault();
        }
    }
}
