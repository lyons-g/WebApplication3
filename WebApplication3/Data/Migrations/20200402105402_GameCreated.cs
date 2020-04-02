using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication3.Data.Migrations
{
    public partial class GameCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameStats");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Game");

            migrationBuilder.RenameColumn(
                name: "GameID",
                table: "Game",
                newName: "GameId");

            migrationBuilder.AddColumn<int>(
                name: "AST",
                table: "Game",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Block",
                table: "Game",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "D_Rb",
                table: "Game",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "FGA",
                table: "Game",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FGM",
                table: "Game",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FGperC",
                table: "Game",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "FTA",
                table: "Game",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FTM",
                table: "Game",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "FT_PC",
                table: "Game",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "O_Rb",
                table: "Game",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "Game",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Steal",
                table: "Game",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TO",
                table: "Game",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Three_PA",
                table: "Game",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Three_PC",
                table: "Game",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Three_PM",
                table: "Game",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Total_Reb",
                table: "Game",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TwoPerC",
                table: "Game",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Two_PA",
                table: "Game",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Two_PM",
                table: "Game",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Venue",
                table: "Game",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Win",
                table: "Game",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AST",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "Block",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "D_Rb",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "FGA",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "FGM",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "FGperC",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "FTA",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "FTM",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "FT_PC",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "O_Rb",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "Points",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "Steal",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "TO",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "Three_PA",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "Three_PC",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "Three_PM",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "Total_Reb",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "TwoPerC",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "Two_PA",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "Two_PM",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "Venue",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "Win",
                table: "Game");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "Game",
                newName: "GameID");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Game",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GameStats",
                columns: table => new
                {
                    GamesStatsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameID = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    Rebound = table.Column<int>(type: "int", nullable: false),
                    Turnovers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameStats", x => x.GamesStatsID);
                    table.ForeignKey(
                        name: "FK_GameStats_Game_GameID",
                        column: x => x.GameID,
                        principalTable: "Game",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    TeamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.TeamID);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    PlayerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false),
                    TeamID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.PlayerID);
                    table.ForeignKey(
                        name: "FK_Player_Team_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Team",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameStats_GameID",
                table: "GameStats",
                column: "GameID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Player_TeamID",
                table: "Player",
                column: "TeamID");
        }
    }
}
