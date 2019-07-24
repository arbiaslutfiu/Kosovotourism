using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Monument_Scann.Data.Migrations
{
    public partial class LikeFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_touristspot_Lajkis_LajkiTSId",
                table: "touristspot");

            migrationBuilder.AlterColumn<int>(
                name: "LajkiTSId",
                table: "touristspot",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "LajkiTurSs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Liked = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    touristspotsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LajkiTurSs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LajkiTurSs_touristspot_touristspotsId",
                        column: x => x.touristspotsId,
                        principalTable: "touristspot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LajkiTurSs_touristspotsId",
                table: "LajkiTurSs",
                column: "touristspotsId");

            migrationBuilder.AddForeignKey(
                name: "FK_touristspot_LajkiTurSs_LajkiTSId",
                table: "touristspot",
                column: "LajkiTSId",
                principalTable: "LajkiTurSs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_touristspot_LajkiTurSs_LajkiTSId",
                table: "touristspot");

            migrationBuilder.DropTable(
                name: "LajkiTurSs");

            migrationBuilder.AlterColumn<int>(
                name: "LajkiTSId",
                table: "touristspot",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_touristspot_Lajkis_LajkiTSId",
                table: "touristspot",
                column: "LajkiTSId",
                principalTable: "Lajkis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
