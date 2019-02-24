using Microsoft.EntityFrameworkCore.Migrations;

namespace Int20HProject.Migrations
{
    public partial class changeuser_infotable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Height",
                table: "user_info",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "user_info");
        }
    }
}
