using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComplantSystem.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.CreateTable(
                name: "BenefCommunication",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValueSql: "NEWID()"),
                    TypeCommunicationId = table.Column<string>(type: "varchar(100)", nullable: false),
                    CommunDescribed = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    BeneficiariesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenefCommunication", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Governorates",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governorates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LimitationOrders",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    UserResponsibleId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LimitationOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Societys",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Societys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StagesComplaints",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StagesComplaints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusCompalints",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusCompalints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeBeneficiari",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<string>(type: "varchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeBeneficiari", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeCommunications",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<string>(type: "varchar(150)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsersNameAddType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeCommunications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeComplaints",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValueSql: "NEWID()"),
                    Type = table.Column<string>(type: "varchar(150)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsersNameAddType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeComplaints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Directorates",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GovernorateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directorates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Directorates_Governorates_GovernorateId",
                        column: x => x.GovernorateId,
                        principalSchema: "Identity",
                        principalTable: "Governorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId1",
                        column: x => x.RoleId1,
                        principalSchema: "Identity",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectorates",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DirectorateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectorates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectorates_Directorates_DirectorateId",
                        column: x => x.DirectorateId,
                        principalSchema: "Identity",
                        principalTable: "Directorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UploadsComplaintes",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValueSql: "NEWID()"),
                    TitleComplaint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeComplaintId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DescComplaint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SocietyId = table.Column<int>(type: "int", nullable: true),
                    StatusCompalintId = table.Column<int>(type: "int", nullable: false),
                    StagesComplaintId = table.Column<int>(type: "int", nullable: false),
                    PropBeneficiarie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GovernorateId = table.Column<int>(type: "int", nullable: false),
                    DirectorateId = table.Column<int>(type: "int", nullable: false),
                    SubDirectorateId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeCommunicationId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadsComplaintes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UploadsComplaintes_Directorates_DirectorateId",
                        column: x => x.DirectorateId,
                        principalSchema: "Identity",
                        principalTable: "Directorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UploadsComplaintes_Governorates_GovernorateId",
                        column: x => x.GovernorateId,
                        principalSchema: "Identity",
                        principalTable: "Governorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UploadsComplaintes_Societys_SocietyId",
                        column: x => x.SocietyId,
                        principalSchema: "Identity",
                        principalTable: "Societys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UploadsComplaintes_StagesComplaints_StagesComplaintId",
                        column: x => x.StagesComplaintId,
                        principalSchema: "Identity",
                        principalTable: "StagesComplaints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UploadsComplaintes_StatusCompalints_StatusCompalintId",
                        column: x => x.StatusCompalintId,
                        principalSchema: "Identity",
                        principalTable: "StatusCompalints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UploadsComplaintes_SubDirectorates_SubDirectorateId",
                        column: x => x.SubDirectorateId,
                        principalSchema: "Identity",
                        principalTable: "SubDirectorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UploadsComplaintes_TypeCommunications_TypeCommunicationId",
                        column: x => x.TypeCommunicationId,
                        principalSchema: "Identity",
                        principalTable: "TypeCommunications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UploadsComplaintes_TypeComplaints_TypeComplaintId",
                        column: x => x.TypeComplaintId,
                        principalSchema: "Identity",
                        principalTable: "TypeComplaints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Villages",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubDirectorateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Villages_SubDirectorates_SubDirectorateId",
                        column: x => x.SubDirectorateId,
                        principalSchema: "Identity",
                        principalTable: "SubDirectorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GovernorateId = table.Column<int>(type: "int", nullable: false),
                    DirectorateId = table.Column<int>(type: "int", nullable: false),
                    SubDirectorateId = table.Column<int>(type: "int", nullable: false),
                    SocietyId = table.Column<int>(type: "int", nullable: true),
                    ProfilePicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    originatorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ApplicationRoleId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    VillageId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Directorates_DirectorateId",
                        column: x => x.DirectorateId,
                        principalSchema: "Identity",
                        principalTable: "Directorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Governorates_GovernorateId",
                        column: x => x.GovernorateId,
                        principalSchema: "Identity",
                        principalTable: "Governorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Roles_ApplicationRoleId",
                        column: x => x.ApplicationRoleId,
                        principalSchema: "Identity",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Societys_SocietyId",
                        column: x => x.SocietyId,
                        principalSchema: "Identity",
                        principalTable: "Societys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_SubDirectorates_SubDirectorateId",
                        column: x => x.SubDirectorateId,
                        principalSchema: "Identity",
                        principalTable: "SubDirectorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Villages_VillageId",
                        column: x => x.VillageId,
                        principalSchema: "Identity",
                        principalTable: "Villages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Beneficiaries",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValueSql: "NEWID()"),
                    IdentityNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AdminId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GovernorateId = table.Column<int>(type: "int", nullable: true),
                    DirectorateId = table.Column<int>(type: "int", nullable: true),
                    SubDirectorateId = table.Column<int>(type: "int", nullable: true),
                    VillageId = table.Column<int>(type: "int", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "تحديد وقت ادخال الصف في قاعدية البيانات"),
                    Update_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeBeneficiariId = table.Column<int>(type: "int", nullable: true),
                    TypeBeneficiarisId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficiaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_Directorates_DirectorateId",
                        column: x => x.DirectorateId,
                        principalSchema: "Identity",
                        principalTable: "Directorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_Governorates_GovernorateId",
                        column: x => x.GovernorateId,
                        principalSchema: "Identity",
                        principalTable: "Governorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_SubDirectorates_SubDirectorateId",
                        column: x => x.SubDirectorateId,
                        principalSchema: "Identity",
                        principalTable: "SubDirectorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_TypeBeneficiari_TypeBeneficiarisId",
                        column: x => x.TypeBeneficiarisId,
                        principalSchema: "Identity",
                        principalTable: "TypeBeneficiari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_User_AdminId",
                        column: x => x.AdminId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_Villages_VillageId",
                        column: x => x.VillageId,
                        principalSchema: "Identity",
                        principalTable: "Villages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserClaims_User_UserId1",
                        column: x => x.UserId1,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "Identity",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLogins_User_UserId1",
                        column: x => x.UserId1,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_User_UserId1",
                        column: x => x.UserId1,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersCommunications",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BenfId = table.Column<int>(type: "int", nullable: false),
                    BenfName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BenfPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GovernorateId = table.Column<int>(type: "int", nullable: false),
                    DirectorateId = table.Column<int>(type: "int", nullable: false),
                    SubDirectorateId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NameUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeCommuncationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeCommunicationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Titile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    reason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersCommunications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersCommunications_Directorates_DirectorateId",
                        column: x => x.DirectorateId,
                        principalSchema: "Identity",
                        principalTable: "Directorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersCommunications_Governorates_GovernorateId",
                        column: x => x.GovernorateId,
                        principalSchema: "Identity",
                        principalTable: "Governorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersCommunications_SubDirectorates_SubDirectorateId",
                        column: x => x.SubDirectorateId,
                        principalSchema: "Identity",
                        principalTable: "SubDirectorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersCommunications_TypeCommunications_TypeCommunicationId",
                        column: x => x.TypeCommunicationId,
                        principalSchema: "Identity",
                        principalTable: "TypeCommunications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersCommunications_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTokens_User_UserId1",
                        column: x => x.UserId1,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BenefCommunicationBeneficiarie",
                schema: "Identity",
                columns: table => new
                {
                    BenefCommunicationsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BeneficiariesId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenefCommunicationBeneficiarie", x => new { x.BenefCommunicationsId, x.BeneficiariesId });
                    table.ForeignKey(
                        name: "FK_BenefCommunicationBeneficiarie_BenefCommunication_BenefCommunicationsId",
                        column: x => x.BenefCommunicationsId,
                        principalSchema: "Identity",
                        principalTable: "BenefCommunication",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BenefCommunicationBeneficiarie_Beneficiaries_BeneficiariesId",
                        column: x => x.BeneficiariesId,
                        principalSchema: "Identity",
                        principalTable: "Beneficiaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Communication_Counter",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Communic_Counter = table.Column<int>(type: "int", nullable: false),
                    BeneficiarieId = table.Column<int>(type: "int", nullable: false),
                    BeneficiariesId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BenefCommunicationId = table.Column<int>(type: "int", nullable: false),
                    BenefCommunicationsId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Communication_Counter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Communication_Counter_BenefCommunication_BenefCommunicationsId",
                        column: x => x.BenefCommunicationsId,
                        principalSchema: "Identity",
                        principalTable: "BenefCommunication",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Communication_Counter_Beneficiaries_BeneficiariesId",
                        column: x => x.BeneficiariesId,
                        principalSchema: "Identity",
                        principalTable: "Beneficiaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Proposals",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValueSql: "NEWID()"),
                    TitileProposal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescProposal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateSubmeted = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "تحديد وقت ادخال الصف في قاعدية البيانات"),
                    BeneficiarieId = table.Column<int>(type: "int", nullable: false),
                    BeneficiarieId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proposals_Beneficiaries_BeneficiarieId1",
                        column: x => x.BeneficiarieId1,
                        principalSchema: "Identity",
                        principalTable: "Beneficiaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UploadsComplainte",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TitleComplaint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeComplaintId = table.Column<int>(type: "int", nullable: false),
                    TypeComplaintId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DescComplaint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SocietyId = table.Column<int>(type: "int", nullable: true),
                    StatusCompalintId = table.Column<int>(type: "int", nullable: false),
                    StagesComplaintId = table.Column<int>(type: "int", nullable: false),
                    PropBeneficiarie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GovernorateId = table.Column<int>(type: "int", nullable: false),
                    DirectorateId = table.Column<int>(type: "int", nullable: true),
                    SubDirectorateId = table.Column<int>(type: "int", nullable: true),
                    VillageId = table.Column<int>(type: "int", nullable: true),
                    CompDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompDateUp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BeneficiarieId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadsComplainte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UploadsComplainte_Beneficiaries_BeneficiarieId",
                        column: x => x.BeneficiarieId,
                        principalSchema: "Identity",
                        principalTable: "Beneficiaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UploadsComplainte_Directorates_DirectorateId",
                        column: x => x.DirectorateId,
                        principalSchema: "Identity",
                        principalTable: "Directorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UploadsComplainte_Governorates_GovernorateId",
                        column: x => x.GovernorateId,
                        principalSchema: "Identity",
                        principalTable: "Governorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UploadsComplainte_Societys_SocietyId",
                        column: x => x.SocietyId,
                        principalSchema: "Identity",
                        principalTable: "Societys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UploadsComplainte_StagesComplaints_StagesComplaintId",
                        column: x => x.StagesComplaintId,
                        principalSchema: "Identity",
                        principalTable: "StagesComplaints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UploadsComplainte_StatusCompalints_StatusCompalintId",
                        column: x => x.StatusCompalintId,
                        principalSchema: "Identity",
                        principalTable: "StatusCompalints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UploadsComplainte_SubDirectorates_SubDirectorateId",
                        column: x => x.SubDirectorateId,
                        principalSchema: "Identity",
                        principalTable: "SubDirectorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UploadsComplainte_TypeComplaints_TypeComplaintId1",
                        column: x => x.TypeComplaintId1,
                        principalSchema: "Identity",
                        principalTable: "TypeComplaints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UploadsComplainte_User_HoUserId",
                        column: x => x.HoUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UploadsComplainte_Villages_VillageId",
                        column: x => x.VillageId,
                        principalSchema: "Identity",
                        principalTable: "Villages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Compalints_Solutions",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UploadsComplainteId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SolutionProvName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolutionProvIdentity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAccept = table.Column<bool>(type: "bit", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentSolution = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateSolution = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompalintId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compalints_Solutions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compalints_Solutions_UploadsComplainte_CompalintId",
                        column: x => x.CompalintId,
                        principalSchema: "Identity",
                        principalTable: "UploadsComplainte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Compalints_Solutions_UploadsComplaintes_UploadsComplainteId",
                        column: x => x.UploadsComplainteId,
                        principalSchema: "Identity",
                        principalTable: "UploadsComplaintes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Compalints_Solutions_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Governorates",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "صنعاء" },
                    { 2, " تعز" },
                    { 3, "الحديدة" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a4937029-c56c-4663-8934-378d6f46efd9", "bd31e929-2692-4a55-8251-9972f3535774", "AdminGeneralFederation", "ADMINGENERALFEDERATION" },
                    { "719899a2-536c-4577-9b84-8809c630ef8d", "81abcb67-69dc-4417-a973-84f42b42028c", "AdminGovernorate", "ADMINGOVERNORATE" },
                    { "9698bd6c-624f-4a5d-9b00-a84aafa0949f", "669bea7e-a57c-4309-b9eb-6f64ea9e7ff2", "AdminDirectorate", "ADMINDIRECTORATE" },
                    { "295cc8ea-7c73-495b-b459-123727da106b", "5d0fe835-591d-44b7-bad5-70a6ca1c8793", "AdminSubDirectorate", "ADMINSUBDIRECTORATE" },
                    { "b3266bc9-9394-49e1-9804-a1c1226fd3d9", "f5983285-5c20-43b9-b1b6-1defc928dd8d", "AdminVillages", "ADMINVILLAGES" },
                    { "28a9ffdb-4eff-4006-b5ba-c262bb6542b2", "c38676c3-571c-4d9d-a375-b9ea42c3a90e", "Beneficiarie", "BENEFICIARIE" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Societys",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "جمعية الالبان" },
                    { 3, "جمعية الحبوب" },
                    { 1, "جمعية البن" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "StagesComplaints",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "العزلة" },
                    { 2, "المديرية" },
                    { 3, "المحافظة" },
                    { 4, "الإتحاد العام" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "StatusCompalints",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "جديدة" },
                    { 2, "محلولة" },
                    { 3, "مرفوضة" },
                    { 4, "معلقة" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "TypeCommunications",
                columns: new[] { "Id", "CreatedDate", "Type", "UserId", "UsersNameAddType" },
                values: new object[,]
                {
                    { "0198b446-8a7a-4ebb-95ac-9d2d5a4d66ad", new DateTime(2022, 9, 4, 1, 15, 34, 82, DateTimeKind.Local).AddTicks(8000), "تماطل", null, "قيمة افتراضية من النضام" },
                    { "61fb9506-0240-43e0-a8ac-d295994906d8", new DateTime(2022, 9, 4, 1, 15, 34, 82, DateTimeKind.Local).AddTicks(8773), "تلاعب بالحلول", null, "قيمة افتراضية من النضام" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "TypeComplaints",
                columns: new[] { "Id", "CreatedDate", "Type", "UserId", "UsersNameAddType" },
                values: new object[,]
                {
                    { "3c6d604f-1570-44a6-bc4f-a4b47abc30ca", new DateTime(2022, 9, 4, 1, 15, 34, 88, DateTimeKind.Local).AddTicks(199), "زراعية", null, "قيمة افتراضية من النضام" },
                    { "570dc7b7-be5a-4303-9311-b146ec16d04a", new DateTime(2022, 9, 4, 1, 15, 34, 88, DateTimeKind.Local).AddTicks(1071), "فساد", null, "قيمة افتراضية من النضام" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Directorates",
                columns: new[] { "Id", "GovernorateId", "Name" },
                values: new object[] { 3, 1, "همدان" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Directorates",
                columns: new[] { "Id", "GovernorateId", "Name" },
                values: new object[] { 1, 2, "شرعب السلام" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Directorates",
                columns: new[] { "Id", "GovernorateId", "Name" },
                values: new object[] { 2, 2, "شرعب الرونة" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "SubDirectorates",
                columns: new[] { "Id", "DirectorateId", "Name" },
                values: new object[] { 3, 3, " بني سعد" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "SubDirectorates",
                columns: new[] { "Id", "DirectorateId", "Name" },
                values: new object[] { 1, 1, " القفاعة" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "SubDirectorates",
                columns: new[] { "Id", "DirectorateId", "Name" },
                values: new object[] { 2, 1, " المخلاف" });

            migrationBuilder.CreateIndex(
                name: "IX_BenefCommunicationBeneficiarie_BeneficiariesId",
                schema: "Identity",
                table: "BenefCommunicationBeneficiarie",
                column: "BeneficiariesId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_AdminId",
                schema: "Identity",
                table: "Beneficiaries",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_DirectorateId",
                schema: "Identity",
                table: "Beneficiaries",
                column: "DirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_GovernorateId",
                schema: "Identity",
                table: "Beneficiaries",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_SubDirectorateId",
                schema: "Identity",
                table: "Beneficiaries",
                column: "SubDirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_TypeBeneficiarisId",
                schema: "Identity",
                table: "Beneficiaries",
                column: "TypeBeneficiarisId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_VillageId",
                schema: "Identity",
                table: "Beneficiaries",
                column: "VillageId");

            migrationBuilder.CreateIndex(
                name: "IX_Communication_Counter_BenefCommunicationsId",
                schema: "Identity",
                table: "Communication_Counter",
                column: "BenefCommunicationsId");

            migrationBuilder.CreateIndex(
                name: "IX_Communication_Counter_BeneficiariesId",
                schema: "Identity",
                table: "Communication_Counter",
                column: "BeneficiariesId");

            migrationBuilder.CreateIndex(
                name: "IX_Compalints_Solutions_CompalintId",
                schema: "Identity",
                table: "Compalints_Solutions",
                column: "CompalintId");

            migrationBuilder.CreateIndex(
                name: "IX_Compalints_Solutions_UploadsComplainteId",
                schema: "Identity",
                table: "Compalints_Solutions",
                column: "UploadsComplainteId");

            migrationBuilder.CreateIndex(
                name: "IX_Compalints_Solutions_UserId",
                schema: "Identity",
                table: "Compalints_Solutions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Directorates_GovernorateId",
                schema: "Identity",
                table: "Directorates",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_BeneficiarieId1",
                schema: "Identity",
                table: "Proposals",
                column: "BeneficiarieId1");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "Identity",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId1",
                schema: "Identity",
                table: "RoleClaims",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Identity",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectorates_DirectorateId",
                schema: "Identity",
                table: "SubDirectorates",
                column: "DirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplainte_BeneficiarieId",
                schema: "Identity",
                table: "UploadsComplainte",
                column: "BeneficiarieId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplainte_DirectorateId",
                schema: "Identity",
                table: "UploadsComplainte",
                column: "DirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplainte_GovernorateId",
                schema: "Identity",
                table: "UploadsComplainte",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplainte_HoUserId",
                schema: "Identity",
                table: "UploadsComplainte",
                column: "HoUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplainte_SocietyId",
                schema: "Identity",
                table: "UploadsComplainte",
                column: "SocietyId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplainte_StagesComplaintId",
                schema: "Identity",
                table: "UploadsComplainte",
                column: "StagesComplaintId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplainte_StatusCompalintId",
                schema: "Identity",
                table: "UploadsComplainte",
                column: "StatusCompalintId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplainte_SubDirectorateId",
                schema: "Identity",
                table: "UploadsComplainte",
                column: "SubDirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplainte_TypeComplaintId1",
                schema: "Identity",
                table: "UploadsComplainte",
                column: "TypeComplaintId1");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplainte_VillageId",
                schema: "Identity",
                table: "UploadsComplainte",
                column: "VillageId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplaintes_DirectorateId",
                schema: "Identity",
                table: "UploadsComplaintes",
                column: "DirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplaintes_GovernorateId",
                schema: "Identity",
                table: "UploadsComplaintes",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplaintes_SocietyId",
                schema: "Identity",
                table: "UploadsComplaintes",
                column: "SocietyId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplaintes_StagesComplaintId",
                schema: "Identity",
                table: "UploadsComplaintes",
                column: "StagesComplaintId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplaintes_StatusCompalintId",
                schema: "Identity",
                table: "UploadsComplaintes",
                column: "StatusCompalintId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplaintes_SubDirectorateId",
                schema: "Identity",
                table: "UploadsComplaintes",
                column: "SubDirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplaintes_TypeCommunicationId",
                schema: "Identity",
                table: "UploadsComplaintes",
                column: "TypeCommunicationId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplaintes_TypeComplaintId",
                schema: "Identity",
                table: "UploadsComplaintes",
                column: "TypeComplaintId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Identity",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_User_ApplicationRoleId",
                schema: "Identity",
                table: "User",
                column: "ApplicationRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_User_DirectorateId",
                schema: "Identity",
                table: "User",
                column: "DirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_User_GovernorateId",
                schema: "Identity",
                table: "User",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_User_SocietyId",
                schema: "Identity",
                table: "User",
                column: "SocietyId");

            migrationBuilder.CreateIndex(
                name: "IX_User_SubDirectorateId",
                schema: "Identity",
                table: "User",
                column: "SubDirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_User_VillageId",
                schema: "Identity",
                table: "User",
                column: "VillageId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Identity",
                table: "User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "Identity",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId1",
                schema: "Identity",
                table: "UserClaims",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                schema: "Identity",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId1",
                schema: "Identity",
                table: "UserLogins",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "Identity",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId1",
                schema: "Identity",
                table: "UserRoles",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_UsersCommunications_DirectorateId",
                schema: "Identity",
                table: "UsersCommunications",
                column: "DirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersCommunications_GovernorateId",
                schema: "Identity",
                table: "UsersCommunications",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersCommunications_SubDirectorateId",
                schema: "Identity",
                table: "UsersCommunications",
                column: "SubDirectorateId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersCommunications_TypeCommunicationId",
                schema: "Identity",
                table: "UsersCommunications",
                column: "TypeCommunicationId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersCommunications_UserId",
                schema: "Identity",
                table: "UsersCommunications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTokens_UserId1",
                schema: "Identity",
                table: "UserTokens",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Villages_SubDirectorateId",
                schema: "Identity",
                table: "Villages",
                column: "SubDirectorateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BenefCommunicationBeneficiarie",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Communication_Counter",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Compalints_Solutions",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "LimitationOrders",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Proposals",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UsersCommunications",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "BenefCommunication",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UploadsComplainte",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UploadsComplaintes",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Beneficiaries",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "StagesComplaints",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "StatusCompalints",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "TypeCommunications",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "TypeComplaints",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "TypeBeneficiari",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Societys",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Villages",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "SubDirectorates",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Directorates",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Governorates",
                schema: "Identity");
        }
    }
}
