using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Db.Migrations
{
    public partial class NoGegisterUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "NoGegisterUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: true),
                    CartLifeTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoGegisterUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoGegisterUsers_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "Image", "Name" },
                values: new object[,]
                {
                    { new Guid("a153b13e-d35d-4ba2-8c90-30dc25900b9a"), 81295m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, quis nostrud exercitation u", "/img/Products/5.jpg", "Пелёнка" },
                    { new Guid("26c081c9-b4c7-434c-9b12-0794eb3f255e"), 97437m, "Lorem ipsum dolor sit amet, consectetu", "/img/Products/1.jpg", "Ложка" },
                    { new Guid("fb770e3f-23a7-48a2-8ec6-4ce4f357e854"), 99802m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, quis nostrud", "/img/Products/2.jpg", "Ползунки" },
                    { new Guid("31e345ed-caed-4350-81c2-91e94cdc9207"), 61448m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, quis ", "/img/Products/2.jpg", "Мячик" },
                    { new Guid("01666a00-aacb-471b-b471-f7726f64d1c0"), 7824m, "Lorem ipsum dolor sit amet, consectetur adipiscin", "/img/Products/4.jpg", "Вилка" },
                    { new Guid("a2730322-7633-449b-bd03-ba9000e20955"), 41010m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad ", "/img/Products/6.jpg", "Распашонка" },
                    { new Guid("7addfed6-1353-4f1d-aeb2-26f495bc0853"), 59253m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et", "/img/Products/5.jpg", "Чашка" },
                    { new Guid("61e62c52-080c-4c24-9651-033cd8ce2aca"), 21687m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor ", "/img/Products/6.jpg", "Памперсы" },
                    { new Guid("715c67ae-03d0-47ad-9d94-2b45eef6e380"), 47635m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupid", "/img/Products/6.jpg", "Мишка" },
                    { new Guid("13c536af-8e63-42ae-9e6b-5d4a6df6bcbe"), 42655m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi u", "/img/Products/5.jpg", "Крем" },
                    { new Guid("eac5756b-1328-4c53-8bcb-39861ff0b2f8"), 92184m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et do", "/img/Products/5.jpg", "Журнал" },
                    { new Guid("59224cf6-6213-4542-951b-c1e539c68551"), 31702m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut e", "/img/Products/5.jpg", "Распашонка" },
                    { new Guid("90949e50-358b-4a79-a85c-b4321b3e6a81"), 91729m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate velit esse cil", "/img/Products/4.jpg", "Трусы" },
                    { new Guid("f8eecce2-53e4-4cae-8654-fdc1d5a60b92"), 69151m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, quis nostrud exerc", "/img/Products/2.jpg", "Ложка" },
                    { new Guid("1ac50387-f968-42a9-b9a9-202374a6fd5c"), 12177m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor in reprehenderit in volup", "/img/Products/6.jpg", "Распашонка" },
                    { new Guid("39386be6-48a0-4414-bd45-d2c36f54ec1c"), 61570m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nu", "/img/Products/6.jpg", "Памперсы" },
                    { new Guid("9b5d6d1a-7ed2-4fac-8145-7439acfd4e9a"), 51764m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occ", "/img/Products/2.jpg", "Соска" },
                    { new Guid("468c1867-7a43-464d-a65b-83de90b9bfb1"), 47521m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut e", "/img/Products/6.jpg", "Ложка" },
                    { new Guid("92d22e64-5f33-4812-9b3c-b32ae27a5982"), 80144m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt moll", "/img/Products/6.jpg", "Трусы" },
                    { new Guid("ef8e6484-a2fa-4170-ac65-3760ec21bea6"), 47896m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed ", "/img/Products/3.jpg", "Журнал" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_NoGegisterUsers_CartId",
                table: "NoGegisterUsers",
                column: "CartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoGegisterUsers");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("01666a00-aacb-471b-b471-f7726f64d1c0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("13c536af-8e63-42ae-9e6b-5d4a6df6bcbe"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1ac50387-f968-42a9-b9a9-202374a6fd5c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("26c081c9-b4c7-434c-9b12-0794eb3f255e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("31e345ed-caed-4350-81c2-91e94cdc9207"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("39386be6-48a0-4414-bd45-d2c36f54ec1c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("468c1867-7a43-464d-a65b-83de90b9bfb1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("59224cf6-6213-4542-951b-c1e539c68551"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("61e62c52-080c-4c24-9651-033cd8ce2aca"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("715c67ae-03d0-47ad-9d94-2b45eef6e380"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7addfed6-1353-4f1d-aeb2-26f495bc0853"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("90949e50-358b-4a79-a85c-b4321b3e6a81"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("92d22e64-5f33-4812-9b3c-b32ae27a5982"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9b5d6d1a-7ed2-4fac-8145-7439acfd4e9a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a153b13e-d35d-4ba2-8c90-30dc25900b9a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a2730322-7633-449b-bd03-ba9000e20955"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("eac5756b-1328-4c53-8bcb-39861ff0b2f8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ef8e6484-a2fa-4170-ac65-3760ec21bea6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f8eecce2-53e4-4cae-8654-fdc1d5a60b92"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fb770e3f-23a7-48a2-8ec6-4ce4f357e854"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "Image", "Name" },
                values: new object[,]
                {
                    { new Guid("a3f432a9-17a0-4307-984b-290611a248f5"), 11426m, "Восторг", "/img/Products/empty.gif", "Пистолетик" },
                    { new Guid("c9f07f92-c9d5-4e8f-8093-5c242997ba82"), 97890m, "Фантастика", "/img/Products/empty.gif", "Шапка" },
                    { new Guid("fe7524c9-a431-4b5b-83b2-9568c7f37bfa"), 10398m, "Нет слов", "/img/Products/empty.gif", "Конструктор" },
                    { new Guid("fce4ebfe-1ae7-4e47-b29f-1d34916fc298"), 94608m, "Отменно", "/img/Products/empty.gif", "Пистолетик" },
                    { new Guid("6e406ea4-2656-4c1f-a0d3-8acbc9265dd7"), 83000m, "Неплохо", "/img/Products/empty.gif", "Мишка" },
                    { new Guid("56db2983-947f-45d5-ba51-5d5cef5cf7a5"), 38020m, "Высший сорт", "/img/Products/empty.gif", "Пирамидка" },
                    { new Guid("8002540c-9944-4b42-ac8c-01ad787e81e6"), 59657m, "Никуда не годится", "/img/Products/empty.gif", "Трусы" },
                    { new Guid("7a2227e4-4603-444f-ae2d-099079474ea0"), 73815m, "Высший сорт", "/img/Products/empty.gif", "Пистолетик" },
                    { new Guid("a76d1ebe-cc7d-4618-ac9f-3d1f4935fe57"), 66068m, "Непонятно", "/img/Products/empty.gif", "Чашка" },
                    { new Guid("e54fae4f-7d6c-4e34-aa1b-820cdc772653"), 51625m, "Супер", "/img/Products/empty.gif", "Ложка" },
                    { new Guid("615496eb-0537-4657-8237-f033266a3a57"), 76311m, "Приятно", "/img/Products/empty.gif", "Пистолетик" },
                    { new Guid("0cb8d9f0-c806-462c-a1b6-3f095b324761"), 12248m, "Потрясног", "/img/Products/empty.gif", "Соска" },
                    { new Guid("27baabe2-d81b-4c46-86e0-23b97d7637c8"), 4225m, "Ништяк", "/img/Products/empty.gif", "Ложка" },
                    { new Guid("fbb6b537-d539-47ee-95c6-386b5ac0679a"), 54643m, "Потрясног", "/img/Products/empty.gif", "Конструктор" },
                    { new Guid("a1ffa88c-1316-42a8-8601-95d70a65d150"), 18346m, "Фантастика", "/img/Products/empty.gif", "Шапка" },
                    { new Guid("0794a187-dfea-4807-9259-a7ff279455f2"), 94741m, "Фантастика", "/img/Products/empty.gif", "Кукла" },
                    { new Guid("bb71353d-1a58-45a2-84da-9b4137bec6f6"), 6957m, "Высший сорт", "/img/Products/empty.gif", "Пирамидка" },
                    { new Guid("755221a6-0f45-4e86-9948-6e9f85872734"), 82167m, "Неплохо", "/img/Products/empty.gif", "Ложка" },
                    { new Guid("133788f9-139f-453e-b543-98b5876c4cb7"), 3822m, "Приятно", "/img/Products/empty.gif", "Чашка" },
                    { new Guid("beb1332d-fbe9-4d6e-88f1-c2603bc7a80f"), 88268m, "Восторг", "/img/Products/empty.gif", "Ползунки" }
                });
        }
    }
}
