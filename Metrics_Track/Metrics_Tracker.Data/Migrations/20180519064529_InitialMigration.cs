namespace Metrics_Track.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Migrations;
    using System;
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CPS");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "CPS",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "CPS",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Holiday Table",
                schema: "CPS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Country = table.Column<string>(maxLength: 255, nullable: true),
                    Function_Name = table.Column<string>(maxLength: 255, nullable: true),
                    HolidayDate = table.Column<DateTime>(name: "Holiday Date", type: "datetime", nullable: true),
                    TeamLead = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holiday Table", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Activity",
                schema: "CPS",
                columns: table => new
                {
                    ID_Activity = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Activity = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Activity", x => x.ID_Activity);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Country",
                schema: "CPS",
                columns: table => new
                {
                    ID_Country = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Country = table.Column<string>(maxLength: 255, nullable: true),
                    RefSite = table.Column<string>(name: "Ref Site", maxLength: 255, nullable: true),
                    SPPH_ID_Country = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Country", x => x.ID_Country);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Division",
                schema: "CPS",
                columns: table => new
                {
                    ID_Division = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Division = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Division", x => x.ID_Division);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Internal_Errors_Log",
                schema: "CPS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Message = table.Column<string>(nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "smalldatetime", nullable: true, defaultValueSql: "(dateadd(hour,(3),getutcdate()))"),
                    UserName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Internal_Errors_Log", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_L2_ID",
                schema: "CPS",
                columns: table => new
                {
                    ID_Process = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    L2 = table.Column<string>(maxLength: 255, nullable: true),
                    L2_ID = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_L2_ID", x => x.ID_Process);
                });

            migrationBuilder.CreateTable(
                name: "tbl_LOB",
                schema: "CPS",
                columns: table => new
                {
                    ID_LOB = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LOB = table.Column<string>(maxLength: 255, nullable: true),
                    MMCPLOB = table.Column<string>(name: "MMCP LOB", maxLength: 50, nullable: true),
                    MMCPSEGMENT = table.Column<string>(name: "MMCP SEGMENT", maxLength: 50, nullable: true),
                    ProductLine1 = table.Column<string>(name: "Product Line 1", maxLength: 50, nullable: true),
                    ProductLine2 = table.Column<string>(name: "Product Line 2", maxLength: 50, nullable: true),
                    ProductLine3 = table.Column<string>(name: "Product Line 3", maxLength: 50, nullable: true),
                    SPPH_ID_PRODUCT = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_LOB", x => x.ID_LOB);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Login",
                schema: "CPS",
                columns: table => new
                {
                    ID_Login = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DisplayName = table.Column<string>(name: "Display Name", maxLength: 255, nullable: true),
                    Password = table.Column<string>(maxLength: 255, nullable: true),
                    Sandbox = table.Column<short>(nullable: false),
                    ServerName = table.Column<string>(maxLength: 255, nullable: true),
                    Site = table.Column<string>(maxLength: 10, nullable: true),
                    SSPH_ID_USER = table.Column<int>(nullable: true),
                    TeamLead = table.Column<string>(maxLength: 255, nullable: true),
                    UserName = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Login", x => x.ID_Login);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Mining",
                schema: "CPS",
                columns: table => new
                {
                    ID_Mining = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    State = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Mining", x => x.ID_Mining);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Objects",
                schema: "CPS",
                columns: table => new
                {
                    ID_Object = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CaptureText = table.Column<string>(maxLength: 255, nullable: true),
                    FieldName = table.Column<string>(maxLength: 50, nullable: true),
                    Height = table.Column<double>(nullable: true),
                    ID_Country = table.Column<int>(nullable: false),
                    IsVisible = table.Column<string>(maxLength: 255, nullable: true),
                    Location = table.Column<string>(maxLength: 255, nullable: true),
                    ObjectName = table.Column<string>(maxLength: 255, nullable: true),
                    ObjectType = table.Column<string>(maxLength: 255, nullable: true),
                    PositionLeft = table.Column<double>(nullable: true),
                    PositionTop = table.Column<double>(nullable: true),
                    Width = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Objects", x => x.ID_Object);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Process",
                schema: "CPS",
                columns: table => new
                {
                    ID_Process = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Function_Name = table.Column<string>(maxLength: 255, nullable: true),
                    Group = table.Column<string>(maxLength: 255, nullable: true),
                    Level2Taxonomy = table.Column<string>(name: "Level 2 Taxonomy", maxLength: 255, nullable: true),
                    Level3Taxonomy = table.Column<string>(name: "Level 3 Taxonomy", maxLength: 255, nullable: true),
                    MNC = table.Column<string>(maxLength: 50, nullable: false),
                    NiceQueue = table.Column<string>(name: "Nice Queue", maxLength: 50, nullable: true),
                    PID = table.Column<string>(maxLength: 50, nullable: true),
                    Process = table.Column<string>(maxLength: 255, nullable: true),
                    ProcessMap = table.Column<string>(name: "Process Map", maxLength: 255, nullable: true),
                    SLATarget = table.Column<string>(name: "SLA Target", maxLength: 50, nullable: true),
                    SLAType = table.Column<string>(name: "SLA Type", maxLength: 50, nullable: true),
                    SPPH_ID_PROCESS = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Process", x => x.ID_Process);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Quality_Integration",
                schema: "CPS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Quality_Pts_Scored = table.Column<double>(nullable: true),
                    Quality_Pts_Total = table.Column<double>(nullable: true),
                    Transaction_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Quality_Integration", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Reporting_Users",
                schema: "CPS",
                columns: table => new
                {
                    ID_User = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NTUser = table.Column<string>(unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Reporting_Users", x => x.ID_User);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Specific",
                schema: "CPS",
                columns: table => new
                {
                    ID_Spec = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ID_Main = table.Column<int>(nullable: true),
                    ID_Number = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Specific", x => x.ID_Spec);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Status",
                schema: "CPS",
                columns: table => new
                {
                    ID_Status = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Status", x => x.ID_Status);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Tower",
                schema: "CPS",
                columns: table => new
                {
                    ID_Tower = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tower = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Tower", x => x.ID_Tower);
                });

            migrationBuilder.CreateTable(
                name: "tbl_TowerCategory",
                schema: "CPS",
                columns: table => new
                {
                    ID_TowerCategory = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TowerCategory = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_TowerCategory", x => x.ID_TowerCategory);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Tracker_Ver",
                schema: "CPS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Change = table.Column<string>(maxLength: 500, nullable: true),
                    ChangeStamp = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(dateadd(hour,(3),getutcdate()))"),
                    Request = table.Column<string>(maxLength: 500, nullable: true),
                    Version = table.Column<string>(type: "nchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Tracker_Ver", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "CPS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "CPS",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "CPS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "CPS",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "CPS",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "CPS",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "CPS",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "CPS",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "CPS",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "CPS",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "CPS",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_UserActivity",
                schema: "CPS",
                columns: table => new
                {
                    ID_UserActivity = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChangeStamp = table.Column<DateTime>(type: "datetime", nullable: true),
                    Comment = table.Column<string>(type: "ntext", nullable: true),
                    ID_Login = table.Column<int>(nullable: true),
                    Metrics_Track_Ver = table.Column<string>(maxLength: 255, nullable: true),
                    Sandbox = table.Column<short>(nullable: false),
                    Type = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_UserActivity", x => x.ID_UserActivity);
                    table.ForeignKey(
                        name: "FK_tbl_UserActivity_tbl_Login",
                        column: x => x.ID_Login,
                        principalSchema: "CPS",
                        principalTable: "tbl_Login",
                        principalColumn: "ID_Login",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "trel_UserCountry",
                schema: "CPS",
                columns: table => new
                {
                    ID_UC = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ID_Country = table.Column<int>(nullable: true),
                    ID_Login = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trel_UserCountry", x => x.ID_UC);
                    table.ForeignKey(
                        name: "FK_trel_UserCountry_tbl_Country",
                        column: x => x.ID_Country,
                        principalSchema: "CPS",
                        principalTable: "tbl_Country",
                        principalColumn: "ID_Country",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trel_UserCountry_tbl_Login",
                        column: x => x.ID_Login,
                        principalSchema: "CPS",
                        principalTable: "tbl_Login",
                        principalColumn: "ID_Login",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "trel_UserMining",
                schema: "CPS",
                columns: table => new
                {
                    ID_UM = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ID_Login = table.Column<int>(nullable: true),
                    ID_Mining = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trel_UserMining", x => x.ID_UM);
                    table.ForeignKey(
                        name: "FK_trel_UserMining_tbl_Login",
                        column: x => x.ID_Login,
                        principalSchema: "CPS",
                        principalTable: "tbl_Login",
                        principalColumn: "ID_Login",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trel_UserMining_tbl_Mining",
                        column: x => x.ID_Mining,
                        principalSchema: "CPS",
                        principalTable: "tbl_Mining",
                        principalColumn: "ID_Mining",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "trel_CountryProcess",
                schema: "CPS",
                columns: table => new
                {
                    ID_CP = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ID_Country = table.Column<int>(nullable: true),
                    ID_Process = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trel_CountryProcess", x => x.ID_CP);
                    table.ForeignKey(
                        name: "FK_trel_CountryProcess_tbl_Country",
                        column: x => x.ID_Country,
                        principalSchema: "CPS",
                        principalTable: "tbl_Country",
                        principalColumn: "ID_Country",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trel_CountryProcess_tbl_Process",
                        column: x => x.ID_Process,
                        principalSchema: "CPS",
                        principalTable: "tbl_Process",
                        principalColumn: "ID_Process",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "trel_ProcessActivity",
                schema: "CPS",
                columns: table => new
                {
                    ID_PA = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ID_Activity = table.Column<int>(nullable: true),
                    ID_Process = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trel_ProcessActivity", x => x.ID_PA);
                    table.ForeignKey(
                        name: "FK_trel_ProcessActivity_tbl_Activity",
                        column: x => x.ID_Activity,
                        principalSchema: "CPS",
                        principalTable: "tbl_Activity",
                        principalColumn: "ID_Activity",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trel_ProcessActivity_tbl_Process",
                        column: x => x.ID_Process,
                        principalSchema: "CPS",
                        principalTable: "tbl_Process",
                        principalColumn: "ID_Process",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "trel_ProcessDivision",
                schema: "CPS",
                columns: table => new
                {
                    ID_PD = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ID_Division = table.Column<int>(nullable: true),
                    ID_Process = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trel_ProcessDivision", x => x.ID_PD);
                    table.ForeignKey(
                        name: "FK_trel_ProcessDivision_tbl_Division",
                        column: x => x.ID_Division,
                        principalSchema: "CPS",
                        principalTable: "tbl_Division",
                        principalColumn: "ID_Division",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trel_ProcessDivision_tbl_Process",
                        column: x => x.ID_Process,
                        principalSchema: "CPS",
                        principalTable: "tbl_Process",
                        principalColumn: "ID_Process",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "trel_ProcessLOB",
                schema: "CPS",
                columns: table => new
                {
                    ID_PL = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ID_LOB = table.Column<int>(nullable: true),
                    ID_Process = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trel_ProcessLOB", x => x.ID_PL);
                    table.ForeignKey(
                        name: "FK_trel_ProcessLOB_tbl_LOB",
                        column: x => x.ID_LOB,
                        principalSchema: "CPS",
                        principalTable: "tbl_LOB",
                        principalColumn: "ID_LOB",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trel_ProcessLOB_tbl_Process",
                        column: x => x.ID_Process,
                        principalSchema: "CPS",
                        principalTable: "tbl_Process",
                        principalColumn: "ID_Process",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "trel_ProcessStatus",
                schema: "CPS",
                columns: table => new
                {
                    ID_SP = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ID_Process = table.Column<int>(nullable: true),
                    ID_Status = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trel_ProcessStatus", x => x.ID_SP);
                    table.ForeignKey(
                        name: "FK_trel_ProcessStatus_tbl_Process",
                        column: x => x.ID_Process,
                        principalSchema: "CPS",
                        principalTable: "tbl_Process",
                        principalColumn: "ID_Process",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trel_ProcessStatus_tbl_Status",
                        column: x => x.ID_Status,
                        principalSchema: "CPS",
                        principalTable: "tbl_Status",
                        principalColumn: "ID_Status",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "trel_ProcessTower",
                schema: "CPS",
                columns: table => new
                {
                    ID_PT = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ID_Process = table.Column<int>(nullable: true),
                    ID_Tower = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trel_ProcessTower", x => x.ID_PT);
                    table.ForeignKey(
                        name: "FK_trel_ProcessTower_tbl_Process",
                        column: x => x.ID_Process,
                        principalSchema: "CPS",
                        principalTable: "tbl_Process",
                        principalColumn: "ID_Process",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trel_ProcessTower_tbl_Tower",
                        column: x => x.ID_Tower,
                        principalSchema: "CPS",
                        principalTable: "tbl_Tower",
                        principalColumn: "ID_Tower",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Volume_Main",
                schema: "CPS",
                columns: table => new
                {
                    Transaction_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Attachments = table.Column<string>(maxLength: 150, nullable: true),
                    Comment = table.Column<string>(type: "ntext", nullable: true),
                    CompleteDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Currency_Code = table.Column<string>(maxLength: 50, nullable: true),
                    Date_Received_in_AIG = table.Column<DateTime>(type: "datetime", nullable: true),
                    ID_Activity = table.Column<int>(nullable: true),
                    ID_Contract = table.Column<string>(maxLength: 50, nullable: true),
                    ID_Country = table.Column<int>(nullable: true),
                    ID_Division = table.Column<int>(nullable: true),
                    ID_LOB = table.Column<int>(nullable: true),
                    ID_Login = table.Column<int>(nullable: true),
                    ID_Number = table.Column<string>(maxLength: 500, nullable: true),
                    ID_Partner = table.Column<string>(maxLength: 50, nullable: true),
                    ID_Process = table.Column<int>(nullable: true),
                    ID_Status = table.Column<int>(nullable: true),
                    ID_Tower = table.Column<int>(nullable: true),
                    ID_TowerCategory = table.Column<int>(nullable: true),
                    Idle_Hours = table.Column<double>(nullable: true, defaultValueSql: "((0))"),
                    Inception_Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Insured_Name = table.Column<string>(maxLength: 150, nullable: true),
                    Original_ID = table.Column<int>(nullable: true),
                    PrecalcHT = table.Column<double>(name: "Precalc HT", nullable: true),
                    PrecalcSLAHours = table.Column<double>(name: "Precalc SLA Hours", nullable: true),
                    Premium = table.Column<double>(nullable: true),
                    Priority = table.Column<short>(nullable: true),
                    Quality_Inspection_Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Quality_Pts_Scored = table.Column<double>(nullable: true),
                    Quality_Pts_Total = table.Column<double>(nullable: true),
                    Quality_Reviewer = table.Column<string>(maxLength: 150, nullable: true),
                    ReceivedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Sandbox = table.Column<short>(nullable: false, defaultValueSql: "((0))"),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Status_Code = table.Column<short>(nullable: true),
                    Transaction_Requestor = table.Column<string>(maxLength: 150, nullable: true),
                    Work_Code = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Volume_Main", x => x.Transaction_ID);
                    table.ForeignKey(
                        name: "FK_tbl_Volume_Main_tbl_Activity",
                        column: x => x.ID_Activity,
                        principalSchema: "CPS",
                        principalTable: "tbl_Activity",
                        principalColumn: "ID_Activity",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Volume_Main_tbl_Country",
                        column: x => x.ID_Country,
                        principalSchema: "CPS",
                        principalTable: "tbl_Country",
                        principalColumn: "ID_Country",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Volume_Main_tbl_Division",
                        column: x => x.ID_Division,
                        principalSchema: "CPS",
                        principalTable: "tbl_Division",
                        principalColumn: "ID_Division",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Volume_Main_tbl_LOB",
                        column: x => x.ID_LOB,
                        principalSchema: "CPS",
                        principalTable: "tbl_LOB",
                        principalColumn: "ID_LOB",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Volume_Main_tbl_Login",
                        column: x => x.ID_Login,
                        principalSchema: "CPS",
                        principalTable: "tbl_Login",
                        principalColumn: "ID_Login",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Volume_Main_tbl_Process",
                        column: x => x.ID_Process,
                        principalSchema: "CPS",
                        principalTable: "tbl_Process",
                        principalColumn: "ID_Process",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Volume_Main_tbl_Status",
                        column: x => x.ID_Status,
                        principalSchema: "CPS",
                        principalTable: "tbl_Status",
                        principalColumn: "ID_Status",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Volume_Main_tbl_Tower",
                        column: x => x.ID_Tower,
                        principalSchema: "CPS",
                        principalTable: "tbl_Tower",
                        principalColumn: "ID_Tower",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Volume_Main_tbl_TowerCategory",
                        column: x => x.ID_TowerCategory,
                        principalSchema: "CPS",
                        principalTable: "tbl_TowerCategory",
                        principalColumn: "ID_TowerCategory",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "trel_ProcessTowerCategory",
                schema: "CPS",
                columns: table => new
                {
                    ID_PTG = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ID_Process = table.Column<int>(nullable: true),
                    ID_TowerCategory = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trel_ProcessTowerCategory", x => x.ID_PTG);
                    table.ForeignKey(
                        name: "FK_trel_ProcessTowerCategory_tbl_Process",
                        column: x => x.ID_Process,
                        principalSchema: "CPS",
                        principalTable: "tbl_Process",
                        principalColumn: "ID_Process",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_trel_ProcessTowerCategory_tbl_TowerCategory",
                        column: x => x.ID_TowerCategory,
                        principalSchema: "CPS",
                        principalTable: "tbl_TowerCategory",
                        principalColumn: "ID_TowerCategory",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "CPS",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "CPS",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "CPS",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "CPS",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "CPS",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "CPS",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "CPS",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "C_Unique_Transaction_ID",
                schema: "CPS",
                table: "tbl_Quality_Integration",
                column: "Transaction_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_UserActivity_ID_Login",
                schema: "CPS",
                table: "tbl_UserActivity",
                column: "ID_Login");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Volume_Main_ID_Activity",
                schema: "CPS",
                table: "tbl_Volume_Main",
                column: "ID_Activity");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Volume_Main_ID_Country",
                schema: "CPS",
                table: "tbl_Volume_Main",
                column: "ID_Country");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Volume_Main_ID_Division",
                schema: "CPS",
                table: "tbl_Volume_Main",
                column: "ID_Division");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Volume_Main_ID_LOB",
                schema: "CPS",
                table: "tbl_Volume_Main",
                column: "ID_LOB");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Volume_Main_ID_Login",
                schema: "CPS",
                table: "tbl_Volume_Main",
                column: "ID_Login");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Volume_Main_ID_Process",
                schema: "CPS",
                table: "tbl_Volume_Main",
                column: "ID_Process");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Volume_Main_ID_Status",
                schema: "CPS",
                table: "tbl_Volume_Main",
                column: "ID_Status");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Volume_Main_ID_Tower",
                schema: "CPS",
                table: "tbl_Volume_Main",
                column: "ID_Tower");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Volume_Main_ID_TowerCategory",
                schema: "CPS",
                table: "tbl_Volume_Main",
                column: "ID_TowerCategory");

            migrationBuilder.CreateIndex(
                name: "NonClusteredIndex-20180216-113906",
                schema: "CPS",
                table: "tbl_Volume_Main",
                columns: new[] { "Transaction_ID", "StartDate", "Original_ID", "CompleteDate", "Status_Code" });

            migrationBuilder.CreateIndex(
                name: "IX_trel_CountryProcess_ID_Country",
                schema: "CPS",
                table: "trel_CountryProcess",
                column: "ID_Country");

            migrationBuilder.CreateIndex(
                name: "IX_trel_CountryProcess_ID_Process",
                schema: "CPS",
                table: "trel_CountryProcess",
                column: "ID_Process");

            migrationBuilder.CreateIndex(
                name: "IX_trel_ProcessActivity_ID_Activity",
                schema: "CPS",
                table: "trel_ProcessActivity",
                column: "ID_Activity");

            migrationBuilder.CreateIndex(
                name: "IX_trel_ProcessActivity_ID_Process",
                schema: "CPS",
                table: "trel_ProcessActivity",
                column: "ID_Process");

            migrationBuilder.CreateIndex(
                name: "IX_trel_ProcessDivision_ID_Division",
                schema: "CPS",
                table: "trel_ProcessDivision",
                column: "ID_Division");

            migrationBuilder.CreateIndex(
                name: "IX_trel_ProcessDivision_ID_Process",
                schema: "CPS",
                table: "trel_ProcessDivision",
                column: "ID_Process");

            migrationBuilder.CreateIndex(
                name: "IX_trel_ProcessLOB_ID_LOB",
                schema: "CPS",
                table: "trel_ProcessLOB",
                column: "ID_LOB");

            migrationBuilder.CreateIndex(
                name: "IX_trel_ProcessLOB_ID_Process",
                schema: "CPS",
                table: "trel_ProcessLOB",
                column: "ID_Process");

            migrationBuilder.CreateIndex(
                name: "IX_trel_ProcessStatus_ID_Process",
                schema: "CPS",
                table: "trel_ProcessStatus",
                column: "ID_Process");

            migrationBuilder.CreateIndex(
                name: "IX_trel_ProcessStatus_ID_Status",
                schema: "CPS",
                table: "trel_ProcessStatus",
                column: "ID_Status");

            migrationBuilder.CreateIndex(
                name: "IX_trel_ProcessTower_ID_Process",
                schema: "CPS",
                table: "trel_ProcessTower",
                column: "ID_Process");

            migrationBuilder.CreateIndex(
                name: "IX_trel_ProcessTower_ID_Tower",
                schema: "CPS",
                table: "trel_ProcessTower",
                column: "ID_Tower");

            migrationBuilder.CreateIndex(
                name: "IX_trel_ProcessTowerCategory_ID_Process",
                schema: "CPS",
                table: "trel_ProcessTowerCategory",
                column: "ID_Process");

            migrationBuilder.CreateIndex(
                name: "IX_trel_ProcessTowerCategory_ID_TowerCategory",
                schema: "CPS",
                table: "trel_ProcessTowerCategory",
                column: "ID_TowerCategory");

            migrationBuilder.CreateIndex(
                name: "IX_trel_UserCountry_ID_Country",
                schema: "CPS",
                table: "trel_UserCountry",
                column: "ID_Country");

            migrationBuilder.CreateIndex(
                name: "IX_trel_UserCountry_ID_Login",
                schema: "CPS",
                table: "trel_UserCountry",
                column: "ID_Login");

            migrationBuilder.CreateIndex(
                name: "IX_trel_UserMining_ID_Login",
                schema: "CPS",
                table: "trel_UserMining",
                column: "ID_Login");

            migrationBuilder.CreateIndex(
                name: "IX_trel_UserMining_ID_Mining",
                schema: "CPS",
                table: "trel_UserMining",
                column: "ID_Mining");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "CPS");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "CPS");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "CPS");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "CPS");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "CPS");

            migrationBuilder.DropTable(
                name: "Holiday Table",
                schema: "CPS");

            migrationBuilder.DropTable(
                name: "tbl_Internal_Errors_Log",
                schema: "CPS");

            migrationBuilder.DropTable(
                name: "tbl_L2_ID",
                schema: "CPS");

            migrationBuilder.DropTable(
                name: "tbl_Objects",
                schema: "CPS");

            migrationBuilder.DropTable(
                name: "tbl_Quality_Integration",
                schema: "CPS");

            migrationBuilder.DropTable(
                name: "tbl_Reporting_Users",
                schema: "CPS");

            migrationBuilder.DropTable(
                name: "tbl_Specific",
                schema: "CPS");

            migrationBuilder.DropTable(
                name: "tbl_Tracker_Ver",
                schema: "CPS");

            migrationBuilder.DropTable(
                name: "tbl_UserActivity",
                schema: "CPS");

            migrationBuilder.DropTable(
                name: "tbl_Volume_Main",
                schema: "CPS");

            migrationBuilder.DropTable(
                name: "trel_CountryProcess",
                schema: "CPS");

            migrationBuilder.DropTable(
                name: "trel_ProcessActivity",
                schema: "CPS");

            migrationBuilder.DropTable(
                name: "trel_ProcessDivision",
                schema: "CPS");

            migrationBuilder.DropTable(
                name: "trel_ProcessLOB",
                schema: "CPS");

            migrationBuilder.DropTable(
                name: "trel_ProcessStatus",
                schema: "CPS");

            migrationBuilder.DropTable(
                name: "trel_ProcessTower",
                schema: "CPS");

            migrationBuilder.DropTable(
                name: "trel_ProcessTowerCategory",
                schema: "CPS");

            migrationBuilder.DropTable(
                name: "trel_UserCountry",
                schema: "CPS");

            migrationBuilder.DropTable(
                name: "trel_UserMining",
                schema: "CPS");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "CPS");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "CPS");

            migrationBuilder.DropTable(
                name: "tbl_Activity",
                schema: "CPS");

            migrationBuilder.DropTable(
                name: "tbl_Division",
                schema: "CPS");

            migrationBuilder.DropTable(
                name: "tbl_LOB",
                schema: "CPS");

            migrationBuilder.DropTable(
                name: "tbl_Status",
                schema: "CPS");

            migrationBuilder.DropTable(
                name: "tbl_Tower",
                schema: "CPS");

            migrationBuilder.DropTable(
                name: "tbl_Process",
                schema: "CPS");

            migrationBuilder.DropTable(
                name: "tbl_TowerCategory",
                schema: "CPS");

            migrationBuilder.DropTable(
                name: "tbl_Country",
                schema: "CPS");

            migrationBuilder.DropTable(
                name: "tbl_Login",
                schema: "CPS");

            migrationBuilder.DropTable(
                name: "tbl_Mining",
                schema: "CPS");
        }
    }
}
