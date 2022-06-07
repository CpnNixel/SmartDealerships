using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartDealerships.DataAccess.Migrations
{
    public partial class AddedUserEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 6, 7, 19, 2, 35, 272, DateTimeKind.Utc).AddTicks(932), new DateTime(2022, 6, 7, 19, 2, 35, 272, DateTimeKind.Utc).AddTicks(974) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 6, 7, 19, 2, 35, 272, DateTimeKind.Utc).AddTicks(981), new DateTime(2022, 6, 7, 19, 2, 35, 272, DateTimeKind.Utc).AddTicks(984) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 6, 5, 23, 5, 45, 619, DateTimeKind.Utc).AddTicks(4452), new DateTime(2022, 6, 5, 23, 5, 45, 619, DateTimeKind.Utc).AddTicks(4499) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 6, 5, 23, 5, 45, 619, DateTimeKind.Utc).AddTicks(4506), new DateTime(2022, 6, 5, 23, 5, 45, 619, DateTimeKind.Utc).AddTicks(4509) });
        }
    }
}
