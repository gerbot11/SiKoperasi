using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using SiKoperasi.Auth.Models;
using SiKoperasi.Auth.Services;
using SiKoperasi.Core.Common;
using SiKoperasi.Core.Data;

namespace SiKoperasi.Auth.Dao
{
    public class AuthDbContext : DbContext
    {
        private readonly IUserResolverService commonService;
        public AuthDbContext(DbContextOptions<AuthDbContext> options, IUserResolverService commonService) : base(options)
        {
            this.commonService = commonService;
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<RolePermission> RolePermissions { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuPermission> MenuPermissions { get; set; }
        public virtual DbSet<LoginAttempt> LoginAttempts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
                entityType.SetTableName(entityType.DisplayName());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            Audit();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess: true, cancellationToken: cancellationToken);
        }

        public override int SaveChanges()
        {
            Audit();
            return base.SaveChanges();
        }

        private void Audit()
        {
            string? currentUser = commonService.GetCurrentUserId();
            string userName = string.IsNullOrEmpty(currentUser) ? "[No User]" : currentUser;
            IEnumerable<EntityEntry> entityEntry = ChangeTracker.Entries().Where(a => a.State == EntityState.Added || a.State == EntityState.Modified);
            foreach (EntityEntry item in entityEntry)
            {
                BaseModel baseModel = (BaseModel)item.Entity;
                if (item.State == EntityState.Added)
                {
                    baseModel.UsrCrt = userName;
                    baseModel.DtmCrt = DateTime.Now;
                    baseModel.UsrUpd = userName;
                    baseModel.DtmUpd = DateTime.Now;
                }
                else if (item.State == EntityState.Modified)
                {
                    baseModel.UsrUpd = userName;
                    baseModel.DtmUpd = DateTime.Now;
                }
            }
        }
    }
}
