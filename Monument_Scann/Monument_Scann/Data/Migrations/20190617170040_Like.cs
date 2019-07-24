using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Monument_Scann.Data.Migrations
{
    public partial class Like : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LajkiTSId",
                table: "touristspot",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LajkiMId",
                table: "Monument",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Lajki",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Liked = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lajki", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_touristspot_LajkiTSId",
                table: "touristspot",
                column: "LajkiTSId");

            migrationBuilder.CreateIndex(
                name: "IX_Monument_LajkiMId",
                table: "Monument",
                column: "LajkiMId");

            migrationBuilder.AddForeignKey(
                name: "FK_Monument_Lajki_LajkiMId",
                table: "Monument",
                column: "LajkiMId",
                principalTable: "Lajki",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_touristspot_Lajki_LajkiTSId",
                table: "touristspot",
                column: "LajkiTSId",
                principalTable: "Lajki",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monument_Lajki_LajkiMId",
                table: "Monument");

            migrationBuilder.DropForeignKey(
                name: "FK_touristspot_Lajki_LajkiTSId",
                table: "touristspot");

            migrationBuilder.DropTable(
                name: "Lajki");

            migrationBuilder.DropIndex(
                name: "IX_touristspot_LajkiTSId",
                table: "touristspot");

            migrationBuilder.DropIndex(
                name: "IX_Monument_LajkiMId",
                table: "Monument");

            migrationBuilder.DropColumn(
                name: "LajkiTSId",
                table: "touristspot");

            migrationBuilder.DropColumn(
                name: "LajkiMId",
                table: "Monument");
        }
    }
}
