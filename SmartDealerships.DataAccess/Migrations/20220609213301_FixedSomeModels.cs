using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartDealerships.DataAccess.Migrations
{
    public partial class FixedSomeModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "CartItems");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "CartItems",
                type: "integer",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "CartItems");

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "CartItems",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 6, 9, 21, 53, 58, 653, DateTimeKind.Utc).AddTicks(9211), new DateTime(2022, 6, 9, 21, 53, 58, 653, DateTimeKind.Utc).AddTicks(9255) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 6, 9, 21, 53, 58, 653, DateTimeKind.Utc).AddTicks(9262), new DateTime(2022, 6, 9, 21, 53, 58, 653, DateTimeKind.Utc).AddTicks(9265) });
        }
    }
}
