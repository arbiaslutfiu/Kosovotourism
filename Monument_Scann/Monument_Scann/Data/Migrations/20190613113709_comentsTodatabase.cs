using Microsoft.EntityFrameworkCore.Migrations;

namespace Monument_Scann.Data.Migrations
{
    public partial class comentsTodatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MonumentComments_MonumentId",
                table: "MonumentComments");

            migrationBuilder.AddColumn<int>(
                name: "ComentsId",
                table: "Monument",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MonumentComments_MonumentId",
                table: "MonumentComments",
                column: "MonumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Monument_ComentsId",
                table: "Monument",
                column: "ComentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Monument_MonumentComments_ComentsId",
                table: "Monument",
                column: "ComentsId",
                principalTable: "MonumentComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monument_MonumentComments_ComentsId",
                table: "Monument");

            migrationBuilder.DropIndex(
                name: "IX_MonumentComments_MonumentId",
                table: "MonumentComments");

            migrationBuilder.DropIndex(
                name: "IX_Monument_ComentsId",
                table: "Monument");

            migrationBuilder.DropColumn(
                name: "ComentsId",
                table: "Monument");

            migrationBuilder.CreateIndex(
                name: "IX_MonumentComments_MonumentId",
                table: "MonumentComments",
                column: "MonumentId",
                unique: true);
        }
    }
}
