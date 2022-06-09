using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SmartDealerships.DataAccess.Migrations
{
    public partial class AddedCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Companies");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ShoppingSessions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "LogoImage",
                table: "Companies",
                type: "bytea",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Spare parts" },
                    { 2, "Fuel filtes" },
                    { 3, "Battery" },
                    { 4, "Brake pads" },
                    { 5, "Brake rotor" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Description", "LogoImage", "Name" },
                values: new object[] { 1, "", null, "Truck shop" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 6, 9, 21, 45, 29, 151, DateTimeKind.Utc).AddTicks(4411), new DateTime(2022, 6, 9, 21, 45, 29, 151, DateTimeKind.Utc).AddTicks(4455) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 6, 9, 21, 45, 29, 151, DateTimeKind.Utc).AddTicks(4461), new DateTime(2022, 6, 9, 21, 45, 29, 151, DateTimeKind.Utc).AddTicks(4464) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CompanyId", "Description", "Name", "Price", "Sku" },
                values: new object[,]
                {
                    { 1, 4, 1, "Brakes squealing? Are you experiencing longer stopping distances? Get reliable, everyday performance for regular driving needs from Duralast brake pads, designed to meet your vehicles original equipment for form, fit, and function. Available only at AutoZone, Duralast brake pads use platform-specific, semi-metallic friction materials tailored to your vehicle. Replace rotors and hardware when replacing brake pads for better performance and less noise.", "Duralast Ceramic Brake Pads", 300.5m, "MKD503" },
                    { 2, 4, 1, "Brakes squealing? Are you experiencing longer stopping distances? Get reliable, everyday performance for regular driving needs from Duralast brake pads, designed to meet your vehicles original equipment for form, fit, and function. Available only at AutoZone, Duralast brake pads use platform-specific, semi-metallic friction materials tailored to your vehicle. Replace rotors and hardware when replacing brake pads for better performance and less noise.", "Duralast Ceramic Brake Pads D924", 36.99m, "D924" },
                    { 3, 4, 1, "Brakes squealing? Are you experiencing longer stopping distances? Get reliable, everyday performance for regular driving needs from Duralast brake pads, designed to meet your vehicles original equipment for form, fit, and function. Available only at AutoZone, Duralast brake pads use platform-specific, semi-metallic friction materials tailored to your vehicle. Replace rotors and hardware when replacing brake pads for better performance and less noise.", "Duralast Ceramic Brake Pads D1339", 44.49m, "D1339" },
                    { 4, 5, 1, "Engineered to properly remove heat from the brake system,OE compliance for equal or better rotor performance, reduced pulsation, and noise.", "Duralast Brake Rotor 31069", 59.99m, "31069" },
                    { 5, 5, 1, "Engineered to properly remove heat from the brake system,OE compliance for equal or better rotor performance, reduced pulsation, and noise.", "Duralast Brake Rotor 55097", 89.99m, "55097" },
                    { 6, 5, 1, "Engineered to properly remove heat from the brake system,OE compliance for equal or better rotor performance, reduced pulsation, and noise.", "Duralast Brake Rotor 55072DL", 79.99m, "55072DL" },
                    { 7, 5, 1, "Duralast® brand disc brake rotors are designed and engineered to match J431 and your vehicles original equipment performance. Our Duralast® rotors can replace your OE parts with no change in performance and safety. So when you need a part you can trust at a price you can afford.", "Duralast Brake Rotor 5333", 97.99m, "55072DL" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LogoImage",
                table: "Companies");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ShoppingSessions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Companies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 6, 8, 2, 9, 43, 242, DateTimeKind.Utc).AddTicks(1552), new DateTime(2022, 6, 8, 2, 9, 43, 242, DateTimeKind.Utc).AddTicks(1602) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2022, 6, 8, 2, 9, 43, 242, DateTimeKind.Utc).AddTicks(1613), new DateTime(2022, 6, 8, 2, 9, 43, 242, DateTimeKind.Utc).AddTicks(1618) });
        }
    }
}
