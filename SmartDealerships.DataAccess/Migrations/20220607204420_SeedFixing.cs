using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartDealerships.DataAccess.Migrations
{
    public partial class SeedFixing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Email", "ModifiedAt", "RoleId" },
                values: new object[] { new DateTime(2022, 6, 7, 23, 44, 19, 314, DateTimeKind.Utc).AddTicks(3929), "john.doe@gmail.com", new DateTime(2022, 6, 7, 23, 44, 19, 314, DateTimeKind.Utc).AddTicks(4005), 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt", "RoleId" },
                values: new object[] { new DateTime(2022, 6, 7, 23, 44, 19, 314, DateTimeKind.Utc).AddTicks(4014), new DateTime(2022, 6, 7, 23, 44, 19, 314, DateTimeKind.Utc).AddTicks(4019), 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Email", "ModifiedAt", "RoleId" },
                values: new object[] { new DateTime(2022, 6, 7, 23, 28, 15, 442, DateTimeKind.Utc).AddTicks(8089), "am9obmRvZTI0MTA=", new DateTime(2022, 6, 7, 23, 28, 15, 442, DateTimeKind.Utc).AddTicks(8149), 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt", "RoleId" },
                values: new object[] { new DateTime(2022, 6, 7, 23, 28, 15, 442, DateTimeKind.Utc).AddTicks(8160), new DateTime(2022, 6, 7, 23, 28, 15, 442, DateTimeKind.Utc).AddTicks(8165), 1 });
        }
    }
}
