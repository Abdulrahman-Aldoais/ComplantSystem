using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ComplantSystem.Migrations
{
    public partial class sfsfa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersCommunications_User_UsersHasId",
                schema: "Identity",
                table: "UsersCommunications");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "0d6f9502-db09-4163-999a-310b507e9dc2");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "51e4af46-5b8d-4b87-a8fb-67786c7304c8");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6330bc07-3985-4ce5-b5ae-67ea4eb9ed24");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6caa4ff9-f398-4525-8a4d-198b9c2ac17f");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "d7f7f7ce-e350-4e81-a443-c510e4f1732b");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e9257003-6e9a-4fc2-a005-f180a603868e");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "c8145422-a2d6-4c6f-b324-a095232d438f");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "fe05cbf4-62bd-4657-bc58-770b3cb2298f");

            migrationBuilder.RenameColumn(
                name: "UsersHasId",
                schema: "Identity",
                table: "UsersCommunications",
                newName: "TypeCommuncationId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersCommunications_UsersHasId",
                schema: "Identity",
                table: "UsersCommunications",
                newName: "IX_UsersCommunications_TypeCommuncationId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "Identity",
                table: "UsersCommunications",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BenfDirId",
                schema: "Identity",
                table: "UsersCommunications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BenfGovId",
                schema: "Identity",
                table: "UsersCommunications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BenfId",
                schema: "Identity",
                table: "UsersCommunications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "BenfName",
                schema: "Identity",
                table: "UsersCommunications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BenfPhoneNumber",
                schema: "Identity",
                table: "UsersCommunications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BenfSubDirId",
                schema: "Identity",
                table: "UsersCommunications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                schema: "Identity",
                table: "UsersCommunications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(9)",
                oldMaxLength: 9);

            migrationBuilder.AlterColumn<string>(
                name: "IdentityNumber",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "19a78a39-19b2-4bf2-a199-e721e1d6e8c1", "6a13c768-1704-4bad-b0e6-753a924c6539", "AdminGeneralFederation", "ADMINGENERALFEDERATION" },
                    { "392afc51-dcf8-43c1-b477-9bc5f4ab21fb", "bb5c50ba-445e-4314-a31a-0bc9fe28884f", "AdminGovernorate", "ADMINGOVERNORATE" },
                    { "863bc173-fa57-4fbe-abdc-07da33fd911d", "6fac5943-ae29-42f5-aa64-e77ab3a166c5", "AdminDirectorate", "ADMINDIRECTORATE" },
                    { "bea63c98-d68d-41b8-ab1b-e40652f0777f", "39a8b7a7-0434-4e1f-9b53-f1f55b7178c5", "AdminSubDirectorate", "ADMINSUBDIRECTORATE" },
                    { "e12a910c-cd35-416f-88f2-b1abebb3e151", "b57da93e-4216-4e6b-8458-374c90071c1b", "AdminVillages", "ADMINVILLAGES" },
                    { "8942f471-65b8-43c4-9a6a-e0cc7c10519c", "b0a2978b-4c7a-41d8-b1b6-0e9b2ee7554e", "Beneficiarie", "BENEFICIARIE" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "TypeComplaints",
                columns: new[] { "Id", "CreatedDate", "Type", "UserId", "UsersNameAddType" },
                values: new object[,]
                {
                    { "f46db8a2-965d-4e6c-8cf3-8ec5a91fa18b", new DateTime(2022, 9, 3, 0, 14, 33, 836, DateTimeKind.Local).AddTicks(7378), "زراعية", null, "قيمة افتراضية من النضام" },
                    { "5a838edf-b9a4-4577-a86f-896f5503cd0e", new DateTime(2022, 9, 3, 0, 14, 33, 836, DateTimeKind.Local).AddTicks(7893), "فساد", null, "قيمة افتراضية من النضام" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersCommunications_BenfDirId",
                schema: "Identity",
                table: "UsersCommunications",
                column: "BenfDirId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersCommunications_BenfGovId",
                schema: "Identity",
                table: "UsersCommunications",
                column: "BenfGovId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersCommunications_BenfSubDirId",
                schema: "Identity",
                table: "UsersCommunications",
                column: "BenfSubDirId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersCommunications_UserId",
                schema: "Identity",
                table: "UsersCommunications",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersCommunications_Directorates_BenfDirId",
                schema: "Identity",
                table: "UsersCommunications",
                column: "BenfDirId",
                principalSchema: "Identity",
                principalTable: "Directorates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersCommunications_Governorates_BenfGovId",
                schema: "Identity",
                table: "UsersCommunications",
                column: "BenfGovId",
                principalSchema: "Identity",
                principalTable: "Governorates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersCommunications_SubDirectorates_BenfSubDirId",
                schema: "Identity",
                table: "UsersCommunications",
                column: "BenfSubDirId",
                principalSchema: "Identity",
                principalTable: "SubDirectorates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersCommunications_TypeCommunications_TypeCommuncationId",
                schema: "Identity",
                table: "UsersCommunications",
                column: "TypeCommuncationId",
                principalSchema: "Identity",
                principalTable: "TypeCommunications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersCommunications_User_UserId",
                schema: "Identity",
                table: "UsersCommunications",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersCommunications_Directorates_BenfDirId",
                schema: "Identity",
                table: "UsersCommunications");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersCommunications_Governorates_BenfGovId",
                schema: "Identity",
                table: "UsersCommunications");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersCommunications_SubDirectorates_BenfSubDirId",
                schema: "Identity",
                table: "UsersCommunications");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersCommunications_TypeCommunications_TypeCommuncationId",
                schema: "Identity",
                table: "UsersCommunications");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersCommunications_User_UserId",
                schema: "Identity",
                table: "UsersCommunications");

            migrationBuilder.DropIndex(
                name: "IX_UsersCommunications_BenfDirId",
                schema: "Identity",
                table: "UsersCommunications");

            migrationBuilder.DropIndex(
                name: "IX_UsersCommunications_BenfGovId",
                schema: "Identity",
                table: "UsersCommunications");

            migrationBuilder.DropIndex(
                name: "IX_UsersCommunications_BenfSubDirId",
                schema: "Identity",
                table: "UsersCommunications");

            migrationBuilder.DropIndex(
                name: "IX_UsersCommunications_UserId",
                schema: "Identity",
                table: "UsersCommunications");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "19a78a39-19b2-4bf2-a199-e721e1d6e8c1");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "392afc51-dcf8-43c1-b477-9bc5f4ab21fb");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "863bc173-fa57-4fbe-abdc-07da33fd911d");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "8942f471-65b8-43c4-9a6a-e0cc7c10519c");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "bea63c98-d68d-41b8-ab1b-e40652f0777f");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e12a910c-cd35-416f-88f2-b1abebb3e151");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "5a838edf-b9a4-4577-a86f-896f5503cd0e");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "TypeComplaints",
                keyColumn: "Id",
                keyValue: "f46db8a2-965d-4e6c-8cf3-8ec5a91fa18b");

            migrationBuilder.DropColumn(
                name: "BenfDirId",
                schema: "Identity",
                table: "UsersCommunications");

            migrationBuilder.DropColumn(
                name: "BenfGovId",
                schema: "Identity",
                table: "UsersCommunications");

            migrationBuilder.DropColumn(
                name: "BenfId",
                schema: "Identity",
                table: "UsersCommunications");

            migrationBuilder.DropColumn(
                name: "BenfName",
                schema: "Identity",
                table: "UsersCommunications");

            migrationBuilder.DropColumn(
                name: "BenfPhoneNumber",
                schema: "Identity",
                table: "UsersCommunications");

            migrationBuilder.DropColumn(
                name: "BenfSubDirId",
                schema: "Identity",
                table: "UsersCommunications");

            migrationBuilder.DropColumn(
                name: "UserName",
                schema: "Identity",
                table: "UsersCommunications");

            migrationBuilder.RenameColumn(
                name: "TypeCommuncationId",
                schema: "Identity",
                table: "UsersCommunications",
                newName: "UsersHasId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersCommunications_TypeCommuncationId",
                schema: "Identity",
                table: "UsersCommunications",
                newName: "IX_UsersCommunications_UsersHasId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "Identity",
                table: "UsersCommunications",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                schema: "Identity",
                table: "User",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdentityNumber",
                schema: "Identity",
                table: "User",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                schema: "Identity",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e9257003-6e9a-4fc2-a005-f180a603868e", "0be6e4d0-f87e-448b-92d4-8301b0940b53", "AdminGeneralFederation", "ADMINGENERALFEDERATION" },
                    { "6caa4ff9-f398-4525-8a4d-198b9c2ac17f", "2a67f865-857d-45ca-8785-9a9f0d681bce", "AdminGovernorate", "ADMINGOVERNORATE" },
                    { "d7f7f7ce-e350-4e81-a443-c510e4f1732b", "76c6b905-a62e-4971-bbd6-0047c6fd8b24", "AdminDirectorate", "ADMINDIRECTORATE" },
                    { "51e4af46-5b8d-4b87-a8fb-67786c7304c8", "b69dfce1-df36-4c72-ad35-d4630242efd3", "AdminSubDirectorate", "ADMINSUBDIRECTORATE" },
                    { "6330bc07-3985-4ce5-b5ae-67ea4eb9ed24", "8f0243c9-fe88-4e24-bb5a-c5fe829adbfc", "AdminVillages", "ADMINVILLAGES" },
                    { "0d6f9502-db09-4163-999a-310b507e9dc2", "d4d8dc9b-1bc3-4c87-8847-53f52b634ec3", "Beneficiarie", "BENEFICIARIE" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "TypeComplaints",
                columns: new[] { "Id", "CreatedDate", "Type", "UserId", "UsersNameAddType" },
                values: new object[,]
                {
                    { "fe05cbf4-62bd-4657-bc58-770b3cb2298f", new DateTime(2022, 8, 31, 17, 28, 27, 687, DateTimeKind.Local).AddTicks(2551), "زراعية", null, "قيمة افتراضية من النضام" },
                    { "c8145422-a2d6-4c6f-b324-a095232d438f", new DateTime(2022, 8, 31, 17, 28, 27, 687, DateTimeKind.Local).AddTicks(3117), "فساد", null, "قيمة افتراضية من النضام" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UsersCommunications_User_UsersHasId",
                schema: "Identity",
                table: "UsersCommunications",
                column: "UsersHasId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
