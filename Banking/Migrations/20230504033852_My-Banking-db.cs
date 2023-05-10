using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Banking.Migrations
{
    public partial class MyBankingdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bank",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bank_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Branch_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IFSC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact_Number = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pincode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "bankloan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Interest_Rate = table.Column<float>(type: "real", nullable: false),
                    Loan_Tenure = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bankloan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cibil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aadhar_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CIBIL_year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CIBIL_Score = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cibil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Last_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    age = table.Column<float>(type: "real", nullable: false),
                    Mobile_Number = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aadhar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pincode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Account_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Account_Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankCustomer",
                columns: table => new
                {
                    CustomerdetailsId = table.Column<int>(type: "int", nullable: false),
                    banksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankCustomer", x => new { x.CustomerdetailsId, x.banksId });
                    table.ForeignKey(
                        name: "FK_BankCustomer_bank_banksId",
                        column: x => x.banksId,
                        principalTable: "bank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BankCustomer_Customer_CustomerdetailsId",
                        column: x => x.CustomerdetailsId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "customer_Banks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankId = table.Column<int>(type: "int", nullable: false),
                    customerId = table.Column<int>(type: "int", nullable: false),
                    BankLoanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_Banks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_customer_Banks_bank_BankId",
                        column: x => x.BankId,
                        principalTable: "bank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_customer_Banks_bankloan_BankLoanId",
                        column: x => x.BankLoanId,
                        principalTable: "bankloan",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_customer_Banks_Customer_customerId",
                        column: x => x.customerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "loanDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Loan_Amount = table.Column<float>(type: "real", nullable: false),
                    Loan_Provided = table.Column<DateTime>(type: "datetime2", nullable: false),
                    payment_Mode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loanDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_loanDetail_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "customer_LoanDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CsutomerId = table.Column<int>(type: "int", nullable: false),
                    LoanDetailsDemoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_LoanDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_customer_LoanDetails_Customer_CsutomerId",
                        column: x => x.CsutomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_customer_LoanDetails_loanDetail_LoanDetailsDemoId",
                        column: x => x.LoanDetailsDemoId,
                        principalTable: "loanDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "loan_loanDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankLoanId = table.Column<int>(type: "int", nullable: false),
                    LoanDetailsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loan_loanDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_loan_loanDetails_bankloan_BankLoanId",
                        column: x => x.BankLoanId,
                        principalTable: "bankloan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_loan_loanDetails_loanDetail_LoanDetailsId",
                        column: x => x.LoanDetailsId,
                        principalTable: "loanDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankCustomer_banksId",
                table: "BankCustomer",
                column: "banksId");

            migrationBuilder.CreateIndex(
                name: "IX_customer_Banks_BankId",
                table: "customer_Banks",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_customer_Banks_BankLoanId",
                table: "customer_Banks",
                column: "BankLoanId");

            migrationBuilder.CreateIndex(
                name: "IX_customer_Banks_customerId",
                table: "customer_Banks",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_customer_LoanDetails_CsutomerId",
                table: "customer_LoanDetails",
                column: "CsutomerId");

            migrationBuilder.CreateIndex(
                name: "IX_customer_LoanDetails_LoanDetailsDemoId",
                table: "customer_LoanDetails",
                column: "LoanDetailsDemoId");

            migrationBuilder.CreateIndex(
                name: "IX_loan_loanDetails_BankLoanId",
                table: "loan_loanDetails",
                column: "BankLoanId");

            migrationBuilder.CreateIndex(
                name: "IX_loan_loanDetails_LoanDetailsId",
                table: "loan_loanDetails",
                column: "LoanDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_loanDetail_CustomerId",
                table: "loanDetail",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankCustomer");

            migrationBuilder.DropTable(
                name: "cibil");

            migrationBuilder.DropTable(
                name: "customer_Banks");

            migrationBuilder.DropTable(
                name: "customer_LoanDetails");

            migrationBuilder.DropTable(
                name: "loan_loanDetails");

            migrationBuilder.DropTable(
                name: "bank");

            migrationBuilder.DropTable(
                name: "bankloan");

            migrationBuilder.DropTable(
                name: "loanDetail");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
