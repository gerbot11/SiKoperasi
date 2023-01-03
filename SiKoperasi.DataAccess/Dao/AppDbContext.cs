using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Models.Commons;
using SiKoperasi.DataAccess.Models.Loans;
using SiKoperasi.DataAccess.Models.MasterData;
using SiKoperasi.DataAccess.Models.Members;
using SiKoperasi.DataAccess.Models.Payments;
using SiKoperasi.DataAccess.Models.Savings;
using SiKoperasi.DataAccess.Models.Shu;

namespace SiKoperasi.DataAccess.Dao
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        //Master Data
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<SubDistrict> SubDistricts { get; set; }
        public virtual DbSet<MasterSequence> MasterSequences { get; set; }

        //Member
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }

        //Loan
        public virtual DbSet<Loan> Loans { get; set; }
        public virtual DbSet<LoanScheme> LoanSchemes { get; set; }
        public virtual DbSet<InstalmentSchedule> InstalmentSchedules { get; set; }
        public virtual DbSet<LoanDocument> LoanDocuments { get; set; }
        public virtual DbSet<RefLoanDocument> RefLoanDocuments { get; set; }
        public virtual DbSet<LoanPayment> LoanPayments { get; set; }
        public virtual DbSet<LoanGuarantee> LoanGuarantees { get; set; }

        //Savings
        public virtual DbSet<Saving> Savings { get; set; }
        public virtual DbSet<SavingTransaction> SavingTransactions { get; set; }
        public virtual DbSet<RefSavingType> RefSavingTypes { get; set; }

        //Commons
        public virtual DbSet<DriveFolderMap> DriveFolderMaps { get; set; }
        public virtual DbSet<RefMaster> RefMasters { get; set; }

        //Payments
        public virtual DbSet<PayHistH> PayHistHs { get; set; }
        public virtual DbSet<PayHistD> PayHistDs { get; set; }

        //Cash Bank
        public virtual DbSet<CashBank> CashBanks { get; set; }
        public virtual DbSet<CashBankAccount> CashBankAccounts { get; set; }
        public virtual DbSet<CashBankTrx> CashBankTrxes { get; set; }

        //SHU
        public virtual DbSet<ShuAllocation> ShuAllocations { get; set; }
        public virtual DbSet<ShuAllocationTrx> ShuAllocationTrxes { get; set; }
        public virtual DbSet<ShuAllocationTrxDist> ShuAllocationTrxDists { get; set; }
        public virtual DbSet<ShuAllocationMember> ShuAllocationLoans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var decimalProps = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => (System.Nullable.GetUnderlyingType(p.ClrType) ?? p.ClrType) == typeof(decimal));

            foreach (var property in decimalProps)
            {
                property.SetPrecision(18);
                property.SetScale(2);
            }

            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                //entityType.Relational().TableName = entityType.DisplayName();
                entityType.SetTableName(entityType.DisplayName());
            }
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
                else if(item.State == EntityState.Modified)
                {
                    baseModel.UsrUpd = "Test Audit Upd";
                    baseModel.DtmUpd = DateTime.Now;
                }
            }
        }
    }
}
