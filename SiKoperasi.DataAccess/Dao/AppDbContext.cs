using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Models.Commons;
using SiKoperasi.DataAccess.Models.Loans;
using SiKoperasi.DataAccess.Models.MasterData;
using SiKoperasi.DataAccess.Models.Members;
using SiKoperasi.DataAccess.Models.Payments;
using SiKoperasi.DataAccess.Models.Savings;

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
        public virtual DbSet<MemberDocument> MembersDocument { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }

        //Loan
        public virtual DbSet<Loan> Loans { get; set; }
        public virtual DbSet<LoanScheme> LoanSchemes { get; set; }
        public virtual DbSet<InstalmentSchedule> InstalmentSchedules { get; set; }
        public virtual DbSet<LoanDocument> LoanDocuments { get; set; }
        public virtual DbSet<RefLoanDocument> RefLoanDocuments { get; set; }
        public virtual DbSet<LoanPayment> LoanPayments { get; set; }

        //Savings
        public virtual DbSet<Saving> Savings { get; set; }
        public virtual DbSet<SavingTransaction> SavingTransactions { get; set; }
        public virtual DbSet<RefSavingType> RefSavingTypes { get; set; }

        //Commons
        public virtual DbSet<DriveFolderMap> DriveFolderMaps { get; set; }

        //Payments
        public virtual DbSet<PayHistH> PayHistHs { get; set; }
        public virtual DbSet<PayHistD> PayHistDs { get; set; }

        //Cash Bank
        public virtual DbSet<CashBank> CashBanks { get; set; }
        public virtual DbSet<CashBankAccount> CashBankAccounts { get; set; }
        public virtual DbSet<CashBankTrx> CashBankTrxes { get; set; }

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
