using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UnderSea.DAL.Migrations
{
    public partial class asd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BuildingType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    PopulationBonus = table.Column<int>(nullable: false),
                    CoralBonus = table.Column<int>(nullable: false),
                    UnitStorage = table.Column<int>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    Score = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Round = table.Column<int>(nullable: false),
                    CoralPictureUrl = table.Column<string>(nullable: true),
                    PearlPictureUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    AttackScore = table.Column<double>(nullable: false),
                    DefenseScore = table.Column<double>(nullable: false),
                    PearlCostPerTurn = table.Column<int>(nullable: false),
                    CoralCostPerTurn = table.Column<int>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    Score = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UpgradeType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    CoralProductionBonusPercentage = table.Column<int>(nullable: false),
                    DefenseBonusPercentage = table.Column<int>(nullable: false),
                    AttackBonusPercentage = table.Column<int>(nullable: false),
                    PearlProductionBonusPercentage = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpgradeType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Place = table.Column<int>(nullable: false),
                    Score = table.Column<int>(nullable: false),
                    GameId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
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
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Attacks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttackerUserId = table.Column<int>(nullable: false),
                    DefenderUserId = table.Column<int>(nullable: false),
                    GameId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attacks_AspNetUsers_AttackerUserId",
                        column: x => x.AttackerUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Attacks_AspNetUsers_DefenderUserId",
                        column: x => x.DefenderUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Attacks_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    AttackingArmyId = table.Column<int>(nullable: false),
                    DefendingArmyId = table.Column<int>(nullable: false),
                    Coral = table.Column<int>(nullable: false),
                    Pearl = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    UpgradeTimeLeft = table.Column<int>(nullable: false),
                    BuildingTimeLeft = table.Column<int>(nullable: false),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countries_UnitGroup_AttackingArmyId",
                        column: x => x.AttackingArmyId,
                        principalTable: "UnitGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Countries_UnitGroup_DefendingArmyId",
                        column: x => x.DefendingArmyId,
                        principalTable: "UnitGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Countries_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttackId = table.Column<int>(nullable: true),
                    UnitGroupId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Units_Attacks_AttackId",
                        column: x => x.AttackId,
                        principalTable: "Attacks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Units_UnitType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "UnitType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Units_UnitGroup_UnitGroupId",
                        column: x => x.UnitGroupId,
                        principalTable: "UnitGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BuildingGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildingGroup_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Upgrade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false),
                    State = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Upgrade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Upgrade_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Upgrade_UpgradeType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "UpgradeType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingGroupId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    UnderConstructionCount = table.Column<int>(nullable: false),
                    ConstructionTimeLeft = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buildings_BuildingGroup_BuildingGroupId",
                        column: x => x.BuildingGroupId,
                        principalTable: "BuildingGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Buildings_BuildingType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "BuildingType",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "BuildingType",
                columns: new[] { "Id", "CoralBonus", "Description", "Discriminator", "ImageUrl", "Name", "PopulationBonus", "Price", "Score", "UnitStorage" },
                values: new object[,]
                {
                    { 2, 200, null, "FlowManager", null, "folyamirányító", 50, 1000, 0, 0 },
                    { 1, 0, null, "ReefCastle", null, "zátonyvár", 0, 1000, 0, 200 }
                });

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "Id", "CoralPictureUrl", "PearlPictureUrl", "Round" },
                values: new object[] { 1, "", "", 1 });

            migrationBuilder.InsertData(
                table: "UnitGroup",
                column: "Id",
                values: new object[]
                {
                    1,
                    2,
                    3,
                    4
                });

            migrationBuilder.InsertData(
                table: "UnitType",
                columns: new[] { "Id", "AttackScore", "CoralCostPerTurn", "DefenseScore", "Discriminator", "ImageUrl", "Name", "PearlCostPerTurn", "Price", "Score" },
                values: new object[,]
                {
                    { 3, 2.0, 1, 6.0, "CombatSeaHorse", null, null, 1, 50, 0 },
                    { 1, 5.0, 2, 5.0, "LaserShark", null, null, 3, 100, 0 },
                    { 2, 6.0, 1, 2.0, "StormSeal", null, null, 1, 50, 0 }
                });

            migrationBuilder.InsertData(
                table: "UpgradeType",
                columns: new[] { "Id", "AttackBonusPercentage", "CoralProductionBonusPercentage", "DefenseBonusPercentage", "Description", "Discriminator", "ImageUrl", "Name", "PearlProductionBonusPercentage" },
                values: new object[,]
                {
                    { 1, 0, 30, 0, "növeli a beszedett adót 30%-kal", "Alchemy", "majd/kesobb/lesz/kep.jpg", "Alkímia", 0 },
                    { 2, 0, 0, 20, "növeli a védelmi pontokat 20%-kal", "CoralWall", "majd/kesobb/lesz/kep.jpg", "Korallfal", 0 },
                    { 3, 0, 15, 0, "növeli a korall termesztést 15%-kal", "MudHarvester", "majd/kesobb/lesz/kep.jpg", "Iszapkombájn", 0 },
                    { 4, 0, 10, 0, "növeli a krumpli termesztést 10%-kal", "MudTractor", "majd/kesobb/lesz/kep.jpg", "Iszaptraktor", 0 },
                    { 5, 20, 0, 0, "növeli a támadópontokat 20%-kal", "SonarCannon", "majd/kesobb/lesz/kep.jpg", "Szonárágyú", 0 },
                    { 6, 10, 0, 10, "növeli a védelmi és támadóerőt 10%-kal", "UnderwaterMartialArts", "majd/kesobb/lesz/kep.jpg", "Vízalatti harcművészetek", 0 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "GameId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Place", "Score", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "797571f0-c01b-49d4-9c93-4f3bca5b2e36", null, false, 1, false, null, null, null, null, null, false, 1, 100, null, false, "First User" },
                    { 2, 0, "44198220-1473-4451-a606-4f50d88e6c70", null, false, 1, false, null, null, null, null, null, false, 2, 50, null, false, "Second User" }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "AttackId", "Count", "TypeId", "UnitGroupId" },
                values: new object[,]
                {
                    { 4, null, 10, 1, 2 },
                    { 5, null, 20, 2, 2 },
                    { 6, null, 40, 3, 2 },
                    { 7, null, 0, 1, 3 },
                    { 8, null, 0, 2, 3 },
                    { 9, null, 0, 3, 3 },
                    { 10, null, 10, 1, 4 },
                    { 11, null, 20, 2, 4 },
                    { 12, null, 40, 3, 4 }
                });

            migrationBuilder.InsertData(
                table: "Attacks",
                columns: new[] { "Id", "AttackerUserId", "DefenderUserId", "GameId" },
                values: new object[] { 1, 1, 2, null });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AttackingArmyId", "BuildingTimeLeft", "Coral", "DefendingArmyId", "Name", "Pearl", "Score", "UpgradeTimeLeft", "UserId" },
                values: new object[] { 1, 1, 0, 0, 2, "First Country", 0, 0, 0, 1 });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "AttackingArmyId", "BuildingTimeLeft", "Coral", "DefendingArmyId", "Name", "Pearl", "Score", "UpgradeTimeLeft", "UserId" },
                values: new object[] { 2, 3, 0, 0, 4, "Another Country", 0, 0, 0, 2 });

            migrationBuilder.InsertData(
                table: "BuildingGroup",
                columns: new[] { "Id", "CountryId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "AttackId", "Count", "TypeId", "UnitGroupId" },
                values: new object[,]
                {
                    { 1, 1, 0, 1, 1 },
                    { 2, 1, 0, 2, 1 },
                    { 3, 1, 0, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Upgrade",
                columns: new[] { "Id", "CountryId", "State", "TypeId" },
                values: new object[,]
                {
                    { 1, 1, 3, 1 },
                    { 2, 1, 3, 2 },
                    { 3, 1, 3, 3 },
                    { 4, 1, 3, 4 },
                    { 5, 1, 3, 5 },
                    { 6, 2, 3, 1 },
                    { 7, 2, 3, 2 },
                    { 8, 2, 3, 3 },
                    { 9, 2, 3, 4 },
                    { 10, 2, 3, 5 }
                });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "Id", "BuildingGroupId", "ConstructionTimeLeft", "Count", "TypeId", "UnderConstructionCount" },
                values: new object[,]
                {
                    { 1, 1, 0, 1, 1, 0 },
                    { 2, 1, 0, 1, 2, 0 },
                    { 3, 2, 0, 1, 1, 0 },
                    { 4, 2, 0, 1, 2, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GameId",
                table: "AspNetUsers",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Attacks_AttackerUserId",
                table: "Attacks",
                column: "AttackerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Attacks_DefenderUserId",
                table: "Attacks",
                column: "DefenderUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Attacks_GameId",
                table: "Attacks",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingGroup_CountryId",
                table: "BuildingGroup",
                column: "CountryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_BuildingGroupId",
                table: "Buildings",
                column: "BuildingGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_TypeId",
                table: "Buildings",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_AttackingArmyId",
                table: "Countries",
                column: "AttackingArmyId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_DefendingArmyId",
                table: "Countries",
                column: "DefendingArmyId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_UserId",
                table: "Countries",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Units_AttackId",
                table: "Units",
                column: "AttackId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_TypeId",
                table: "Units",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_UnitGroupId",
                table: "Units",
                column: "UnitGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Upgrade_CountryId",
                table: "Upgrade",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Upgrade_TypeId",
                table: "Upgrade",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Upgrade");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "BuildingGroup");

            migrationBuilder.DropTable(
                name: "BuildingType");

            migrationBuilder.DropTable(
                name: "Attacks");

            migrationBuilder.DropTable(
                name: "UnitType");

            migrationBuilder.DropTable(
                name: "UpgradeType");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "UnitGroup");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Game");
        }
    }
}
