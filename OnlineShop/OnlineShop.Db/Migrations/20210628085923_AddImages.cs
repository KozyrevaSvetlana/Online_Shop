using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Db.Migrations
{
    public partial class AddImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("089c8d74-5fd5-4932-902c-a3d4b461d20d"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("2b4224c1-c404-4139-bc8b-f08d0aaaf828"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("4d7786b0-d787-4bfe-97bf-c9bbe381b516"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("5075c6a4-c3b2-47bd-aef4-390c7c07c8f0"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("59571305-9b90-4135-9ef6-ba324f3363ea"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("5b6d26ba-d47a-45f1-b123-7956e505a532"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("5facc071-6f36-4661-818e-0009216f3b97"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("86be92f1-25b6-43ee-9ca3-cd47334d92ee"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("8d0db4e4-b26c-4d8b-9ca7-ae07de204929"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("8df3a154-b9d1-48e1-a54b-5696831638c2"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("a4187aa0-a297-4977-aa36-ccb50679d214"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("ba029b2a-32fd-4c9c-bc02-5b8ef6284be6"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("be880a41-5891-453a-9c32-ef032f4e8265"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("d25fab08-cb1a-466b-bbde-ae4d4dacce87"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("d37c74cb-094b-4f82-abc3-bbccc87e64f4"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("de59c4dd-f1d2-4e33-99a1-51614349a316"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("e2f1d2a8-6fda-4754-8229-14c0822c3fe7"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("e99d45ef-2c97-47b9-9ca7-737b3fdce3f9"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("f1a5c8bc-8c28-4d3f-9d5a-3fcbc7b691de"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("f1d67b06-f4a8-44de-8ff6-45ede24ff17b"));

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "ProductId", "Url" },
                values: new object[,]
                {
                    { new Guid("6ff0cddb-19c5-4a96-b923-98ba28deb591"), new Guid("a3f432a9-17a0-4307-984b-290611a248f5"), "/img/Products/1.jpg" },
                    { new Guid("723e08b3-faf6-487a-8c98-6f33473b4966"), new Guid("755221a6-0f45-4e86-9948-6e9f85872734"), "/img/Products/4.jpg" },
                    { new Guid("94fa046e-865c-41e2-89b8-53890c41f17e"), new Guid("bb71353d-1a58-45a2-84da-9b4137bec6f6"), "/img/Products/6.jpg" },
                    { new Guid("5bd7333f-2090-4f5f-8bd8-36f1afcc571d"), new Guid("0794a187-dfea-4807-9259-a7ff279455f2"), "/img/Products/5.jpg" },
                    { new Guid("292467c7-f617-4262-80dc-9bae43c6d01b"), new Guid("a1ffa88c-1316-42a8-8601-95d70a65d150"), "/img/Products/4.jpg" },
                    { new Guid("329a7079-d90c-4599-a511-7907de74abaa"), new Guid("fbb6b537-d539-47ee-95c6-386b5ac0679a"), "/img/Products/3.jpg" },
                    { new Guid("91d24398-74a1-441b-aa26-ba354596b20b"), new Guid("27baabe2-d81b-4c46-86e0-23b97d7637c8"), "/img/Products/2.jpg" },
                    { new Guid("b03da0cb-fd2e-44f1-b387-6fb13dce2889"), new Guid("0cb8d9f0-c806-462c-a1b6-3f095b324761"), "/img/Products/1.jpg" },
                    { new Guid("58f18bde-226c-46b4-a430-7cb839dcb99f"), new Guid("615496eb-0537-4657-8237-f033266a3a57"), "/img/Products/2.jpg" },
                    { new Guid("3fdcd0d6-5253-457c-9f2c-c46ebb89435c"), new Guid("e54fae4f-7d6c-4e34-aa1b-820cdc772653"), "/img/Products/3.jpg" },
                    { new Guid("dcffa333-de6c-4f74-b3e1-25523be0df5e"), new Guid("a76d1ebe-cc7d-4618-ac9f-3d1f4935fe57"), "/img/Products/4.jpg" },
                    { new Guid("9efa8471-8cd1-4484-b0b7-dd96a645ab47"), new Guid("7a2227e4-4603-444f-ae2d-099079474ea0"), "/img/Products/5.jpg" },
                    { new Guid("d0a0d6d4-3f3d-4eab-a454-b5d5653435e9"), new Guid("8002540c-9944-4b42-ac8c-01ad787e81e6"), "/img/Products/6.jpg" },
                    { new Guid("dc53b3c1-26df-4075-879a-5554f1b81127"), new Guid("56db2983-947f-45d5-ba51-5d5cef5cf7a5"), "/img/Products/6.jpg" },
                    { new Guid("dc2cdde7-2a0b-4735-8f1b-ab8cd787f3c7"), new Guid("6e406ea4-2656-4c1f-a0d3-8acbc9265dd7"), "/img/Products/5.jpg" },
                    { new Guid("7d1d5dc1-195a-409d-a03e-7d1637cc589a"), new Guid("fce4ebfe-1ae7-4e47-b29f-1d34916fc298"), "/img/Products/3.jpg" },
                    { new Guid("09eb85d7-e361-4320-bb94-35a5a405dd3c"), new Guid("fe7524c9-a431-4b5b-83b2-9568c7f37bfa"), "/img/Products/3.jpg" },
                    { new Guid("7f3f54ac-bf05-4faf-aaa1-0141eee34cdd"), new Guid("c9f07f92-c9d5-4e8f-8093-5c242997ba82"), "/img/Products/2.jpg" },
                    { new Guid("326ba2c2-9d62-4146-8a20-a17cff2dd984"), new Guid("133788f9-139f-453e-b543-98b5876c4cb7"), "/img/Products/3.jpg" },
                    { new Guid("2e01a790-a3cd-4a0b-b027-75f04948d969"), new Guid("beb1332d-fbe9-4d6e-88f1-c2603bc7a80f"), "/img/Products/1.jpg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("09eb85d7-e361-4320-bb94-35a5a405dd3c"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("292467c7-f617-4262-80dc-9bae43c6d01b"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("2e01a790-a3cd-4a0b-b027-75f04948d969"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("326ba2c2-9d62-4146-8a20-a17cff2dd984"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("329a7079-d90c-4599-a511-7907de74abaa"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("3fdcd0d6-5253-457c-9f2c-c46ebb89435c"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("58f18bde-226c-46b4-a430-7cb839dcb99f"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("5bd7333f-2090-4f5f-8bd8-36f1afcc571d"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("6ff0cddb-19c5-4a96-b923-98ba28deb591"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("723e08b3-faf6-487a-8c98-6f33473b4966"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("7d1d5dc1-195a-409d-a03e-7d1637cc589a"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("7f3f54ac-bf05-4faf-aaa1-0141eee34cdd"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("91d24398-74a1-441b-aa26-ba354596b20b"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("94fa046e-865c-41e2-89b8-53890c41f17e"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("9efa8471-8cd1-4484-b0b7-dd96a645ab47"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("b03da0cb-fd2e-44f1-b387-6fb13dce2889"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("d0a0d6d4-3f3d-4eab-a454-b5d5653435e9"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("dc2cdde7-2a0b-4735-8f1b-ab8cd787f3c7"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("dc53b3c1-26df-4075-879a-5554f1b81127"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("dcffa333-de6c-4f74-b3e1-25523be0df5e"));

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "ProductId", "Url" },
                values: new object[,]
                {
                    { new Guid("2b4224c1-c404-4139-bc8b-f08d0aaaf828"), new Guid("a3f432a9-17a0-4307-984b-290611a248f5"), "/img/Products/1.jpg" },
                    { new Guid("a4187aa0-a297-4977-aa36-ccb50679d214"), new Guid("755221a6-0f45-4e86-9948-6e9f85872734"), "/img/Products/4.jpg" },
                    { new Guid("d25fab08-cb1a-466b-bbde-ae4d4dacce87"), new Guid("bb71353d-1a58-45a2-84da-9b4137bec6f6"), "/img/Products/6.jpg" },
                    { new Guid("5b6d26ba-d47a-45f1-b123-7956e505a532"), new Guid("0794a187-dfea-4807-9259-a7ff279455f2"), "/img/Products/5.jpg" },
                    { new Guid("089c8d74-5fd5-4932-902c-a3d4b461d20d"), new Guid("a1ffa88c-1316-42a8-8601-95d70a65d150"), "/img/Products/4.jpg" },
                    { new Guid("86be92f1-25b6-43ee-9ca3-cd47334d92ee"), new Guid("fbb6b537-d539-47ee-95c6-386b5ac0679a"), "/img/Products/3.jpg" },
                    { new Guid("be880a41-5891-453a-9c32-ef032f4e8265"), new Guid("27baabe2-d81b-4c46-86e0-23b97d7637c8"), "/img/Products/2.jpg" },
                    { new Guid("e2f1d2a8-6fda-4754-8229-14c0822c3fe7"), new Guid("0cb8d9f0-c806-462c-a1b6-3f095b324761"), "/img/Products/1.jpg" },
                    { new Guid("4d7786b0-d787-4bfe-97bf-c9bbe381b516"), new Guid("615496eb-0537-4657-8237-f033266a3a57"), "/img/Products/2.jpg" },
                    { new Guid("8d0db4e4-b26c-4d8b-9ca7-ae07de204929"), new Guid("e54fae4f-7d6c-4e34-aa1b-820cdc772653"), "/img/Products/3.jpg" },
                    { new Guid("e99d45ef-2c97-47b9-9ca7-737b3fdce3f9"), new Guid("a76d1ebe-cc7d-4618-ac9f-3d1f4935fe57"), "/img/Products/4.jpg" },
                    { new Guid("59571305-9b90-4135-9ef6-ba324f3363ea"), new Guid("7a2227e4-4603-444f-ae2d-099079474ea0"), "/img/Products/5.jpg" },
                    { new Guid("d37c74cb-094b-4f82-abc3-bbccc87e64f4"), new Guid("8002540c-9944-4b42-ac8c-01ad787e81e6"), "/img/Products/6.jpg" },
                    { new Guid("f1d67b06-f4a8-44de-8ff6-45ede24ff17b"), new Guid("56db2983-947f-45d5-ba51-5d5cef5cf7a5"), "/img/Products/6.jpg" },
                    { new Guid("de59c4dd-f1d2-4e33-99a1-51614349a316"), new Guid("6e406ea4-2656-4c1f-a0d3-8acbc9265dd7"), "/img/Products/5.jpg" },
                    { new Guid("f1a5c8bc-8c28-4d3f-9d5a-3fcbc7b691de"), new Guid("fce4ebfe-1ae7-4e47-b29f-1d34916fc298"), "/img/Products/3.jpg" },
                    { new Guid("ba029b2a-32fd-4c9c-bc02-5b8ef6284be6"), new Guid("fe7524c9-a431-4b5b-83b2-9568c7f37bfa"), "/img/Products/3.jpg" },
                    { new Guid("5075c6a4-c3b2-47bd-aef4-390c7c07c8f0"), new Guid("c9f07f92-c9d5-4e8f-8093-5c242997ba82"), "/img/Products/2.jpg" },
                    { new Guid("8df3a154-b9d1-48e1-a54b-5696831638c2"), new Guid("133788f9-139f-453e-b543-98b5876c4cb7"), "/img/Products/3.jpg" },
                    { new Guid("5facc071-6f36-4661-818e-0009216f3b97"), new Guid("beb1332d-fbe9-4d6e-88f1-c2603bc7a80f"), "/img/Products/1.jpg" }
                });
        }
    }
}
