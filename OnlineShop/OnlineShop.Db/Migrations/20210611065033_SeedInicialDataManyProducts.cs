using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Db.Migrations
{
    public partial class SeedInicialDataManyProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("aa45e09e-5e1c-4d6d-ae6b-312784420b02"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b1b2d7fb-50b8-4a6d-b450-883c0bf40a0e"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "Image", "Name" },
                values: new object[,]
                {
                    { new Guid("a3f432a9-17a0-4307-984b-290611a248f5"), 11426m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit", "/img/Products/1.jpg", "Пистолетик" },
                    { new Guid("c9f07f92-c9d5-4e8f-8093-5c242997ba82"), 97890m, "Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim", "/img/Products/2.jpg", "Шапка" },
                    { new Guid("fe7524c9-a431-4b5b-83b2-9568c7f37bfa"), 10398m, "Ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip", "/img/Products/3.jpg", "Конструктор" },
                    { new Guid("fce4ebfe-1ae7-4e47-b29f-1d34916fc298"), 94608m, "Ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate", "/img/Products/4.jpg", "Пистолетик" },
                    { new Guid("6e406ea4-2656-4c1f-a0d3-8acbc9265dd7"), 83000m, "Velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat", "/img/Products/5.jpg", "Мишка" },
                    { new Guid("56db2983-947f-45d5-ba51-5d5cef5cf7a5"), 38020m, "cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum", "/img/Products/6.jpg", "Пирамидка" },
                    { new Guid("8002540c-9944-4b42-ac8c-01ad787e81e6"), 59657m, "Lorem ipsum dolor sit amet, consectetur adipiscing", "/img/Products/6.jpg", "Трусы" },
                    { new Guid("7a2227e4-4603-444f-ae2d-099079474ea0"), 73815m, "Ex ea commodo consequat.Duis aute irure dolor", "/img/Products/5.jpg", "Пистолетик" },
                    { new Guid("a76d1ebe-cc7d-4618-ac9f-3d1f4935fe57"), 66068m, "Sed do eiusmod tempor incididunt ut labore et dolore magna", "/img/Products/4.jpg", "Чашка" },
                    { new Guid("e54fae4f-7d6c-4e34-aa1b-820cdc772653"), 51625m, "Velit esse cillum dolore eu fugiat nulla pariatur.E", "/img/Products/3.jpg", "Ложка" },
                    { new Guid("615496eb-0537-4657-8237-f033266a3a57"), 76311m, "Velit esse cillum dolore eu fugiat nulla pariatur.", "/img/Products/2.jpg", "Пистолетик" },
                    { new Guid("0cb8d9f0-c806-462c-a1b6-3f095b324761"), 12248m, "Ex ea commodo consequat.Duis aute irure dolor in reprehenderit in v", "/img/Products/1.jpg", "Соска" },
                    { new Guid("27baabe2-d81b-4c46-86e0-23b97d7637c8"), 4225m, "Ex ea commodo consequat.Duis aute i", "/img/Products/2.jpg", "Ложка" },
                    { new Guid("fbb6b537-d539-47ee-95c6-386b5ac0679a"), 54643m, "Minim veniam, quis nostrud exercitation ullamco laboris ", "/img/Products/3.jpg", "Конструктор" },
                    { new Guid("a1ffa88c-1316-42a8-8601-95d70a65d150"), 18346m, "Velit esse cillum dolore eu fugiat nulla pariatur.", "/img/Products/4.jpg", "Шапка" },
                    { new Guid("0794a187-dfea-4807-9259-a7ff279455f2"), 94741m, "Ex ea commodo consequat.Duis aute irure dolor in r", "/img/Products/5.jpg", "Кукла" },
                    { new Guid("bb71353d-1a58-45a2-84da-9b4137bec6f6"), 6957m, "Velit esse cillum dolore eu fugiat nulla pariatur.", "/img/Products/6.jpg", "Пирамидка" },
                    { new Guid("755221a6-0f45-4e86-9948-6e9f85872734"), 82167m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit", "/img/Products/4.jpg", "Ложка" },
                    { new Guid("133788f9-139f-453e-b543-98b5876c4cb7"), 3822m, "Velit esse cillum dolore eu fugiat nulla pariatur.", "/img/Products/3.jpg", "Чашка" },
                    { new Guid("beb1332d-fbe9-4d6e-88f1-c2603bc7a80f"), 88268m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit", "/img/Products/1.jpg", "Ползунки" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0794a187-dfea-4807-9259-a7ff279455f2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0cb8d9f0-c806-462c-a1b6-3f095b324761"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("133788f9-139f-453e-b543-98b5876c4cb7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("27baabe2-d81b-4c46-86e0-23b97d7637c8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("56db2983-947f-45d5-ba51-5d5cef5cf7a5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("615496eb-0537-4657-8237-f033266a3a57"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6e406ea4-2656-4c1f-a0d3-8acbc9265dd7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("755221a6-0f45-4e86-9948-6e9f85872734"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7a2227e4-4603-444f-ae2d-099079474ea0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8002540c-9944-4b42-ac8c-01ad787e81e6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a1ffa88c-1316-42a8-8601-95d70a65d150"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a3f432a9-17a0-4307-984b-290611a248f5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a76d1ebe-cc7d-4618-ac9f-3d1f4935fe57"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bb71353d-1a58-45a2-84da-9b4137bec6f6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("beb1332d-fbe9-4d6e-88f1-c2603bc7a80f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c9f07f92-c9d5-4e8f-8093-5c242997ba82"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e54fae4f-7d6c-4e34-aa1b-820cdc772653"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fbb6b537-d539-47ee-95c6-386b5ac0679a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fce4ebfe-1ae7-4e47-b29f-1d34916fc298"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fe7524c9-a431-4b5b-83b2-9568c7f37bfa"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "Image", "Name" },
                values: new object[] { new Guid("b1b2d7fb-50b8-4a6d-b450-883c0bf40a0e"), 22005m, "Восторг", "/img/Products/empty.gif", "Мишка" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "Image", "Name" },
                values: new object[] { new Guid("aa45e09e-5e1c-4d6d-ae6b-312784420b02"), 64843m, "Огонь!", "/img/Products/empty.gif", "Соска" });
        }
    }
}
