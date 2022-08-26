using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComplantSystem.Migrations
{
    public partial class asfasf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "23849cc6-e2ce-4d22-8500-2ab055e29163");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2fd37af7-3bd2-42a6-9c44-1b7259a3dba2");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6f2f6dd1-cbab-4c23-8339-09cfb435f61f");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ad01d0f3-7216-487a-9ca6-870082a19218");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "d50b3050-7ca8-4066-8834-1ca856339fae");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "eaab8f23-d643-4d6f-9d34-78c1e7d392cd");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "95601674-3690-40a5-b918-d9e4de8c40b5");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "9c8059a4-e483-4430-a467-33e0aceeff5f");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "f541e325-f544-4332-8d5c-ec399637f476");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "f990403e-d059-4e3a-ae59-f5d5fbac7f7d");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "ad01d0f3-7216-487a-9ca6-870082a19218", "67e65c81-4113-419d-9a10-93698c6b41f7", "AdminGeneralFederation", "ADMINGENERALFEDERATION" },
                    { "d50b3050-7ca8-4066-8834-1ca856339fae", "30137725-f310-4d72-9bf2-0fad76d19a58", "AdminGovernorate", "ADMINGOVERNORATE" },
                    { "23849cc6-e2ce-4d22-8500-2ab055e29163", "13f85dc4-f00c-4512-8ea8-b77807097578", "AdminDirectorate", "ADMINDIRECTORATE" },
                    { "6f2f6dd1-cbab-4c23-8339-09cfb435f61f", "451410a4-44f4-4e82-8c77-aa7091b6874b", "AdminSubDirectorate", "ADMINSUBDIRECTORATE" },
                    { "2fd37af7-3bd2-42a6-9c44-1b7259a3dba2", "8ff0b20d-6db2-44bf-835a-aaeac8750c57", "AdminVillages", "ADMINVILLAGES" },
                    { "eaab8f23-d643-4d6f-9d34-78c1e7d392cd", "cc671c7d-5b8d-4351-9d02-098c0c41fc73", "Beneficiarie", "BENEFICIARIE" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "TypeComplaints",
                columns: new[] { "Id", "CreatedDate", "Type", "UserId", "UsersNameAddType" },
                values: new object[,]
                {
                    { "95601674-3690-40a5-b918-d9e4de8c40b5", new DateTime(2022, 8, 24, 23, 11, 0, 412, DateTimeKind.Local).AddTicks(6825), "زراعية", null, null },
                    { "f541e325-f544-4332-8d5c-ec399637f476", new DateTime(2022, 8, 24, 23, 11, 0, 412, DateTimeKind.Local).AddTicks(7617), "فساد", null, null },
                    { "f990403e-d059-4e3a-ae59-f5d5fbac7f7d", new DateTime(2022, 8, 24, 23, 11, 0, 412, DateTimeKind.Local).AddTicks(7632), "مماطلة", null, null },
                    { "9c8059a4-e483-4430-a467-33e0aceeff5f", new DateTime(2022, 8, 24, 23, 11, 0, 412, DateTimeKind.Local).AddTicks(7649), "إرتشاء", null, null }
                });
        }
    }
}
