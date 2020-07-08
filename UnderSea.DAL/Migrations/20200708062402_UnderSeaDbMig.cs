using Microsoft.EntityFrameworkCore.Migrations;

namespace UnderSea.DAL.Migrations
{
    public partial class UnderSeaDbMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CombatSeaHorse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    AttackScore = table.Column<double>(nullable: false),
                    DefenseScore = table.Column<double>(nullable: false),
                    PearlCostPerTurn = table.Column<int>(nullable: false),
                    CoralCostPerTurn = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CombatSeaHorse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlowManager",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    PopulationBonus = table.Column<int>(nullable: false),
                    CoralBonus = table.Column<int>(nullable: false),
                    UnitStorage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowManager", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Round = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LaserShark",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    AttackScore = table.Column<double>(nullable: false),
                    DefenseScore = table.Column<double>(nullable: false),
                    PearlCostPerTurn = table.Column<int>(nullable: false),
                    CoralCostPerTurn = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaserShark", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReefCastle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    PopulationBonus = table.Column<int>(nullable: false),
                    CoralBonus = table.Column<int>(nullable: false),
                    UnitStorage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReefCastle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StormSeal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    AttackScore = table.Column<double>(nullable: false),
                    DefenseScore = table.Column<double>(nullable: false),
                    PearlCostPerTurn = table.Column<int>(nullable: false),
                    CoralCostPerTurn = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StormSeal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Upgrades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MudTractor = table.Column<int>(nullable: false),
                    MudHarvester = table.Column<int>(nullable: false),
                    CoralWall = table.Column<int>(nullable: false),
                    SonarCannon = table.Column<int>(nullable: false),
                    UnderwaterMartialArts = table.Column<int>(nullable: false),
                    Alchemy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Upgrades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BuildingGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlowManagerId = table.Column<int>(nullable: true),
                    ReefCastleId = table.Column<int>(nullable: true),
                    BuildingState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildingGroup_FlowManager_FlowManagerId",
                        column: x => x.FlowManagerId,
                        principalTable: "FlowManager",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BuildingGroup_ReefCastle_ReefCastleId",
                        column: x => x.ReefCastleId,
                        principalTable: "ReefCastle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UnitGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StormSealId = table.Column<int>(nullable: true),
                    CombatSeaHorseId = table.Column<int>(nullable: true),
                    LaserSharkId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnitGroup_CombatSeaHorse_CombatSeaHorseId",
                        column: x => x.CombatSeaHorseId,
                        principalTable: "CombatSeaHorse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UnitGroup_LaserShark_LaserSharkId",
                        column: x => x.LaserSharkId,
                        principalTable: "LaserShark",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UnitGroup_StormSeal_StormSealId",
                        column: x => x.StormSealId,
                        principalTable: "StormSeal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    BuildingGroupId = table.Column<int>(nullable: true),
                    ArmyId = table.Column<int>(nullable: true),
                    Coral = table.Column<int>(nullable: false),
                    CoralProduction = table.Column<int>(nullable: false),
                    Pearl = table.Column<int>(nullable: false),
                    PearlProduction = table.Column<int>(nullable: false),
                    UpgradesId = table.Column<int>(nullable: true),
                    UpgradeTimeLeft = table.Column<int>(nullable: false),
                    BuildingTimeLeft = table.Column<int>(nullable: false),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Country_UnitGroup_ArmyId",
                        column: x => x.ArmyId,
                        principalTable: "UnitGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Country_BuildingGroup_BuildingGroupId",
                        column: x => x.BuildingGroupId,
                        principalTable: "BuildingGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Country_Upgrades_UpgradesId",
                        column: x => x.UpgradesId,
                        principalTable: "Upgrades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    GameId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Attack",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttackerUserId = table.Column<int>(nullable: true),
                    DefenderUserId = table.Column<int>(nullable: true),
                    UnitGroupId = table.Column<int>(nullable: true),
                    GameId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attack", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attack_User_AttackerUserId",
                        column: x => x.AttackerUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attack_User_DefenderUserId",
                        column: x => x.DefenderUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attack_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attack_UnitGroup_UnitGroupId",
                        column: x => x.UnitGroupId,
                        principalTable: "UnitGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attack_AttackerUserId",
                table: "Attack",
                column: "AttackerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Attack_DefenderUserId",
                table: "Attack",
                column: "DefenderUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Attack_GameId",
                table: "Attack",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Attack_UnitGroupId",
                table: "Attack",
                column: "UnitGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingGroup_FlowManagerId",
                table: "BuildingGroup",
                column: "FlowManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingGroup_ReefCastleId",
                table: "BuildingGroup",
                column: "ReefCastleId");

            migrationBuilder.CreateIndex(
                name: "IX_Country_ArmyId",
                table: "Country",
                column: "ArmyId");

            migrationBuilder.CreateIndex(
                name: "IX_Country_BuildingGroupId",
                table: "Country",
                column: "BuildingGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Country_UpgradesId",
                table: "Country",
                column: "UpgradesId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitGroup_CombatSeaHorseId",
                table: "UnitGroup",
                column: "CombatSeaHorseId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitGroup_LaserSharkId",
                table: "UnitGroup",
                column: "LaserSharkId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitGroup_StormSealId",
                table: "UnitGroup",
                column: "StormSealId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CountryId",
                table: "User",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_User_GameId",
                table: "User",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attack");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "UnitGroup");

            migrationBuilder.DropTable(
                name: "BuildingGroup");

            migrationBuilder.DropTable(
                name: "Upgrades");

            migrationBuilder.DropTable(
                name: "CombatSeaHorse");

            migrationBuilder.DropTable(
                name: "LaserShark");

            migrationBuilder.DropTable(
                name: "StormSeal");

            migrationBuilder.DropTable(
                name: "FlowManager");

            migrationBuilder.DropTable(
                name: "ReefCastle");
        }
    }
}
