using Microsoft.EntityFrameworkCore.Migrations;

namespace Monument_Scann.Data.Migrations
{
    public partial class touristimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "touristspot",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "touristspot");
        }
    }
}
