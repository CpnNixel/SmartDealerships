using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartDealerships.DataAccess.Migrations
{
    public partial class AddedImageLinkToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageLink",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageLink",
                value: "https://db73q1dut0rlp.cloudfront.net/eyJ3aWR0aCI6NDM1LCJoZWlnaHQiOjQzNSwiZml0IjoiY29udGFpbiIsIndhdGVybWFya2VkIjp0cnVlLCJmb3JtYXQiOiJ3ZWJwIiwia2V5IjoiYXNzZXRzL2ltYWdlcy8xMDQ4NzU2NS9wcm9kdWN0LzU3ZGM5ZGY4Y2E4NTJhZGQ3NTZkOWU4Njg5NmFlZWEyLmpwZyIsInZlcnNpb24iOjJ9.webp?s=f17c9f283b640e18c3ccad87a5897582e9c42a0198361b93ce344dbc66d9f67a");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageLink",
                value: "https://db73q1dut0rlp.cloudfront.net/eyJ3aWR0aCI6NDM1LCJoZWlnaHQiOjQzNSwiZml0IjoiY29udGFpbiIsIndhdGVybWFya2VkIjp0cnVlLCJmb3JtYXQiOiJ3ZWJwIiwia2V5IjoiYXNzZXRzL2ltYWdlcy83Njc5MjEwL3Byb2R1Y3QvYjEwZTdhOTJiMjU2N2YwNjkxODllOGQwMDY1ZDZmZTIuanBnIiwidmVyc2lvbiI6Mn0=.webp?s=d99aa90b79e4f9fe43889b808046b776d1bfc3cbacf7f12259179419df90d73b");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageLink",
                value: "https://db73q1dut0rlp.cloudfront.net/eyJ3aWR0aCI6NDM1LCJoZWlnaHQiOjQzNSwiZml0IjoiY29udGFpbiIsIndhdGVybWFya2VkIjp0cnVlLCJmb3JtYXQiOiJ3ZWJwIiwia2V5IjoiYXNzZXRzL2ltYWdlcy8xMDQ4NzU2NS9wcm9kdWN0LzU3ZGM5ZGY4Y2E4NTJhZGQ3NTZkOWU4Njg5NmFlZWEyLmpwZyIsInZlcnNpb24iOjJ9.webp?s=f17c9f283b640e18c3ccad87a5897582e9c42a0198361b93ce344dbc66d9f67a");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageLink",
                value: "https://db73q1dut0rlp.cloudfront.net/eyJ3aWR0aCI6NDM1LCJoZWlnaHQiOjQzNSwiZml0IjoiY29udGFpbiIsIndhdGVybWFya2VkIjp0cnVlLCJmb3JtYXQiOiJ3ZWJwIiwia2V5IjoiYXNzZXRzL2ltYWdlcy84MjQyNzA1L3Byb2R1Y3QvMDZlZWJkODRlZDc1NzIxZjg5MzEwYTYzNTdkMDUyNzcuanBnIiwidmVyc2lvbiI6Mn0=.webp?s=620cd67494495e3dbf662fea5641d783ec6103b4643a04ba2c20fce0c32b0e10");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageLink",
                value: "https://db73q1dut0rlp.cloudfront.net/eyJ3aWR0aCI6NDM1LCJoZWlnaHQiOjQzNSwiZml0IjoiY29udGFpbiIsIndhdGVybWFya2VkIjp0cnVlLCJrZXkiOiJhc3NldHMvaW1hZ2VzLzM5ODA0NDQvcHJvZHVjdC9hMDdmNDkwNGNmODI0MTU5NTM3MjY0ZTM5NTdhNDk0Yi5qcGciLCJ2ZXJzaW9uIjoyfQ==.jpg?s=27ac4792d15bef3fd6a03c9c9aa319c4c3d0dac75115c8e3b8e856ac01a26722");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageLink",
                value: "https://db73q1dut0rlp.cloudfront.net/eyJ3aWR0aCI6NDM1LCJoZWlnaHQiOjQzNSwiZml0IjoiY29udGFpbiIsIndhdGVybWFya2VkIjp0cnVlLCJmb3JtYXQiOiJ3ZWJwIiwia2V5IjoiYXNzZXRzL2ltYWdlcy8zNjUxMDgwL3Byb2R1Y3QvZjRjZjQwZjMwYTQxYjBjN2U4MzdlZDk2OTMzNzk4OWMuanBnIiwidmVyc2lvbiI6Mn0=.webp?s=90276857837de2b16a45fc0deba9678c4d427c8f82ceab6d987b583aac03b0e9");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageLink",
                value: "https://contentinfo.autozone.com/znetcs/product-info/en/US/aim/72213DL/image/10/");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt", "PasswordHash" },
                values: new object[] { new DateTime(2022, 6, 22, 8, 29, 7, 908, DateTimeKind.Utc).AddTicks(7493), new DateTime(2022, 6, 22, 8, 29, 7, 908, DateTimeKind.Utc).AddTicks(7526), "$2a$11$HJsqUEsh/lebuPE34xZ9N.Ve//.OXx.9UA3Rk5ZIlO.McASOIWzRO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt", "PasswordHash" },
                values: new object[] { new DateTime(2022, 6, 22, 8, 29, 7, 908, DateTimeKind.Utc).AddTicks(7531), new DateTime(2022, 6, 22, 8, 29, 7, 908, DateTimeKind.Utc).AddTicks(7533), "$2a$11$RY9/Od/PHd5IyNWy6lBiYe1nXSVATRNCBpG4NDfIsneT7lNHj75G2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageLink",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt", "PasswordHash" },
                values: new object[] { new DateTime(2022, 6, 10, 2, 12, 8, 589, DateTimeKind.Utc).AddTicks(7411), new DateTime(2022, 6, 10, 2, 12, 8, 589, DateTimeKind.Utc).AddTicks(7462), "am9obmRvZTI0MTAK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt", "PasswordHash" },
                values: new object[] { new DateTime(2022, 6, 10, 2, 12, 8, 589, DateTimeKind.Utc).AddTicks(7473), new DateTime(2022, 6, 10, 2, 12, 8, 589, DateTimeKind.Utc).AddTicks(7478), "MTIwOTE5OTM=" });
        }
    }
}
