using Microsoft.EntityFrameworkCore.Migrations;

namespace Monument_Scann.Data.Migrations
{
    public partial class listamonument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MonumentId",
                table: "Monument",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Monument_MonumentId",
                table: "Monument",
                column: "MonumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Monument_Monument_MonumentId",
                table: "Monument",
                column: "MonumentId",
                principalTable: "Monument",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monument_Monument_MonumentId",
                table: "Monument");

            migrationBuilder.DropIndex(
                name: "IX_Monument_MonumentId",
                table: "Monument");

            migrationBuilder.DropColumn(
                name: "MonumentId",
                table: "Monument");
        }
    }
}
