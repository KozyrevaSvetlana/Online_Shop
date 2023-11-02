using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Db.Migrations
{
    public partial class Identity3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Url" },
                values: new object[] { new Guid("5e32cc56-ff1c-4216-b583-0574c1719efe"), "testImage" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "Name" },
                values: new object[] { new Guid("9527aaed-6914-4c92-ba08-a024d3befb04"), 100m, null, "testProduct" });

            migrationBuilder.InsertData(
                table: "ImagesProducts",
                columns: new[] { "ImageId", "ProductId" },
                values: new object[] { new Guid("5e32cc56-ff1c-4216-b583-0574c1719efe"), new Guid("9527aaed-6914-4c92-ba08-a024d3befb04") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ImagesProducts",
                keyColumns: new[] { "ImageId", "ProductId" },
                keyValues: new object[] { new Guid("5e32cc56-ff1c-4216-b583-0574c1719efe"), new Guid("9527aaed-6914-4c92-ba08-a024d3befb04") });

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("5e32cc56-ff1c-4216-b583-0574c1719efe"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9527aaed-6914-4c92-ba08-a024d3befb04"));
        }
    }
}
