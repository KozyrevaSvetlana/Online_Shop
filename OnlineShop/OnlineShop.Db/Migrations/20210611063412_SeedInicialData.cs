using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Db.Migrations
{
    public partial class SeedInicialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "Image", "Name" },
                values: new object[] { new Guid("b1b2d7fb-50b8-4a6d-b450-883c0bf40a0e"), 22005m, "Восторг", "/img/Products/empty.gif", "Мишка" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "Image", "Name" },
                values: new object[] { new Guid("aa45e09e-5e1c-4d6d-ae6b-312784420b02"), 64843m, "Огонь!", "/img/Products/empty.gif", "Соска" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("aa45e09e-5e1c-4d6d-ae6b-312784420b02"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b1b2d7fb-50b8-4a6d-b450-883c0bf40a0e"));
        }
    }
}
