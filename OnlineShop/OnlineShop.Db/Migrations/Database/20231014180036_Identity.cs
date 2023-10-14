using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Db.Migrations.Database
{
    public partial class Identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Compares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompareProduct",
                columns: table => new
                {
                    ComparesId = table.Column<int>(type: "int", nullable: false),
                    ItemsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompareProduct", x => new { x.ComparesId, x.ItemsId });
                    table.ForeignKey(
                        name: "FK_CompareProduct_Compares_ComparesId",
                        column: x => x.ComparesId,
                        principalTable: "Compares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompareProduct_Products_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavoritesProduct",
                columns: table => new
                {
                    FavoritesId = table.Column<int>(type: "int", nullable: false),
                    ItemsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoritesProduct", x => new { x.FavoritesId, x.ItemsId });
                    table.ForeignKey(
                        name: "FK_FavoritesProduct_Favorites_FavoritesId",
                        column: x => x.FavoritesId,
                        principalTable: "Favorites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoritesProduct_Products_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoStatus = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserContacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserContacts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CartId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartItems_UserContacts_UserContactId",
                        column: x => x.UserContactId,
                        principalTable: "UserContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    { new Guid("6cb5d7b1-e020-4822-b952-e2f263729cc1"), new Guid("a3f432a9-17a0-4307-984b-290611a248f5"), "/img/Products/1.jpg" },
                    { new Guid("e9ec9f49-45e3-4f27-ab42-e5f0adb842f8"), new Guid("755221a6-0f45-4e86-9948-6e9f85872734"), "/img/Products/4.jpg" },
                    { new Guid("8d065588-34df-4ee2-a966-b98b370712c2"), new Guid("bb71353d-1a58-45a2-84da-9b4137bec6f6"), "/img/Products/6.jpg" },
                    { new Guid("bd54cf1a-dad9-4932-85bc-d706020c27d4"), new Guid("0794a187-dfea-4807-9259-a7ff279455f2"), "/img/Products/5.jpg" },
                    { new Guid("96acd93c-f9f4-4f80-ad72-dbb5dc530609"), new Guid("a1ffa88c-1316-42a8-8601-95d70a65d150"), "/img/Products/4.jpg" },
                    { new Guid("f3a6f162-6424-4c32-af38-2da43e658809"), new Guid("fbb6b537-d539-47ee-95c6-386b5ac0679a"), "/img/Products/3.jpg" },
                    { new Guid("ede9fa40-296e-4550-8591-25411d412652"), new Guid("27baabe2-d81b-4c46-86e0-23b97d7637c8"), "/img/Products/2.jpg" },
                    { new Guid("2c49cad8-2e76-4e5a-90ce-aa1c16cb79be"), new Guid("0cb8d9f0-c806-462c-a1b6-3f095b324761"), "/img/Products/1.jpg" },
                    { new Guid("a4d5beef-6ac2-4736-89a2-a341620e201d"), new Guid("615496eb-0537-4657-8237-f033266a3a57"), "/img/Products/2.jpg" },
                    { new Guid("ad749561-6e46-41fb-b8ed-b1a61388dc1f"), new Guid("e54fae4f-7d6c-4e34-aa1b-820cdc772653"), "/img/Products/3.jpg" },
                    { new Guid("24e3cbf6-5405-4ef7-8ab9-d1cb14c4219f"), new Guid("a76d1ebe-cc7d-4618-ac9f-3d1f4935fe57"), "/img/Products/4.jpg" },
                    { new Guid("71e300e1-55a3-40f9-9995-63f77d73761d"), new Guid("7a2227e4-4603-444f-ae2d-099079474ea0"), "/img/Products/5.jpg" },
                    { new Guid("558426b1-8e9b-41ed-accd-8f11ebaf6c88"), new Guid("8002540c-9944-4b42-ac8c-01ad787e81e6"), "/img/Products/6.jpg" },
                    { new Guid("e817aeb4-fdf7-46a5-970f-3f0ecae6bf2d"), new Guid("56db2983-947f-45d5-ba51-5d5cef5cf7a5"), "/img/Products/6.jpg" },
                    { new Guid("458dc5b8-d4f0-469d-8207-6f7fd802d2bd"), new Guid("6e406ea4-2656-4c1f-a0d3-8acbc9265dd7"), "/img/Products/5.jpg" },
                    { new Guid("7d306aec-9a1b-43c6-b104-f5ddc973b0f9"), new Guid("fce4ebfe-1ae7-4e47-b29f-1d34916fc298"), "/img/Products/3.jpg" },
                    { new Guid("90dcf2a4-085b-4272-958b-b55f61627742"), new Guid("fe7524c9-a431-4b5b-83b2-9568c7f37bfa"), "/img/Products/3.jpg" },
                    { new Guid("2e13aa14-ff35-4b1b-9aeb-3654c6181632"), new Guid("c9f07f92-c9d5-4e8f-8093-5c242997ba82"), "/img/Products/2.jpg" },
                    { new Guid("f969ee19-069a-4769-8bbc-f52919e31065"), new Guid("133788f9-139f-453e-b543-98b5876c4cb7"), "/img/Products/3.jpg" },
                    { new Guid("7b046970-f8e1-4838-a1e4-29d0be538f08"), new Guid("beb1332d-fbe9-4d6e-88f1-c2603bc7a80f"), "/img/Products/1.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_OrderId",
                table: "CartItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_UserContactId",
                table: "CartItems",
                column: "UserContactId");

            migrationBuilder.CreateIndex(
                name: "IX_CompareProduct_ItemsId",
                table: "CompareProduct",
                column: "ItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoritesProduct_ItemsId",
                table: "FavoritesProduct",
                column: "ItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_ProductId",
                table: "Image",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UserContacts_OrderId",
                table: "UserContacts",
                column: "OrderId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "CompareProduct");

            migrationBuilder.DropTable(
                name: "FavoritesProduct");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "UserContacts");

            migrationBuilder.DropTable(
                name: "Compares");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
