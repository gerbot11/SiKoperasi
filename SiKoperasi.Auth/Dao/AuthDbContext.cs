using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SiKoperasi.Core.Data;

namespace SiKoperasi.Auth.Dao
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
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
            IEnumerable<EntityEntry> entityEntry = ChangeTracker.Entries().Where(a => a.State == EntityState.Added || a.State == EntityState.Modified);
            foreach (EntityEntry item in entityEntry)
            {
                BaseModel baseModel = (BaseModel)item.Entity;
                if (item.State == EntityState.Added)
                {
                    baseModel.UsrCrt = "Test Audit Crt";
                    baseModel.DtmCrt = DateTime.Now;
                    baseModel.UsrUpd = "Test Audit Crt";
                    baseModel.DtmUpd = DateTime.Now;
                }
                else if (item.State == EntityState.Modified)
                {
                    baseModel.UsrUpd = "Test Audit Upd";
                    baseModel.DtmUpd = DateTime.Now;
                }
            }
        }
    }
}
