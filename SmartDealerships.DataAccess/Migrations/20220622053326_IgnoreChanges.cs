using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartDealerships.DataAccess.Migrations
{
    public partial class IgnoreChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageLink",
                table: "Products",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 6, 22, 8, 33, 26, 456, DateTimeKind.Utc).AddTicks(1503), new DateTime(2022, 6, 22, 8, 33, 26, 456, DateTimeKind.Utc).AddTicks(1533) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 6, 22, 8, 33, 26, 456, DateTimeKind.Utc).AddTicks(1536), new DateTime(2022, 6, 22, 8, 33, 26, 456, DateTimeKind.Utc).AddTicks(1538) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageLink",
                table: "Products",
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
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 6, 22, 8, 29, 7, 908, DateTimeKind.Utc).AddTicks(7493), new DateTime(2022, 6, 22, 8, 29, 7, 908, DateTimeKind.Utc).AddTicks(7526) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 6, 22, 8, 29, 7, 908, DateTimeKind.Utc).AddTicks(7531), new DateTime(2022, 6, 22, 8, 29, 7, 908, DateTimeKind.Utc).AddTicks(7533) });
        }
    }
}
