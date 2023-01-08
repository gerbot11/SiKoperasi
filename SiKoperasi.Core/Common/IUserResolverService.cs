using SiKoperasi.Core.Data;

namespace SiKoperasi.Core.Common
{
    public interface IUserResolverService
    {
        string? GetCurrentUserId();
        UserIdentity GetCurrentUser();
        UserIdentity GetCurrentUserRole();
    }
}
