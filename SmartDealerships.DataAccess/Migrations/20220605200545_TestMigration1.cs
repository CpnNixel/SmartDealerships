using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartDealerships.DataAccess.Migrations
{
    public partial class TestMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedAt", "FirstName", "LastName", "ModifiedAt", "PasswordHash", "Telephone" },
                values: new object[,]
                {
                    { 1, "Kharkiv city, Buchmy 50", new DateTime(2022, 6, 5, 23, 5, 45, 619, DateTimeKind.Utc).AddTicks(4452), "John", "Doe", new DateTime(2022, 6, 5, 23, 5, 45, 619, DateTimeKind.Utc).AddTicks(4499), "am9obmRvZTI0MTAK", "380662016" },
                    { 2, "Pervomaiskiy", new DateTime(2022, 6, 5, 23, 5, 45, 619, DateTimeKind.Utc).AddTicks(4506), "Mykyta", "Kysil", new DateTime(2022, 6, 5, 23, 5, 45, 619, DateTimeKind.Utc).AddTicks(4509), "MTIwOTE5OTMK", "0662016521" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
