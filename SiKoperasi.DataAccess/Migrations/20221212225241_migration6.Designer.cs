// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SiKoperasi.DataAccess.Dao;

#nullable disable

namespace SiKoperasi.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221212225241_migration6")]
    partial class migration6
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SiKoperasi.DataAccess.Models.Loans.InstalmentSchedule", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DtmCrt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtmUpd")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("InstAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("InstDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("InterestAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("LateChargeAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("LoanId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("OsInterestAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("OsPrincipalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("PayDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("PrincipalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SeqNo")
                        .HasColumnType("int");

                    b.Property<string>("UsrCrt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsrUpd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LoanId");

                    b.ToTable("InstalmentSchedules");
                });

            modelBuilder.Entity("SiKoperasi.DataAccess.Models.Loans.Loan", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("CurrentDueNum")
                        .HasColumnType("int");

                    b.Property<DateTime>("DtmCrt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtmUpd")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("LoanAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("LoanDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LoanNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LoanSchemeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MemberId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("NextDueNum")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsrCrt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsrUpd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LoanSchemeId");

                    b.HasIndex("MemberId")
                        .IsUnique();

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("SiKoperasi.DataAccess.Models.Loans.LoanDocument", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DocumentExt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DtmCrt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtmUpd")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LoanId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UsrCrt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsrUpd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LoanId");

                    b.ToTable("LoanDocument");
                });

            modelBuilder.Entity("SiKoperasi.DataAccess.Models.Loans.LoanScheme", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DtmCrt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtmUpd")
                        .HasColumnType("datetime2");

                    b.Property<int>("DueNum")
                        .HasColumnType("int");

                    b.Property<string>("LoanSchemeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PlafondAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UsrCrt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsrUpd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LoanSchemes");
                });

            modelBuilder.Entity("SiKoperasi.DataAccess.Models.MasterData.City", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DtmCrt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtmUpd")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProvinceId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UsrCrt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsrUpd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("SiKoperasi.DataAccess.Models.MasterData.District", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CityId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DtmCrt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtmUpd")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsrCrt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsrUpd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("SiKoperasi.DataAccess.Models.MasterData.MasterSequence", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DtmCrt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtmUpd")
                        .HasColumnType("datetime2");

                    b.Property<string>("MasterSeqCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MasterSeqName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<int>("NumLength")
                        .HasColumnType("int");

                    b.Property<string>("Prefix")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RessetFlag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeqNo")
                        .HasColumnType("int");

                    b.Property<string>("Sufix")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsrCrt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsrUpd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MasterSequences");
                });

            modelBuilder.Entity("SiKoperasi.DataAccess.Models.MasterData.Province", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DtmCrt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtmUpd")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TimeZone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsrCrt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsrUpd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Provinces");
                });

            modelBuilder.Entity("SiKoperasi.DataAccess.Models.MasterData.SubDistrict", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DistrictId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DtmCrt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtmUpd")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsrCrt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsrUpd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DistrictId");

                    b.ToTable("SubDistricts");
                });

            modelBuilder.Entity("SiKoperasi.DataAccess.Models.Members.Address", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AddressType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CityId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DistrictId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DtmCrt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtmUpd")
                        .HasColumnType("datetime2");

                    b.Property<string>("MemberId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProvinceId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Rt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rw")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubDistrictId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UsrCrt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsrUpd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("DistrictId");

                    b.HasIndex("MemberId");

                    b.HasIndex("ProvinceId");

                    b.HasIndex("SubDistrictId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("SiKoperasi.DataAccess.Models.Members.Job", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DtmCrt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtmUpd")
                        .HasColumnType("datetime2");

                    b.Property<string>("JobDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobPosition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemberId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UsrCrt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsrUpd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MemberId")
                        .IsUnique();

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("SiKoperasi.DataAccess.Models.Members.Member", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("BirthPlace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DtmCrt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtmUpd")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsIdVerified")
                        .HasColumnType("bit");

                    b.Property<string>("MemberNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NpwpNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UsrCrt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsrUpd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("SiKoperasi.DataAccess.Models.Members.MemberDocument", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DocumentExt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DtmCrt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtmUpd")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemberId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UsrCrt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsrUpd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("MembersDocument");
                });

            modelBuilder.Entity("SiKoperasi.DataAccess.Models.Savings.Saving", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DtmCrt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtmUpd")
                        .HasColumnType("datetime2");

                    b.Property<string>("MemberId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SavingType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TransactionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsrCrt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsrUpd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("Savings");
                });

            modelBuilder.Entity("SiKoperasi.DataAccess.Models.Loans.InstalmentSchedule", b =>
                {
                    b.HasOne("SiKoperasi.DataAccess.Models.Loans.Loan", "Loan")
                        .WithMany("InstalmentSchedules")
                        .HasForeignKey("LoanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Loan");
                });

            modelBuilder.Entity("SiKoperasi.DataAccess.Models.Loans.Loan", b =>
                {
                    b.HasOne("SiKoperasi.DataAccess.Models.Loans.LoanScheme", "LoanScheme")
                        .WithMany()
                        .HasForeignKey("LoanSchemeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SiKoperasi.DataAccess.Models.Members.Member", "Member")
                        .WithOne("Loan")
                        .HasForeignKey("SiKoperasi.DataAccess.Models.Loans.Loan", "MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoanScheme");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("SiKoperasi.DataAccess.Models.Loans.LoanDocument", b =>
                {
                    b.HasOne("SiKoperasi.DataAccess.Models.Loans.Loan", "Loan")
                        .WithMany("LoanDocuments")
                        .HasForeignKey("LoanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Loan");
                });

            modelBuilder.Entity("SiKoperasi.DataAccess.Models.MasterData.City", b =>
                {
                    b.HasOne("SiKoperasi.DataAccess.Models.MasterData.Province", "Province")
                        .WithMany("Cities")
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Province");
                });

            modelBuilder.Entity("SiKoperasi.DataAccess.Models.MasterData.District", b =>
                {
                    b.HasOne("SiKoperasi.DataAccess.Models.MasterData.City", "City")
                        .WithMany("Districts")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("SiKoperasi.DataAccess.Models.MasterData.SubDistrict", b =>
                {
                    b.HasOne("SiKoperasi.DataAccess.Models.MasterData.District", "District")
                        .WithMany("SubDistricts")
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("District");
                });

            modelBuilder.Entity("SiKoperasi.DataAccess.Models.Members.Address", b =>
                {
                    b.HasOne("SiKoperasi.DataAccess.Models.MasterData.City", "City")
                        .WithMany("Addresses")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SiKoperasi.DataAccess.Models.MasterData.District", "District")
                        .WithMany("Addresses")
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SiKoperasi.DataAccess.Models.Members.Member", "Member")
                        .WithMany("Addresses")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SiKoperasi.DataAccess.Models.MasterData.Province", "Province")
                        .WithMany("Addresses")
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SiKoperasi.DataAccess.Models.MasterData.SubDistrict", "SubDistrict")
                        .WithMany("Addresses")
                        .HasForeignKey("SubDistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("District");

                    b.Navigation("Member");

                    b.Navigation("Province");

                    b.Navigation("SubDistrict");
                });

            modelBuilder.Entity("SiKoperasi.DataAccess.Models.Members.Job", b =>
                {
                    b.HasOne("SiKoperasi.DataAccess.Models.Members.Member", "Member")
                        .WithOne("Job")
                        .HasForeignKey("SiKoperasi.DataAccess.Models.Members.Job", "MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("SiKoperasi.DataAccess.Models.Members.MemberDocument", b =>
                {
                    b.HasOne("SiKoperasi.DataAccess.Models.Members.Member", "Member")
                        .WithMany("MemberDocuments")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("SiKoperasi.DataAccess.Models.Savings.Saving", b =>
                {
                    b.HasOne("SiKoperasi.DataAccess.Models.Members.Member", "Member")
                        .WithMany("Savings")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("SiKoperasi.DataAccess.Models.Loans.Loan", b =>
                {
                    b.Navigation("InstalmentSchedules");

                    b.Navigation("LoanDocuments");
                });

            modelBuilder.Entity("SiKoperasi.DataAccess.Models.MasterData.City", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Districts");
                });

            modelBuilder.Entity("SiKoperasi.DataAccess.Models.MasterData.District", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("SubDistricts");
                });

            modelBuilder.Entity("SiKoperasi.DataAccess.Models.MasterData.Province", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Cities");
                });

            modelBuilder.Entity("SiKoperasi.DataAccess.Models.MasterData.SubDistrict", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("SiKoperasi.DataAccess.Models.Members.Member", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Job")
                        .IsRequired();

                    b.Navigation("Loan")
                        .IsRequired();

                    b.Navigation("MemberDocuments");

                    b.Navigation("Savings");
                });
#pragma warning restore 612, 618
        }
    }
}
