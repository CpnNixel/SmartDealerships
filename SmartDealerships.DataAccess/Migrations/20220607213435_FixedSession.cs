using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartDealerships.DataAccess.Migrations
{
    public partial class FixedSession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingSessions_Users_UserId",
                table: "ShoppingSessions");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingSessions_UserId",
                table: "ShoppingSessions");

            migrationBuilder.AddColumn<int>(
                name: "ShoppingSessionId",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ShoppingSessions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 6, 8, 0, 34, 35, 67, DateTimeKind.Utc).AddTicks(5700), new DateTime(2022, 6, 8, 0, 34, 35, 67, DateTimeKind.Utc).AddTicks(5768) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 6, 8, 0, 34, 35, 67, DateTimeKind.Utc).AddTicks(5778), new DateTime(2022, 6, 8, 0, 34, 35, 67, DateTimeKind.Utc).AddTicks(5784) });

            migrationBuilder.CreateIndex(
                name: "IX_Users_ShoppingSessionId",
                table: "Users",
                column: "ShoppingSessionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_ShoppingSessions_ShoppingSessionId",
                table: "Users",
                column: "ShoppingSessionId",
                principalTable: "ShoppingSessions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_ShoppingSessions_ShoppingSessionId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ShoppingSessionId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ShoppingSessionId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ShoppingSessions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 6, 7, 23, 44, 19, 314, DateTimeKind.Utc).AddTicks(3929), new DateTime(2022, 6, 7, 23, 44, 19, 314, DateTimeKind.Utc).AddTicks(4005) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 6, 7, 23, 44, 19, 314, DateTimeKind.Utc).AddTicks(4014), new DateTime(2022, 6, 7, 23, 44, 19, 314, DateTimeKind.Utc).AddTicks(4019) });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingSessions_UserId",
                table: "ShoppingSessions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingSessions_Users_UserId",
                table: "ShoppingSessions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
