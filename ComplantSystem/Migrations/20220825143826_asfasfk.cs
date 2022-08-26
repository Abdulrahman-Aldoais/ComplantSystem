using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComplantSystem.Migrations
{
    public partial class asfasfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1546677b-890f-4d25-a682-9c4330a62c8e");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1854072f-b0ec-48bb-a282-13a384a3f746");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "752d8654-6a01-4275-90d2-ba274204a135");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "7b4128c6-599f-4c30-86ed-72ff6f824e8a");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "a2de648a-0b02-4da9-a83a-3c2d426a48e8");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c1e62005-42af-42ce-ba81-b71d37d9c634");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "17ae5192-450a-4d24-82b0-3d934895d86a");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "2f17d445-7dc4-4c4e-97f8-8e932d9aa83a");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "4fd5bf7a-4411-4938-bf94-b3245704017e");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "dfd214ff-48a9-4319-bc2f-d69da6090563");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "1546677b-890f-4d25-a682-9c4330a62c8e", "86ae4846-fde7-4364-99bc-eaabbb8bc590", "AdminGeneralFederation", "ADMINGENERALFEDERATION" },
                    { "752d8654-6a01-4275-90d2-ba274204a135", "2dc28578-0046-47ff-9917-8bd44b594a32", "AdminGovernorate", "ADMINGOVERNORATE" },
                    { "7b4128c6-599f-4c30-86ed-72ff6f824e8a", "911f1cc1-f72d-48b3-bc70-9b07de984c79", "AdminDirectorate", "ADMINDIRECTORATE" },
                    { "c1e62005-42af-42ce-ba81-b71d37d9c634", "91036537-df76-4759-a8cd-7d21b08dcbaa", "AdminSubDirectorate", "ADMINSUBDIRECTORATE" },
                    { "a2de648a-0b02-4da9-a83a-3c2d426a48e8", "07950267-bb06-4071-82ce-84cfe1045dc7", "AdminVillages", "ADMINVILLAGES" },
                    { "1854072f-b0ec-48bb-a282-13a384a3f746", "1e0a0651-d4ca-4d70-b056-496f24f24f60", "Beneficiarie", "BENEFICIARIE" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "TypeComplaints",
                columns: new[] { "Id", "CreatedDate", "Type", "UserId", "UsersNameAddType" },
                values: new object[,]
                {
                    { "dfd214ff-48a9-4319-bc2f-d69da6090563", new DateTime(2022, 8, 25, 16, 50, 4, 60, DateTimeKind.Local).AddTicks(907), "زراعية", null, null },
                    { "17ae5192-450a-4d24-82b0-3d934895d86a", new DateTime(2022, 8, 25, 16, 50, 4, 60, DateTimeKind.Local).AddTicks(1565), "فساد", null, null },
                    { "4fd5bf7a-4411-4938-bf94-b3245704017e", new DateTime(2022, 8, 25, 16, 50, 4, 60, DateTimeKind.Local).AddTicks(1577), "مماطلة", null, null },
                    { "2f17d445-7dc4-4c4e-97f8-8e932d9aa83a", new DateTime(2022, 8, 25, 16, 50, 4, 60, DateTimeKind.Local).AddTicks(1603), "إرتشاء", null, null }
                });
        }
    }
}
