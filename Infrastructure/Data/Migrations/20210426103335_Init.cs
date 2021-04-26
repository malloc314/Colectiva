using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistoricalSequences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sn = table.Column<int>(type: "int", nullable: false),
                    First = table.Column<byte>(type: "tinyint", nullable: false),
                    Second = table.Column<byte>(type: "tinyint", nullable: false),
                    Thrid = table.Column<byte>(type: "tinyint", nullable: false),
                    Fourth = table.Column<byte>(type: "tinyint", nullable: false),
                    Fifth = table.Column<byte>(type: "tinyint", nullable: false),
                    Sixth = table.Column<byte>(type: "tinyint", nullable: false),
                    Seventh = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricalSequences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PseudoProbableSequences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First = table.Column<byte>(type: "tinyint", nullable: false),
                    Second = table.Column<byte>(type: "tinyint", nullable: false),
                    Thrid = table.Column<byte>(type: "tinyint", nullable: false),
                    Fourth = table.Column<byte>(type: "tinyint", nullable: false),
                    Fifth = table.Column<byte>(type: "tinyint", nullable: false),
                    Sixth = table.Column<byte>(type: "tinyint", nullable: false),
                    Seventh = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PseudoProbableSequences", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricalSequences");

            migrationBuilder.DropTable(
                name: "PseudoProbableSequences");
        }
    }
}
