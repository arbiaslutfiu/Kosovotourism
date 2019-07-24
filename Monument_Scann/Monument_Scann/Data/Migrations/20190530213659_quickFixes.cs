using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Monument_Scann.Data.Migrations
{
    public partial class quickFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monument_Comment_ComentsId",
                table: "Monument");

            migrationBuilder.DropForeignKey(
                name: "FK_touristspot_Comment_ComentsId",
                table: "touristspot");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_touristspot_ComentsId",
                table: "touristspot");

            migrationBuilder.DropIndex(
                name: "IX_Monument_ComentsId",
                table: "Monument");

            migrationBuilder.DropColumn(
                name: "ComentsId",
                table: "touristspot");

            migrationBuilder.DropColumn(
                name: "ComentsId",
                table: "Monument");

            migrationBuilder.CreateTable(
                name: "MonumentComments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    Comented = table.Column<string>(nullable: true),
                    MonumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonumentComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonumentComments_Monument_MonumentId",
                        column: x => x.MonumentId,
                        principalTable: "Monument",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TouristSpotComents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    Comented = table.Column<string>(nullable: true),
                    touristspotId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TouristSpotComents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TouristSpotComents_touristspot_touristspotId",
                        column: x => x.touristspotId,
                        principalTable: "touristspot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonumentComments_MonumentId",
                table: "MonumentComments",
                column: "MonumentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TouristSpotComents_touristspotId",
                table: "TouristSpotComents",
                column: "touristspotId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonumentComments");

            migrationBuilder.DropTable(
                name: "TouristSpotComents");

            migrationBuilder.AddColumn<int>(
                name: "ComentsId",
                table: "touristspot",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComentsId",
                table: "Monument",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comented = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_touristspot_ComentsId",
                table: "touristspot",
                column: "ComentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Monument_ComentsId",
                table: "Monument",
                column: "ComentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Monument_Comment_ComentsId",
                table: "Monument",
                column: "ComentsId",
                principalTable: "Comment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_touristspot_Comment_ComentsId",
                table: "touristspot",
                column: "ComentsId",
                principalTable: "Comment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
