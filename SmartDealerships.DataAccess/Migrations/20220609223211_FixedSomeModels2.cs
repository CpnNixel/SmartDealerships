using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartDealerships.DataAccess.Migrations
{
    public partial class FixedSomeModels2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "CartItems",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 6, 10, 1, 32, 10, 711, DateTimeKind.Utc).AddTicks(5589), new DateTime(2022, 6, 10, 1, 32, 10, 711, DateTimeKind.Utc).AddTicks(5631) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 6, 10, 1, 32, 10, 711, DateTimeKind.Utc).AddTicks(5638), new DateTime(2022, 6, 10, 1, 32, 10, 711, DateTimeKind.Utc).AddTicks(5642) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "CartItems");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 6, 10, 0, 33, 0, 594, DateTimeKind.Utc).AddTicks(28), new DateTime(2022, 6, 10, 0, 33, 0, 594, DateTimeKind.Utc).AddTicks(86) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 6, 10, 0, 33, 0, 594, DateTimeKind.Utc).AddTicks(95), new DateTime(2022, 6, 10, 0, 33, 0, 594, DateTimeKind.Utc).AddTicks(100) });
        }
    }
}
