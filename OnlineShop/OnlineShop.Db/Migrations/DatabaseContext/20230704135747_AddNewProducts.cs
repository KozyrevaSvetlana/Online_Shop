using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Db.Migrations.DatabaseContext
{
    public partial class AddNewProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("a3f432a9-17a0-4307-984b-290611a248f5"), 11426m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit", "Пистолетик" },
                    { new Guid("755221a6-0f45-4e86-9948-6e9f85872734"), 82167m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit", "Ложка" },
                    { new Guid("bb71353d-1a58-45a2-84da-9b4137bec6f6"), 6957m, "Velit esse cillum dolore eu fugiat nulla pariatur.", "Кукла" },
                    { new Guid("0794a187-dfea-4807-9259-a7ff279455f2"), 94741m, "Ex ea commodo consequat.Duis aute irure dolor in r", "Кукла" },
                    { new Guid("a1ffa88c-1316-42a8-8601-95d70a65d150"), 18346m, "Velit esse cillum dolore eu fugiat nulla pariatur.", "Шапка" },
                    { new Guid("fbb6b537-d539-47ee-95c6-386b5ac0679a"), 54643m, "Minim veniam, quis nostrud exercitation ullamco laboris ", "Конструктор" },
                    { new Guid("27baabe2-d81b-4c46-86e0-23b97d7637c8"), 4225m, "Ex ea commodo consequat.Duis aute i ", "Ложка" },
                    { new Guid("0cb8d9f0-c806-462c-a1b6-3f095b324761"), 12248m, "Ex ea commodo consequat.Duis aute irure dolor in reprehenderit in v", "Соска" },
                    { new Guid("615496eb-0537-4657-8237-f033266a3a57"), 76311m, "Velit esse cillum dolore eu fugiat nulla pariatur.", "Пистолетик" },
                    { new Guid("e54fae4f-7d6c-4e34-aa1b-820cdc772653"), 51625m, "Velit esse cillum dolore eu fugiat nulla pariatur.E", "Ложка" },
                    { new Guid("a76d1ebe-cc7d-4618-ac9f-3d1f4935fe57"), 66068m, "Sed do eiusmod tempor incididunt ut labore et dolore magna ", "Пистолетик" },
                    { new Guid("7a2227e4-4603-444f-ae2d-099079474ea0"), 73815m, "Ex ea commodo consequat.Duis aute irure dolor", "Пистолетик" },
                    { new Guid("8002540c-9944-4b42-ac8c-01ad787e81e6"), 59657m, "Lorem ipsum dolor sit amet, consectetur adipiscing", "Трусы" },
                    { new Guid("56db2983-947f-45d5-ba51-5d5cef5cf7a5"), 38020m, "cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum", "Пирамидка" },
                    { new Guid("6e406ea4-2656-4c1f-a0d3-8acbc9265dd7"), 83000m, "Velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat", "Мишка" },
                    { new Guid("fce4ebfe-1ae7-4e47-b29f-1d34916fc298"), 94608m, "Ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate", "Пистолетик" },
                    { new Guid("fe7524c9-a431-4b5b-83b2-9568c7f37bfa"), 10398m, "Ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ", "Конструктор" },
                    { new Guid("c9f07f92-c9d5-4e8f-8093-5c242997ba82"), 11426m, "Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim", "Шапка" },
                    { new Guid("133788f9-139f-453e-b543-98b5876c4cb7"), 82167m, "Velit esse cillum dolore eu fugiat nulla pariatur", "Чашка" },
                    { new Guid("beb1332d-fbe9-4d6e-88f1-c2603bc7a80f"), 88268m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit", "Ползунки" }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "ProductId", "Url" },
                values: new object[,]
                {
                    { new Guid("1748607c-2cf3-477e-9681-d1a8ad2a0fe8"), new Guid("a3f432a9-17a0-4307-984b-290611a248f5"), "/img/Products/1.jpg" },
                    { new Guid("7d93ce60-b7fd-4dd5-b35e-f11a9c60dc9d"), new Guid("755221a6-0f45-4e86-9948-6e9f85872734"), "/img/Products/4.jpg" },
                    { new Guid("72fc74bc-d89c-4157-b9f1-d883d8dbd205"), new Guid("bb71353d-1a58-45a2-84da-9b4137bec6f6"), "/img/Products/6.jpg" },
                    { new Guid("61a860bb-a5d4-4ee2-bb8a-4d22c1f694c5"), new Guid("0794a187-dfea-4807-9259-a7ff279455f2"), "/img/Products/5.jpg" },
                    { new Guid("90d5f94e-dbbb-4aaf-9666-ff6c170054a3"), new Guid("a1ffa88c-1316-42a8-8601-95d70a65d150"), "/img/Products/4.jpg" },
                    { new Guid("5f3c0884-7620-44e2-ae41-f69084e9c356"), new Guid("fbb6b537-d539-47ee-95c6-386b5ac0679a"), "/img/Products/3.jpg" },
                    { new Guid("01c5a811-b6ec-440d-9268-8365c4662688"), new Guid("27baabe2-d81b-4c46-86e0-23b97d7637c8"), "/img/Products/2.jpg" },
                    { new Guid("9e242f48-390e-46a6-92ec-f7ff9c76cb23"), new Guid("0cb8d9f0-c806-462c-a1b6-3f095b324761"), "/img/Products/1.jpg" },
                    { new Guid("a98d7022-c4e2-4c0d-81ea-7d6e2e802c52"), new Guid("615496eb-0537-4657-8237-f033266a3a57"), "/img/Products/2.jpg" },
                    { new Guid("9bb4561c-0252-42e8-be13-ba8f91fc4245"), new Guid("e54fae4f-7d6c-4e34-aa1b-820cdc772653"), "/img/Products/3.jpg" },
                    { new Guid("68543a26-c03f-40c2-80a5-af273002c415"), new Guid("a76d1ebe-cc7d-4618-ac9f-3d1f4935fe57"), "/img/Products/4.jpg" },
                    { new Guid("077003e4-057c-4284-be54-aa2b2a63dd44"), new Guid("7a2227e4-4603-444f-ae2d-099079474ea0"), "/img/Products/5.jpg" },
                    { new Guid("e2ee0a50-a2c4-44ff-9ae2-e48b54efcd80"), new Guid("8002540c-9944-4b42-ac8c-01ad787e81e6"), "/img/Products/6.jpg" },
                    { new Guid("58de2a7c-6ed6-4cc5-89c5-e582d2bf9912"), new Guid("56db2983-947f-45d5-ba51-5d5cef5cf7a5"), "/img/Products/6.jpg" },
                    { new Guid("919c3e60-7e36-4617-9be5-b9b3f9a67139"), new Guid("6e406ea4-2656-4c1f-a0d3-8acbc9265dd7"), "/img/Products/5.jpg" },
                    { new Guid("f7ef5df8-23cc-4e61-9cec-c0709a0c2796"), new Guid("fce4ebfe-1ae7-4e47-b29f-1d34916fc298"), "/img/Products/3.jpg" },
                    { new Guid("bbaf97d4-c5ce-43a0-98f9-651d7303bad9"), new Guid("fe7524c9-a431-4b5b-83b2-9568c7f37bfa"), "/img/Products/3.jpg" },
                    { new Guid("401aaf8b-de6a-4486-86c2-628e44b6f6a7"), new Guid("c9f07f92-c9d5-4e8f-8093-5c242997ba82"), "/img/Products/2.jpg" },
                    { new Guid("96b0c149-dc78-4cfa-816b-c459ea2b7d4e"), new Guid("133788f9-139f-453e-b543-98b5876c4cb7"), "/img/Products/3.jpg" },
                    { new Guid("c92b9f40-017a-4146-b836-1af2b5fadff8"), new Guid("beb1332d-fbe9-4d6e-88f1-c2603bc7a80f"), "/img/Products/1.jpg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("01c5a811-b6ec-440d-9268-8365c4662688"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("077003e4-057c-4284-be54-aa2b2a63dd44"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("1748607c-2cf3-477e-9681-d1a8ad2a0fe8"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("401aaf8b-de6a-4486-86c2-628e44b6f6a7"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("58de2a7c-6ed6-4cc5-89c5-e582d2bf9912"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("5f3c0884-7620-44e2-ae41-f69084e9c356"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("61a860bb-a5d4-4ee2-bb8a-4d22c1f694c5"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("68543a26-c03f-40c2-80a5-af273002c415"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("72fc74bc-d89c-4157-b9f1-d883d8dbd205"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("7d93ce60-b7fd-4dd5-b35e-f11a9c60dc9d"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("90d5f94e-dbbb-4aaf-9666-ff6c170054a3"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("919c3e60-7e36-4617-9be5-b9b3f9a67139"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("96b0c149-dc78-4cfa-816b-c459ea2b7d4e"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("9bb4561c-0252-42e8-be13-ba8f91fc4245"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("9e242f48-390e-46a6-92ec-f7ff9c76cb23"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("a98d7022-c4e2-4c0d-81ea-7d6e2e802c52"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("bbaf97d4-c5ce-43a0-98f9-651d7303bad9"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("c92b9f40-017a-4146-b836-1af2b5fadff8"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("e2ee0a50-a2c4-44ff-9ae2-e48b54efcd80"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("f7ef5df8-23cc-4e61-9cec-c0709a0c2796"));

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
        }
    }
}
