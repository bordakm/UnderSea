using Microsoft.EntityFrameworkCore.Migrations;

namespace UnderSea.DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuildingGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingGroup", x => x.Id);
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
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    PopulationBonus = table.Column<int>(nullable: false),
                    CoralBonus = table.Column<int>(nullable: false),
                    UnitStorage = table.Column<int>(nullable: false),
                    UnderConstructionCount = table.Column<bool>(nullable: false),
                    BuildingGroupId = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buildings_BuildingGroup_BuildingGroupId",
                        column: x => x.BuildingGroupId,
                        principalTable: "BuildingGroup",
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
                    Population = table.Column<int>(nullable: false),
                    UnitStorage = table.Column<int>(nullable: false),
                    TaxRate = table.Column<int>(nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    AttackScore = table.Column<double>(nullable: false),
                    DefenseScore = table.Column<double>(nullable: false),
                    PearlCostPerTurn = table.Column<int>(nullable: false),
                    CoralCostPerTurn = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    UnitGroupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unit_UnitGroup_UnitGroupId",
                        column: x => x.UnitGroupId,
                        principalTable: "UnitGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Upgrade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoralProductionBonusPercentage = table.Column<int>(nullable: false),
                    DefenseBonusPercentage = table.Column<int>(nullable: false),
                    AttackBonusPercentage = table.Column<int>(nullable: false),
                    AttackAndDefenseBonusPercentage = table.Column<int>(nullable: false),
                    PearlProductionBonusPercentage = table.Column<int>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Upgrade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Upgrade_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
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
                name: "IX_Buildings_BuildingGroupId",
                table: "Buildings",
                column: "BuildingGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Country_ArmyId",
                table: "Country",
                column: "ArmyId");

            migrationBuilder.CreateIndex(
                name: "IX_Country_BuildingGroupId",
                table: "Country",
                column: "BuildingGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Unit_UnitGroupId",
                table: "Unit",
                column: "UnitGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Upgrade_CountryId",
                table: "Upgrade",
                column: "CountryId");

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
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "Upgrade");

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
        }
    }
}
