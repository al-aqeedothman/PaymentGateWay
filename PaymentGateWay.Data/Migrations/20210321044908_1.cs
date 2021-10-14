using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentGateWay.Data.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attachment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedById = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedById = table.Column<long>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    FileType = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    OriginalFileName = table.Column<string>(nullable: true),
                    PhysicalFileName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessType",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IndiviualAccount",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedById = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedById = table.Column<long>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    ContactName = table.Column<string>(maxLength: 100, nullable: false),
                    ContactPhone = table.Column<string>(maxLength: 100, nullable: false),
                    Balance = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndiviualAccount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionType",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserStatus",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyAccount",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedById = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedById = table.Column<long>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    ContactName = table.Column<string>(maxLength: 100, nullable: false),
                    ContactPhone = table.Column<string>(maxLength: 100, nullable: false),
                    Balance = table.Column<double>(nullable: false),
                    BusinessId = table.Column<long>(nullable: false),
                    BusinessTypeId = table.Column<long>(nullable: false),
                    BusinessCertificationId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyAccount_Attachment_BusinessCertificationId",
                        column: x => x.BusinessCertificationId,
                        principalTable: "Attachment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyAccount_BusinessType_BusinessTypeId",
                        column: x => x.BusinessTypeId,
                        principalTable: "BusinessType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedById = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedById = table.Column<long>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    LoginName = table.Column<string>(maxLength: 100, nullable: false),
                    UserTypeId = table.Column<long>(nullable: false),
                    Password = table.Column<string>(maxLength: 100, nullable: false),
                    UserStatusId = table.Column<long>(nullable: false),
                    IndiviualAccountId = table.Column<long>(nullable: true),
                    CompanyAccountId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_CompanyAccount_CompanyAccountId",
                        column: x => x.CompanyAccountId,
                        principalTable: "CompanyAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_IndiviualAccount_IndiviualAccountId",
                        column: x => x.IndiviualAccountId,
                        principalTable: "IndiviualAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_UserStatus_UserStatusId",
                        column: x => x.UserStatusId,
                        principalTable: "UserStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_UserType_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "UserType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedById = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedById = table.Column<long>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    TransactionTypeId = table.Column<long>(nullable: false),
                    Amount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transaction_TransactionType_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalTable: "TransactionType",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "BusinessType",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { 1L, "Partnership" },
                    { 2L, "Corporation" },
                    { 3L, "Nonprofit Organization" }
                });

            migrationBuilder.InsertData(
                table: "TransactionType",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { 1L, "withdrawal" },
                    { 2L, "Refund" },
                    { 3L, "Pay" }
                });

            migrationBuilder.InsertData(
                table: "UserStatus",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { 1L, "Active" },
                    { 2L, "inactive" },
                    { 3L, "pending" }
                });

            migrationBuilder.InsertData(
                table: "UserType",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { 1L, "SystemAdmin" },
                    { 2L, "individual" },
                    { 3L, "company" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CompanyAccountId", "CreatedById", "CreatedDate", "IndiviualAccountId", "LoginName", "Password", "UpdatedById", "UpdatedDate", "UserStatusId", "UserTypeId" },
                values: new object[] { 1L, null, null, null, null, "superAdmin", "/e9LCZCv0OnYEC/ggb3KFQ==:::g6a5JtXuBrRM9Elw7LCT9y+yzsdbZRbb0eg3ztnwWSI=", null, null, 1L, 1L });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAccount_BusinessCertificationId",
                table: "CompanyAccount",
                column: "BusinessCertificationId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAccount_BusinessTypeId",
                table: "CompanyAccount",
                column: "BusinessTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_CreatedById",
                table: "Transaction",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_TransactionTypeId",
                table: "Transaction",
                column: "TransactionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CompanyAccountId",
                table: "User",
                column: "CompanyAccountId",
                unique: true,
                filter: "[CompanyAccountId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_User_IndiviualAccountId",
                table: "User",
                column: "IndiviualAccountId",
                unique: true,
                filter: "[IndiviualAccountId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserStatusId",
                table: "User",
                column: "UserStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserTypeId",
                table: "User",
                column: "UserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_User_IndiviualAccountId_CompanyAccountId",
                table: "User",
                columns: new[] { "IndiviualAccountId", "CompanyAccountId" },
                unique: true,
                filter: "[IndiviualAccountId] IS NOT NULL AND [CompanyAccountId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "TransactionType");

            migrationBuilder.DropTable(
                name: "CompanyAccount");

            migrationBuilder.DropTable(
                name: "IndiviualAccount");

            migrationBuilder.DropTable(
                name: "UserStatus");

            migrationBuilder.DropTable(
                name: "UserType");

            migrationBuilder.DropTable(
                name: "Attachment");

            migrationBuilder.DropTable(
                name: "BusinessType");
        }
    }
}
