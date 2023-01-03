using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiKoperasi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migration30 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Cities_CityId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Districts_DistrictId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Members_MemberId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Provinces_ProvinceId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_SubDistricts_SubDistrictId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_CashBanks_CashBankAccounts_CashBankAccountId",
                table: "CashBanks");

            migrationBuilder.DropForeignKey(
                name: "FK_CashBankTrxes_CashBanks_CashBankId",
                table: "CashBankTrxes");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Provinces_ProvinceId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Districts_Cities_CityId",
                table: "Districts");

            migrationBuilder.DropForeignKey(
                name: "FK_InstalmentSchedules_Loans_LoanId",
                table: "InstalmentSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Members_MemberId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanDocuments_Loans_LoanId",
                table: "LoanDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanDocuments_RefLoanDocuments_RefLoanDocumentId",
                table: "LoanDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanGuarantees_Loans_LoanId",
                table: "LoanGuarantees");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanPayments_Loans_LoanId",
                table: "LoanPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_LoanSchemes_LoanSchemeId",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Members_MemberId",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_PayHistDs_PayHistHs_PayHistHId",
                table: "PayHistDs");

            migrationBuilder.DropForeignKey(
                name: "FK_Savings_Members_MemberId",
                table: "Savings");

            migrationBuilder.DropForeignKey(
                name: "FK_Savings_RefSavingTypes_RefSavingTypeId",
                table: "Savings");

            migrationBuilder.DropForeignKey(
                name: "FK_SavingTransactions_Savings_SavingId",
                table: "SavingTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_ShuAllocationLoans_Loans_LoanId",
                table: "ShuAllocationLoans");

            migrationBuilder.DropForeignKey(
                name: "FK_ShuAllocationLoans_ShuAllocationTrxDists_ShuAllocationTrxDistId",
                table: "ShuAllocationLoans");

            migrationBuilder.DropForeignKey(
                name: "FK_ShuAllocationTrxDists_ShuAllocationTrxes_ShuAllocationTrxId",
                table: "ShuAllocationTrxDists");

            migrationBuilder.DropForeignKey(
                name: "FK_ShuAllocationTrxDists_ShuAllocations_ShuAllocationId",
                table: "ShuAllocationTrxDists");

            migrationBuilder.DropForeignKey(
                name: "FK_ShuAllocationTrxes_ShuAllocations_ShuAllocationId",
                table: "ShuAllocationTrxes");

            migrationBuilder.DropForeignKey(
                name: "FK_SubDistricts_Districts_DistrictId",
                table: "SubDistricts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubDistricts",
                table: "SubDistricts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShuAllocationTrxes",
                table: "ShuAllocationTrxes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShuAllocationTrxDists",
                table: "ShuAllocationTrxDists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShuAllocations",
                table: "ShuAllocations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShuAllocationLoans",
                table: "ShuAllocationLoans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SavingTransactions",
                table: "SavingTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Savings",
                table: "Savings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RefSavingTypes",
                table: "RefSavingTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RefMasters",
                table: "RefMasters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RefLoanDocuments",
                table: "RefLoanDocuments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Provinces",
                table: "Provinces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PayHistHs",
                table: "PayHistHs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PayHistDs",
                table: "PayHistDs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Members",
                table: "Members");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MasterSequences",
                table: "MasterSequences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoanSchemes",
                table: "LoanSchemes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Loans",
                table: "Loans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoanPayments",
                table: "LoanPayments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoanGuarantees",
                table: "LoanGuarantees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoanDocuments",
                table: "LoanDocuments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InstalmentSchedules",
                table: "InstalmentSchedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DriveFolderMaps",
                table: "DriveFolderMaps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Districts",
                table: "Districts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CashBankTrxes",
                table: "CashBankTrxes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CashBanks",
                table: "CashBanks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CashBankAccounts",
                table: "CashBankAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "SubDistricts",
                newName: "SubDistrict");

            migrationBuilder.RenameTable(
                name: "ShuAllocationTrxes",
                newName: "ShuAllocationTrx");

            migrationBuilder.RenameTable(
                name: "ShuAllocationTrxDists",
                newName: "ShuAllocationTrxDist");

            migrationBuilder.RenameTable(
                name: "ShuAllocations",
                newName: "ShuAllocation");

            migrationBuilder.RenameTable(
                name: "ShuAllocationLoans",
                newName: "ShuAllocationLoan");

            migrationBuilder.RenameTable(
                name: "SavingTransactions",
                newName: "SavingTransaction");

            migrationBuilder.RenameTable(
                name: "Savings",
                newName: "Saving");

            migrationBuilder.RenameTable(
                name: "RefSavingTypes",
                newName: "RefSavingType");

            migrationBuilder.RenameTable(
                name: "RefMasters",
                newName: "RefMaster");

            migrationBuilder.RenameTable(
                name: "RefLoanDocuments",
                newName: "RefLoanDocument");

            migrationBuilder.RenameTable(
                name: "Provinces",
                newName: "Province");

            migrationBuilder.RenameTable(
                name: "PayHistHs",
                newName: "PayHistH");

            migrationBuilder.RenameTable(
                name: "PayHistDs",
                newName: "PayHistD");

            migrationBuilder.RenameTable(
                name: "Members",
                newName: "Member");

            migrationBuilder.RenameTable(
                name: "MasterSequences",
                newName: "MasterSequence");

            migrationBuilder.RenameTable(
                name: "LoanSchemes",
                newName: "LoanScheme");

            migrationBuilder.RenameTable(
                name: "Loans",
                newName: "Loan");

            migrationBuilder.RenameTable(
                name: "LoanPayments",
                newName: "LoanPayment");

            migrationBuilder.RenameTable(
                name: "LoanGuarantees",
                newName: "LoanGuarantee");

            migrationBuilder.RenameTable(
                name: "LoanDocuments",
                newName: "LoanDocument");

            migrationBuilder.RenameTable(
                name: "Jobs",
                newName: "Job");

            migrationBuilder.RenameTable(
                name: "InstalmentSchedules",
                newName: "InstalmentSchedule");

            migrationBuilder.RenameTable(
                name: "DriveFolderMaps",
                newName: "DriveFolderMap");

            migrationBuilder.RenameTable(
                name: "Districts",
                newName: "District");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "City");

            migrationBuilder.RenameTable(
                name: "CashBankTrxes",
                newName: "CashBankTrx");

            migrationBuilder.RenameTable(
                name: "CashBanks",
                newName: "CashBank");

            migrationBuilder.RenameTable(
                name: "CashBankAccounts",
                newName: "CashBankAccount");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address");

            migrationBuilder.RenameIndex(
                name: "IX_SubDistricts_DistrictId",
                table: "SubDistrict",
                newName: "IX_SubDistrict_DistrictId");

            migrationBuilder.RenameIndex(
                name: "IX_ShuAllocationTrxes_ShuAllocationId",
                table: "ShuAllocationTrx",
                newName: "IX_ShuAllocationTrx_ShuAllocationId");

            migrationBuilder.RenameIndex(
                name: "IX_ShuAllocationTrxDists_ShuAllocationTrxId",
                table: "ShuAllocationTrxDist",
                newName: "IX_ShuAllocationTrxDist_ShuAllocationTrxId");

            migrationBuilder.RenameIndex(
                name: "IX_ShuAllocationTrxDists_ShuAllocationId",
                table: "ShuAllocationTrxDist",
                newName: "IX_ShuAllocationTrxDist_ShuAllocationId");

            migrationBuilder.RenameIndex(
                name: "IX_ShuAllocationLoans_ShuAllocationTrxDistId",
                table: "ShuAllocationLoan",
                newName: "IX_ShuAllocationLoan_ShuAllocationTrxDistId");

            migrationBuilder.RenameIndex(
                name: "IX_ShuAllocationLoans_LoanId",
                table: "ShuAllocationLoan",
                newName: "IX_ShuAllocationLoan_LoanId");

            migrationBuilder.RenameIndex(
                name: "IX_SavingTransactions_SavingId",
                table: "SavingTransaction",
                newName: "IX_SavingTransaction_SavingId");

            migrationBuilder.RenameIndex(
                name: "IX_Savings_RefSavingTypeId",
                table: "Saving",
                newName: "IX_Saving_RefSavingTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Savings_MemberId",
                table: "Saving",
                newName: "IX_Saving_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_PayHistDs_PayHistHId",
                table: "PayHistD",
                newName: "IX_PayHistD_PayHistHId");

            migrationBuilder.RenameIndex(
                name: "IX_Loans_MemberId",
                table: "Loan",
                newName: "IX_Loan_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Loans_LoanSchemeId",
                table: "Loan",
                newName: "IX_Loan_LoanSchemeId");

            migrationBuilder.RenameIndex(
                name: "IX_LoanPayments_LoanId",
                table: "LoanPayment",
                newName: "IX_LoanPayment_LoanId");

            migrationBuilder.RenameIndex(
                name: "IX_LoanGuarantees_LoanId",
                table: "LoanGuarantee",
                newName: "IX_LoanGuarantee_LoanId");

            migrationBuilder.RenameIndex(
                name: "IX_LoanDocuments_RefLoanDocumentId",
                table: "LoanDocument",
                newName: "IX_LoanDocument_RefLoanDocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_LoanDocuments_LoanId",
                table: "LoanDocument",
                newName: "IX_LoanDocument_LoanId");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_MemberId",
                table: "Job",
                newName: "IX_Job_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_InstalmentSchedules_LoanId",
                table: "InstalmentSchedule",
                newName: "IX_InstalmentSchedule_LoanId");

            migrationBuilder.RenameIndex(
                name: "IX_Districts_CityId",
                table: "District",
                newName: "IX_District_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_ProvinceId",
                table: "City",
                newName: "IX_City_ProvinceId");

            migrationBuilder.RenameIndex(
                name: "IX_CashBankTrxes_CashBankId",
                table: "CashBankTrx",
                newName: "IX_CashBankTrx_CashBankId");

            migrationBuilder.RenameIndex(
                name: "IX_CashBanks_CashBankAccountId",
                table: "CashBank",
                newName: "IX_CashBank_CashBankAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_SubDistrictId",
                table: "Address",
                newName: "IX_Address_SubDistrictId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_ProvinceId",
                table: "Address",
                newName: "IX_Address_ProvinceId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_MemberId",
                table: "Address",
                newName: "IX_Address_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_DistrictId",
                table: "Address",
                newName: "IX_Address_DistrictId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_CityId",
                table: "Address",
                newName: "IX_Address_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubDistrict",
                table: "SubDistrict",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShuAllocationTrx",
                table: "ShuAllocationTrx",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShuAllocationTrxDist",
                table: "ShuAllocationTrxDist",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShuAllocation",
                table: "ShuAllocation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShuAllocationLoan",
                table: "ShuAllocationLoan",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SavingTransaction",
                table: "SavingTransaction",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Saving",
                table: "Saving",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefSavingType",
                table: "RefSavingType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefMaster",
                table: "RefMaster",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefLoanDocument",
                table: "RefLoanDocument",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Province",
                table: "Province",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PayHistH",
                table: "PayHistH",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PayHistD",
                table: "PayHistD",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Member",
                table: "Member",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MasterSequence",
                table: "MasterSequence",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoanScheme",
                table: "LoanScheme",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Loan",
                table: "Loan",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoanPayment",
                table: "LoanPayment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoanGuarantee",
                table: "LoanGuarantee",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoanDocument",
                table: "LoanDocument",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Job",
                table: "Job",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InstalmentSchedule",
                table: "InstalmentSchedule",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DriveFolderMap",
                table: "DriveFolderMap",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_District",
                table: "District",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CashBankTrx",
                table: "CashBankTrx",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CashBank",
                table: "CashBank",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CashBankAccount",
                table: "CashBankAccount",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_City_CityId",
                table: "Address",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_District_DistrictId",
                table: "Address",
                column: "DistrictId",
                principalTable: "District",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Member_MemberId",
                table: "Address",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Province_ProvinceId",
                table: "Address",
                column: "ProvinceId",
                principalTable: "Province",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_SubDistrict_SubDistrictId",
                table: "Address",
                column: "SubDistrictId",
                principalTable: "SubDistrict",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CashBank_CashBankAccount_CashBankAccountId",
                table: "CashBank",
                column: "CashBankAccountId",
                principalTable: "CashBankAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CashBankTrx_CashBank_CashBankId",
                table: "CashBankTrx",
                column: "CashBankId",
                principalTable: "CashBank",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_City_Province_ProvinceId",
            //    table: "City",
            //    column: "ProvinceId",
            //    principalTable: "Province",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_District_City_CityId",
            //    table: "District",
            //    column: "CityId",
            //    principalTable: "City",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InstalmentSchedule_Loan_LoanId",
                table: "InstalmentSchedule",
                column: "LoanId",
                principalTable: "Loan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Member_MemberId",
                table: "Job",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Loan_LoanScheme_LoanSchemeId",
                table: "Loan",
                column: "LoanSchemeId",
                principalTable: "LoanScheme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Loan_Member_MemberId",
                table: "Loan",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanDocument_Loan_LoanId",
                table: "LoanDocument",
                column: "LoanId",
                principalTable: "Loan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanDocument_RefLoanDocument_RefLoanDocumentId",
                table: "LoanDocument",
                column: "RefLoanDocumentId",
                principalTable: "RefLoanDocument",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanGuarantee_Loan_LoanId",
                table: "LoanGuarantee",
                column: "LoanId",
                principalTable: "Loan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanPayment_Loan_LoanId",
                table: "LoanPayment",
                column: "LoanId",
                principalTable: "Loan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PayHistD_PayHistH_PayHistHId",
                table: "PayHistD",
                column: "PayHistHId",
                principalTable: "PayHistH",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Saving_Member_MemberId",
                table: "Saving",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Saving_RefSavingType_RefSavingTypeId",
                table: "Saving",
                column: "RefSavingTypeId",
                principalTable: "RefSavingType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SavingTransaction_Saving_SavingId",
                table: "SavingTransaction",
                column: "SavingId",
                principalTable: "Saving",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShuAllocationLoan_Loan_LoanId",
                table: "ShuAllocationLoan",
                column: "LoanId",
                principalTable: "Loan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShuAllocationLoan_ShuAllocationTrxDist_ShuAllocationTrxDistId",
                table: "ShuAllocationLoan",
                column: "ShuAllocationTrxDistId",
                principalTable: "ShuAllocationTrxDist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShuAllocationTrx_ShuAllocation_ShuAllocationId",
                table: "ShuAllocationTrx",
                column: "ShuAllocationId",
                principalTable: "ShuAllocation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShuAllocationTrxDist_ShuAllocationTrx_ShuAllocationTrxId",
                table: "ShuAllocationTrxDist",
                column: "ShuAllocationTrxId",
                principalTable: "ShuAllocationTrx",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShuAllocationTrxDist_ShuAllocation_ShuAllocationId",
                table: "ShuAllocationTrxDist",
                column: "ShuAllocationId",
                principalTable: "ShuAllocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_SubDistrict_District_DistrictId",
            //    table: "SubDistrict",
            //    column: "DistrictId",
            //    principalTable: "District",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_City_CityId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_District_DistrictId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Member_MemberId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Province_ProvinceId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_SubDistrict_SubDistrictId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_CashBank_CashBankAccount_CashBankAccountId",
                table: "CashBank");

            migrationBuilder.DropForeignKey(
                name: "FK_CashBankTrx_CashBank_CashBankId",
                table: "CashBankTrx");

            migrationBuilder.DropForeignKey(
                name: "FK_City_Province_ProvinceId",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_District_City_CityId",
                table: "District");

            migrationBuilder.DropForeignKey(
                name: "FK_InstalmentSchedule_Loan_LoanId",
                table: "InstalmentSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_Member_MemberId",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_Loan_LoanScheme_LoanSchemeId",
                table: "Loan");

            migrationBuilder.DropForeignKey(
                name: "FK_Loan_Member_MemberId",
                table: "Loan");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanDocument_Loan_LoanId",
                table: "LoanDocument");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanDocument_RefLoanDocument_RefLoanDocumentId",
                table: "LoanDocument");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanGuarantee_Loan_LoanId",
                table: "LoanGuarantee");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanPayment_Loan_LoanId",
                table: "LoanPayment");

            migrationBuilder.DropForeignKey(
                name: "FK_PayHistD_PayHistH_PayHistHId",
                table: "PayHistD");

            migrationBuilder.DropForeignKey(
                name: "FK_Saving_Member_MemberId",
                table: "Saving");

            migrationBuilder.DropForeignKey(
                name: "FK_Saving_RefSavingType_RefSavingTypeId",
                table: "Saving");

            migrationBuilder.DropForeignKey(
                name: "FK_SavingTransaction_Saving_SavingId",
                table: "SavingTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_ShuAllocationLoan_Loan_LoanId",
                table: "ShuAllocationLoan");

            migrationBuilder.DropForeignKey(
                name: "FK_ShuAllocationLoan_ShuAllocationTrxDist_ShuAllocationTrxDistId",
                table: "ShuAllocationLoan");

            migrationBuilder.DropForeignKey(
                name: "FK_ShuAllocationTrx_ShuAllocation_ShuAllocationId",
                table: "ShuAllocationTrx");

            migrationBuilder.DropForeignKey(
                name: "FK_ShuAllocationTrxDist_ShuAllocationTrx_ShuAllocationTrxId",
                table: "ShuAllocationTrxDist");

            migrationBuilder.DropForeignKey(
                name: "FK_ShuAllocationTrxDist_ShuAllocation_ShuAllocationId",
                table: "ShuAllocationTrxDist");

            migrationBuilder.DropForeignKey(
                name: "FK_SubDistrict_District_DistrictId",
                table: "SubDistrict");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubDistrict",
                table: "SubDistrict");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShuAllocationTrxDist",
                table: "ShuAllocationTrxDist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShuAllocationTrx",
                table: "ShuAllocationTrx");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShuAllocationLoan",
                table: "ShuAllocationLoan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShuAllocation",
                table: "ShuAllocation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SavingTransaction",
                table: "SavingTransaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Saving",
                table: "Saving");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RefSavingType",
                table: "RefSavingType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RefMaster",
                table: "RefMaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RefLoanDocument",
                table: "RefLoanDocument");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Province",
                table: "Province");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PayHistH",
                table: "PayHistH");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PayHistD",
                table: "PayHistD");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Member",
                table: "Member");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MasterSequence",
                table: "MasterSequence");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoanScheme",
                table: "LoanScheme");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoanPayment",
                table: "LoanPayment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoanGuarantee",
                table: "LoanGuarantee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoanDocument",
                table: "LoanDocument");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Loan",
                table: "Loan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Job",
                table: "Job");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InstalmentSchedule",
                table: "InstalmentSchedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DriveFolderMap",
                table: "DriveFolderMap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_District",
                table: "District");

            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                table: "City");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CashBankTrx",
                table: "CashBankTrx");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CashBankAccount",
                table: "CashBankAccount");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CashBank",
                table: "CashBank");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "SubDistrict",
                newName: "SubDistricts");

            migrationBuilder.RenameTable(
                name: "ShuAllocationTrxDist",
                newName: "ShuAllocationTrxDists");

            migrationBuilder.RenameTable(
                name: "ShuAllocationTrx",
                newName: "ShuAllocationTrxes");

            migrationBuilder.RenameTable(
                name: "ShuAllocationLoan",
                newName: "ShuAllocationLoans");

            migrationBuilder.RenameTable(
                name: "ShuAllocation",
                newName: "ShuAllocations");

            migrationBuilder.RenameTable(
                name: "SavingTransaction",
                newName: "SavingTransactions");

            migrationBuilder.RenameTable(
                name: "Saving",
                newName: "Savings");

            migrationBuilder.RenameTable(
                name: "RefSavingType",
                newName: "RefSavingTypes");

            migrationBuilder.RenameTable(
                name: "RefMaster",
                newName: "RefMasters");

            migrationBuilder.RenameTable(
                name: "RefLoanDocument",
                newName: "RefLoanDocuments");

            migrationBuilder.RenameTable(
                name: "Province",
                newName: "Provinces");

            migrationBuilder.RenameTable(
                name: "PayHistH",
                newName: "PayHistHs");

            migrationBuilder.RenameTable(
                name: "PayHistD",
                newName: "PayHistDs");

            migrationBuilder.RenameTable(
                name: "Member",
                newName: "Members");

            migrationBuilder.RenameTable(
                name: "MasterSequence",
                newName: "MasterSequences");

            migrationBuilder.RenameTable(
                name: "LoanScheme",
                newName: "LoanSchemes");

            migrationBuilder.RenameTable(
                name: "LoanPayment",
                newName: "LoanPayments");

            migrationBuilder.RenameTable(
                name: "LoanGuarantee",
                newName: "LoanGuarantees");

            migrationBuilder.RenameTable(
                name: "LoanDocument",
                newName: "LoanDocuments");

            migrationBuilder.RenameTable(
                name: "Loan",
                newName: "Loans");

            migrationBuilder.RenameTable(
                name: "Job",
                newName: "Jobs");

            migrationBuilder.RenameTable(
                name: "InstalmentSchedule",
                newName: "InstalmentSchedules");

            migrationBuilder.RenameTable(
                name: "DriveFolderMap",
                newName: "DriveFolderMaps");

            migrationBuilder.RenameTable(
                name: "District",
                newName: "Districts");

            migrationBuilder.RenameTable(
                name: "City",
                newName: "Cities");

            migrationBuilder.RenameTable(
                name: "CashBankTrx",
                newName: "CashBankTrxes");

            migrationBuilder.RenameTable(
                name: "CashBankAccount",
                newName: "CashBankAccounts");

            migrationBuilder.RenameTable(
                name: "CashBank",
                newName: "CashBanks");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresses");

            migrationBuilder.RenameIndex(
                name: "IX_SubDistrict_DistrictId",
                table: "SubDistricts",
                newName: "IX_SubDistricts_DistrictId");

            migrationBuilder.RenameIndex(
                name: "IX_ShuAllocationTrxDist_ShuAllocationTrxId",
                table: "ShuAllocationTrxDists",
                newName: "IX_ShuAllocationTrxDists_ShuAllocationTrxId");

            migrationBuilder.RenameIndex(
                name: "IX_ShuAllocationTrxDist_ShuAllocationId",
                table: "ShuAllocationTrxDists",
                newName: "IX_ShuAllocationTrxDists_ShuAllocationId");

            migrationBuilder.RenameIndex(
                name: "IX_ShuAllocationTrx_ShuAllocationId",
                table: "ShuAllocationTrxes",
                newName: "IX_ShuAllocationTrxes_ShuAllocationId");

            migrationBuilder.RenameIndex(
                name: "IX_ShuAllocationLoan_ShuAllocationTrxDistId",
                table: "ShuAllocationLoans",
                newName: "IX_ShuAllocationLoans_ShuAllocationTrxDistId");

            migrationBuilder.RenameIndex(
                name: "IX_ShuAllocationLoan_LoanId",
                table: "ShuAllocationLoans",
                newName: "IX_ShuAllocationLoans_LoanId");

            migrationBuilder.RenameIndex(
                name: "IX_SavingTransaction_SavingId",
                table: "SavingTransactions",
                newName: "IX_SavingTransactions_SavingId");

            migrationBuilder.RenameIndex(
                name: "IX_Saving_RefSavingTypeId",
                table: "Savings",
                newName: "IX_Savings_RefSavingTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Saving_MemberId",
                table: "Savings",
                newName: "IX_Savings_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_PayHistD_PayHistHId",
                table: "PayHistDs",
                newName: "IX_PayHistDs_PayHistHId");

            migrationBuilder.RenameIndex(
                name: "IX_LoanPayment_LoanId",
                table: "LoanPayments",
                newName: "IX_LoanPayments_LoanId");

            migrationBuilder.RenameIndex(
                name: "IX_LoanGuarantee_LoanId",
                table: "LoanGuarantees",
                newName: "IX_LoanGuarantees_LoanId");

            migrationBuilder.RenameIndex(
                name: "IX_LoanDocument_RefLoanDocumentId",
                table: "LoanDocuments",
                newName: "IX_LoanDocuments_RefLoanDocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_LoanDocument_LoanId",
                table: "LoanDocuments",
                newName: "IX_LoanDocuments_LoanId");

            migrationBuilder.RenameIndex(
                name: "IX_Loan_MemberId",
                table: "Loans",
                newName: "IX_Loans_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Loan_LoanSchemeId",
                table: "Loans",
                newName: "IX_Loans_LoanSchemeId");

            migrationBuilder.RenameIndex(
                name: "IX_Job_MemberId",
                table: "Jobs",
                newName: "IX_Jobs_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_InstalmentSchedule_LoanId",
                table: "InstalmentSchedules",
                newName: "IX_InstalmentSchedules_LoanId");

            migrationBuilder.RenameIndex(
                name: "IX_District_CityId",
                table: "Districts",
                newName: "IX_Districts_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_City_ProvinceId",
                table: "Cities",
                newName: "IX_Cities_ProvinceId");

            migrationBuilder.RenameIndex(
                name: "IX_CashBankTrx_CashBankId",
                table: "CashBankTrxes",
                newName: "IX_CashBankTrxes_CashBankId");

            migrationBuilder.RenameIndex(
                name: "IX_CashBank_CashBankAccountId",
                table: "CashBanks",
                newName: "IX_CashBanks_CashBankAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_SubDistrictId",
                table: "Addresses",
                newName: "IX_Addresses_SubDistrictId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_ProvinceId",
                table: "Addresses",
                newName: "IX_Addresses_ProvinceId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_MemberId",
                table: "Addresses",
                newName: "IX_Addresses_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_DistrictId",
                table: "Addresses",
                newName: "IX_Addresses_DistrictId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_CityId",
                table: "Addresses",
                newName: "IX_Addresses_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubDistricts",
                table: "SubDistricts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShuAllocationTrxDists",
                table: "ShuAllocationTrxDists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShuAllocationTrxes",
                table: "ShuAllocationTrxes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShuAllocationLoans",
                table: "ShuAllocationLoans",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShuAllocations",
                table: "ShuAllocations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SavingTransactions",
                table: "SavingTransactions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Savings",
                table: "Savings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefSavingTypes",
                table: "RefSavingTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefMasters",
                table: "RefMasters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefLoanDocuments",
                table: "RefLoanDocuments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Provinces",
                table: "Provinces",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PayHistHs",
                table: "PayHistHs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PayHistDs",
                table: "PayHistDs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Members",
                table: "Members",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MasterSequences",
                table: "MasterSequences",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoanSchemes",
                table: "LoanSchemes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoanPayments",
                table: "LoanPayments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoanGuarantees",
                table: "LoanGuarantees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoanDocuments",
                table: "LoanDocuments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Loans",
                table: "Loans",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InstalmentSchedules",
                table: "InstalmentSchedules",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DriveFolderMaps",
                table: "DriveFolderMaps",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Districts",
                table: "Districts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CashBankTrxes",
                table: "CashBankTrxes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CashBankAccounts",
                table: "CashBankAccounts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CashBanks",
                table: "CashBanks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Cities_CityId",
                table: "Addresses",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Districts_DistrictId",
                table: "Addresses",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Members_MemberId",
                table: "Addresses",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Provinces_ProvinceId",
                table: "Addresses",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_SubDistricts_SubDistrictId",
                table: "Addresses",
                column: "SubDistrictId",
                principalTable: "SubDistricts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CashBanks_CashBankAccounts_CashBankAccountId",
                table: "CashBanks",
                column: "CashBankAccountId",
                principalTable: "CashBankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CashBankTrxes_CashBanks_CashBankId",
                table: "CashBankTrxes",
                column: "CashBankId",
                principalTable: "CashBanks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Cities_Provinces_ProvinceId",
            //    table: "Cities",
            //    column: "ProvinceId",
            //    principalTable: "Provinces",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Districts_Cities_CityId",
                table: "Districts",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InstalmentSchedules_Loans_LoanId",
                table: "InstalmentSchedules",
                column: "LoanId",
                principalTable: "Loans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Members_MemberId",
                table: "Jobs",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanDocuments_Loans_LoanId",
                table: "LoanDocuments",
                column: "LoanId",
                principalTable: "Loans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanDocuments_RefLoanDocuments_RefLoanDocumentId",
                table: "LoanDocuments",
                column: "RefLoanDocumentId",
                principalTable: "RefLoanDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanGuarantees_Loans_LoanId",
                table: "LoanGuarantees",
                column: "LoanId",
                principalTable: "Loans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanPayments_Loans_LoanId",
                table: "LoanPayments",
                column: "LoanId",
                principalTable: "Loans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_LoanSchemes_LoanSchemeId",
                table: "Loans",
                column: "LoanSchemeId",
                principalTable: "LoanSchemes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Members_MemberId",
                table: "Loans",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PayHistDs_PayHistHs_PayHistHId",
                table: "PayHistDs",
                column: "PayHistHId",
                principalTable: "PayHistHs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Savings_Members_MemberId",
                table: "Savings",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Savings_RefSavingTypes_RefSavingTypeId",
                table: "Savings",
                column: "RefSavingTypeId",
                principalTable: "RefSavingTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SavingTransactions_Savings_SavingId",
                table: "SavingTransactions",
                column: "SavingId",
                principalTable: "Savings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShuAllocationLoans_Loans_LoanId",
                table: "ShuAllocationLoans",
                column: "LoanId",
                principalTable: "Loans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShuAllocationLoans_ShuAllocationTrxDists_ShuAllocationTrxDistId",
                table: "ShuAllocationLoans",
                column: "ShuAllocationTrxDistId",
                principalTable: "ShuAllocationTrxDists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShuAllocationTrxDists_ShuAllocationTrxes_ShuAllocationTrxId",
                table: "ShuAllocationTrxDists",
                column: "ShuAllocationTrxId",
                principalTable: "ShuAllocationTrxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShuAllocationTrxDists_ShuAllocations_ShuAllocationId",
                table: "ShuAllocationTrxDists",
                column: "ShuAllocationId",
                principalTable: "ShuAllocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShuAllocationTrxes_ShuAllocations_ShuAllocationId",
                table: "ShuAllocationTrxes",
                column: "ShuAllocationId",
                principalTable: "ShuAllocations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubDistricts_Districts_DistrictId",
                table: "SubDistricts",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
