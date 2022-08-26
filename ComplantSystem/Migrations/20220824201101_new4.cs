using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComplantSystem.Migrations
{
    public partial class new4 : Migration
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
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
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
                name: "TypeComplaints",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValueSql: "NEWID()"),
                    Type = table.Column<string>(type: "varchar(150)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UsersNameAddType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeComplaints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypeComplaints_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UsersHasId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Titile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    reason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersCommunications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersCommunications_User_UsersHasId",
                        column: x => x.UsersHasId,
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
                    VillagesId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OriginalFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                        name: "FK_UploadsComplaintes_TypeComplaints_TypeComplaintId",
                        column: x => x.TypeComplaintId,
                        principalSchema: "Identity",
                        principalTable: "TypeComplaints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UploadsComplaintes_User_HoUserId",
                        column: x => x.HoUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UploadsComplaintes_Villages_VillagesId",
                        column: x => x.VillagesId,
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
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAddSolutionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CompalintId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UploadsComplainteId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ContentSolution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateSolution = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                        name: "FK_Compalints_Solutions_User_UserAddSolutionId",
                        column: x => x.UserAddSolutionId,
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
                    { "ad01d0f3-7216-487a-9ca6-870082a19218", "67e65c81-4113-419d-9a10-93698c6b41f7", "AdminGeneralFederation", "ADMINGENERALFEDERATION" },
                    { "d50b3050-7ca8-4066-8834-1ca856339fae", "30137725-f310-4d72-9bf2-0fad76d19a58", "AdminGovernorate", "ADMINGOVERNORATE" },
                    { "23849cc6-e2ce-4d22-8500-2ab055e29163", "13f85dc4-f00c-4512-8ea8-b77807097578", "AdminDirectorate", "ADMINDIRECTORATE" },
                    { "6f2f6dd1-cbab-4c23-8339-09cfb435f61f", "451410a4-44f4-4e82-8c77-aa7091b6874b", "AdminSubDirectorate", "ADMINSUBDIRECTORATE" },
                    { "2fd37af7-3bd2-42a6-9c44-1b7259a3dba2", "8ff0b20d-6db2-44bf-835a-aaeac8750c57", "AdminVillages", "ADMINVILLAGES" },
                    { "eaab8f23-d643-4d6f-9d34-78c1e7d392cd", "cc671c7d-5b8d-4351-9d02-098c0c41fc73", "Beneficiarie", "BENEFICIARIE" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Societys",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "جمعية البن" },
                    { 2, "جمعية الالبان" },
                    { 3, "جمعية الحبوب" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "StagesComplaints",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 5, "الإتحاد العام" },
                    { 4, "المحافظة" },
                    { 1, "القرية" },
                    { 2, "العزلة" },
                    { 3, "المديرية" }
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
                table: "TypeComplaints",
                columns: new[] { "Id", "CreatedDate", "Type", "UserId", "UsersNameAddType" },
                values: new object[,]
                {
                    { "f990403e-d059-4e3a-ae59-f5d5fbac7f7d", new DateTime(2022, 8, 24, 23, 11, 0, 412, DateTimeKind.Local).AddTicks(7632), "مماطلة", null, null },
                    { "95601674-3690-40a5-b918-d9e4de8c40b5", new DateTime(2022, 8, 24, 23, 11, 0, 412, DateTimeKind.Local).AddTicks(6825), "زراعية", null, null },
                    { "f541e325-f544-4332-8d5c-ec399637f476", new DateTime(2022, 8, 24, 23, 11, 0, 412, DateTimeKind.Local).AddTicks(7617), "فساد", null, null },
                    { "9c8059a4-e483-4430-a467-33e0aceeff5f", new DateTime(2022, 8, 24, 23, 11, 0, 412, DateTimeKind.Local).AddTicks(7649), "إرتشاء", null, null }
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
                name: "IX_Compalints_Solutions_UserAddSolutionId",
                schema: "Identity",
                table: "Compalints_Solutions",
                column: "UserAddSolutionId");

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
                name: "IX_TypeComplaints_UserId",
                schema: "Identity",
                table: "TypeComplaints",
                column: "UserId");

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
                name: "IX_UploadsComplaintes_HoUserId",
                schema: "Identity",
                table: "UploadsComplaintes",
                column: "HoUserId");

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
                name: "IX_UploadsComplaintes_TypeComplaintId",
                schema: "Identity",
                table: "UploadsComplaintes",
                column: "TypeComplaintId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadsComplaintes_VillagesId",
                schema: "Identity",
                table: "UploadsComplaintes",
                column: "VillagesId");

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
                name: "IX_UsersCommunications_UsersHasId",
                schema: "Identity",
                table: "UsersCommunications",
                column: "UsersHasId");

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
