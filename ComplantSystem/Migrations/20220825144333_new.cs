using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComplantSystem.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1b87e3c5-fe9e-456f-98ca-40a55d6b1971");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2958cfef-2dd9-4337-9cfc-78f6a0e64e04");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "597a129a-08ae-4055-a614-e05cf56f5eb1");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "a5e392f5-5e29-472f-bec7-2dc62feb9866");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c257705b-162b-42ad-a888-2c918edfba0a");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ed412ee2-50ad-4f5e-ae56-1b1c8cbf7e6c");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "0de8a99c-f9bc-446a-bf60-f18f36715cbe");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "6d3ebdee-40e4-4daa-8e08-26da84b6d577");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "b2b36c8c-08a8-4845-8c50-abcf63ce8669");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "b4e5a529-6673-4261-852a-7d4d402f19c3");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6d208451-fa54-4360-bf85-3c248952999f", "447bba93-5146-4b50-9e49-64e4c4a7031f", "AdminGeneralFederation", "ADMINGENERALFEDERATION" },
                    { "a01d9754-6f5d-4ee8-b70c-faefba94c0ce", "96f06219-08be-4f65-ad7e-d9b1715b61a9", "AdminGovernorate", "ADMINGOVERNORATE" },
                    { "0bb61ada-0d87-45d5-94b6-5e3810a84466", "7fe3eac0-9a2a-40f9-8e11-56544ddb6cbd", "AdminDirectorate", "ADMINDIRECTORATE" },
                    { "284430a5-69a7-4a6b-8cd0-94516121581d", "ecb6ff5e-9532-41e1-8042-a1d11712733f", "AdminSubDirectorate", "ADMINSUBDIRECTORATE" },
                    { "4498ef8e-d3f7-465e-99ac-b3fac6077c1c", "6de356e7-9a13-4339-bcb5-a66c69d985fb", "AdminVillages", "ADMINVILLAGES" },
                    { "d995dfc5-5f36-4761-aaeb-a6238fa51f35", "4f9490e6-4a2d-4b85-b888-e3186dba1785", "Beneficiarie", "BENEFICIARIE" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "TypeComplaints",
                columns: new[] { "Id", "CreatedDate", "Type", "UserId", "UsersNameAddType" },
                values: new object[,]
                {
                    { "a7eb5577-a4f4-41da-ac6f-8acb8a375091", new DateTime(2022, 8, 25, 17, 43, 32, 652, DateTimeKind.Local).AddTicks(4281), "زراعية", null, null },
                    { "ccea5cfe-2bca-4113-b8fb-6f67fcdcb845", new DateTime(2022, 8, 25, 17, 43, 32, 652, DateTimeKind.Local).AddTicks(5500), "فساد", null, null },
                    { "5defa393-ef64-41c3-b198-5f778f1129fd", new DateTime(2022, 8, 25, 17, 43, 32, 652, DateTimeKind.Local).AddTicks(5512), "مماطلة", null, null },
                    { "a66a4717-501e-4772-bdfd-c0d84f7234b4", new DateTime(2022, 8, 25, 17, 43, 32, 652, DateTimeKind.Local).AddTicks(5526), "إرتشاء", null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "0bb61ada-0d87-45d5-94b6-5e3810a84466");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "284430a5-69a7-4a6b-8cd0-94516121581d");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "4498ef8e-d3f7-465e-99ac-b3fac6077c1c");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6d208451-fa54-4360-bf85-3c248952999f");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "a01d9754-6f5d-4ee8-b70c-faefba94c0ce");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "d995dfc5-5f36-4761-aaeb-a6238fa51f35");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "5defa393-ef64-41c3-b198-5f778f1129fd");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "a66a4717-501e-4772-bdfd-c0d84f7234b4");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "a7eb5577-a4f4-41da-ac6f-8acb8a375091");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "ccea5cfe-2bca-4113-b8fb-6f67fcdcb845");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a5e392f5-5e29-472f-bec7-2dc62feb9866", "4fb3a8b2-fced-45ba-85c8-d31bb9429f15", "AdminGeneralFederation", "ADMINGENERALFEDERATION" },
                    { "c257705b-162b-42ad-a888-2c918edfba0a", "0366cebb-18bd-450d-9462-4b7d4f59e991", "AdminGovernorate", "ADMINGOVERNORATE" },
                    { "597a129a-08ae-4055-a614-e05cf56f5eb1", "70e1a720-7143-4926-8872-6e8a6bc43949", "AdminDirectorate", "ADMINDIRECTORATE" },
                    { "2958cfef-2dd9-4337-9cfc-78f6a0e64e04", "e859d491-2a28-40ec-899a-86e389887914", "AdminSubDirectorate", "ADMINSUBDIRECTORATE" },
                    { "1b87e3c5-fe9e-456f-98ca-40a55d6b1971", "dcb3faa1-ad3a-41f1-a2ab-fd266d44b14c", "AdminVillages", "ADMINVILLAGES" },
                    { "ed412ee2-50ad-4f5e-ae56-1b1c8cbf7e6c", "fa424e83-481c-4829-a862-c1da21697ad5", "Beneficiarie", "BENEFICIARIE" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "TypeComplaints",
                columns: new[] { "Id", "CreatedDate", "Type", "UserId", "UsersNameAddType" },
                values: new object[,]
                {
                    { "b2b36c8c-08a8-4845-8c50-abcf63ce8669", new DateTime(2022, 8, 25, 17, 38, 25, 64, DateTimeKind.Local).AddTicks(3643), "زراعية", null, null },
                    { "b4e5a529-6673-4261-852a-7d4d402f19c3", new DateTime(2022, 8, 25, 17, 38, 25, 64, DateTimeKind.Local).AddTicks(4323), "فساد", null, null },
                    { "0de8a99c-f9bc-446a-bf60-f18f36715cbe", new DateTime(2022, 8, 25, 17, 38, 25, 64, DateTimeKind.Local).AddTicks(4350), "مماطلة", null, null },
                    { "6d3ebdee-40e4-4daa-8e08-26da84b6d577", new DateTime(2022, 8, 25, 17, 38, 25, 64, DateTimeKind.Local).AddTicks(4360), "إرتشاء", null, null }
                });
        }
    }
}
