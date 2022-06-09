using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartDealerships.DataAccess.Migrations
{
    public partial class AddedRequiredEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Email", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 6, 7, 19, 36, 14, 474, DateTimeKind.Utc).AddTicks(6110), "john.doe@gmail.com", new DateTime(2022, 6, 7, 19, 36, 14, 474, DateTimeKind.Utc).AddTicks(6150) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Email", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 6, 7, 19, 36, 14, 474, DateTimeKind.Utc).AddTicks(6157), "mykyta.kysil@nure.ua", new DateTime(2022, 6, 7, 19, 36, 14, 474, DateTimeKind.Utc).AddTicks(6161) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Email", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 6, 7, 19, 2, 35, 272, DateTimeKind.Utc).AddTicks(932), null, new DateTime(2022, 6, 7, 19, 2, 35, 272, DateTimeKind.Utc).AddTicks(974) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Email", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 6, 7, 19, 2, 35, 272, DateTimeKind.Utc).AddTicks(981), null, new DateTime(2022, 6, 7, 19, 2, 35, 272, DateTimeKind.Utc).AddTicks(984) });
        }
    }
}
