using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartDealerships.DataAccess.Migrations
{
    public partial class FixedSomeModels3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 6, 10, 2, 12, 8, 589, DateTimeKind.Utc).AddTicks(7411), new DateTime(2022, 6, 10, 2, 12, 8, 589, DateTimeKind.Utc).AddTicks(7462) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 6, 10, 2, 12, 8, 589, DateTimeKind.Utc).AddTicks(7473), new DateTime(2022, 6, 10, 2, 12, 8, 589, DateTimeKind.Utc).AddTicks(7478) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
