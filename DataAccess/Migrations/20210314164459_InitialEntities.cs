using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class InitialEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ReportId = table.Column<Guid>(nullable: false),
                    RequestDate = table.Column<DateTime>(nullable: false),
                    State = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.ReportId);
                });

            migrationBuilder.CreateTable(
                name: "ContactInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InfoType = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ContactId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactInfos_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "ContactId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    NumberOfPeople = table.Column<int>(nullable: false),
                    NumberOfPhone = table.Column<int>(nullable: false),
                    ReportId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportDetails_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "ReportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "Company", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("632b7eb3-4fc3-4e4a-9c84-c772636d4958"), "Turkcell", "Mehmet", "Sağlam" },
                    { new Guid("1f3a7bab-e51f-4198-a0a0-4a1632e90d67"), "Vodafone", "Ahmet", "Atay" },
                    { new Guid("9c7feca6-d91a-485e-ac99-4e7c2b9c7277"), "Turkcell", "Hande", "Güneş" },
                    { new Guid("7e74cf3c-c47c-46c6-8372-2f97eed167ba"), "TurkTelekom", "Leyla", "Güzel" },
                    { new Guid("957dcbf5-e531-4ac0-924d-5ce85ca1545a"), "Turkcell", "Arif", "Dertsiz" }
                });

            migrationBuilder.InsertData(
                table: "ContactInfos",
                columns: new[] { "Id", "ContactId", "Description", "InfoType" },
                values: new object[,]
                {
                    { new Guid("ae854b10-5327-452a-aec1-bcc13d4e5796"), new Guid("632b7eb3-4fc3-4e4a-9c84-c772636d4958"), "İstanbul", "Location" },
                    { new Guid("b310d6cd-2e42-4755-9cb5-1e6a726b81f1"), new Guid("632b7eb3-4fc3-4e4a-9c84-c772636d4958"), "090555445566", "Phone" },
                    { new Guid("a3d84f56-15bc-45a5-85fe-7335bcfefd51"), new Guid("632b7eb3-4fc3-4e4a-9c84-c772636d4958"), "mehmet.saglam@turkcell.com", "Email" },
                    { new Guid("617c4f00-20fb-47e8-bc5a-a537c191134d"), new Guid("1f3a7bab-e51f-4198-a0a0-4a1632e90d67"), "Ankara", "Location" },
                    { new Guid("30f8a76a-54a6-4194-af0e-573245429a85"), new Guid("1f3a7bab-e51f-4198-a0a0-4a1632e90d67"), "905449998877", "Phone" },
                    { new Guid("2ba68125-ff2a-412e-bc07-ff3910aa5c42"), new Guid("1f3a7bab-e51f-4198-a0a0-4a1632e90d67"), "ahmet.atay@vodafone.com", "Email" },
                    { new Guid("dc0aaa1b-a795-435c-b40c-f72b1a86396e"), new Guid("9c7feca6-d91a-485e-ac99-4e7c2b9c7277"), "Ankara", "Location" },
                    { new Guid("518a6d4e-9642-4b24-abfb-f6b2745413f4"), new Guid("9c7feca6-d91a-485e-ac99-4e7c2b9c7277"), "905438789977", "Phone" },
                    { new Guid("c9661670-8403-4df6-a171-4dbdc68cccd5"), new Guid("7e74cf3c-c47c-46c6-8372-2f97eed167ba"), "İzmir", "Location" },
                    { new Guid("ffe99b57-8c31-4f2a-9504-d7e7acc86d59"), new Guid("957dcbf5-e531-4ac0-924d-5ce85ca1545a"), "arif.dertsiz@turkcell.com", "Email" },
                    { new Guid("5169a796-f9ce-4653-9395-b7bd5ab01703"), new Guid("957dcbf5-e531-4ac0-924d-5ce85ca1545a"), "İzmir", "Location" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfos_ContactId",
                table: "ContactInfos",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportDetails_ReportId",
                table: "ReportDetails",
                column: "ReportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactInfos");

            migrationBuilder.DropTable(
                name: "ReportDetails");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Reports");
        }
    }
}
