﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Models.Loans;
using SiKoperasi.DataAccess.Models.MasterData;
using SiKoperasi.DataAccess.Models.Members;
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

        //Member
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }

        //Loan
        public virtual DbSet<Loan> Loans { get; set; }
        public virtual DbSet<LoanScheme> LoanSchemes { get; set; }
        public virtual DbSet<InstalmentSchedule> InstalmentSchedules { get; set; }

        //Savings
        public virtual DbSet<Saving> Savings { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            Audit();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess: true, cancellationToken: cancellationToken);
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
                    baseModel.DtmCrt = DateTime.UtcNow;
                    baseModel.UsrUpd = "Test Audit Crt";
                    baseModel.DtmUpd = DateTime.UtcNow;
                }
                else if(item.State == EntityState.Modified)
                {
                    baseModel.UsrUpd = "Test Audit Upd";
                    baseModel.DtmUpd = DateTime.UtcNow;
                }
            }
        }
    }
}