using Microsoft.EntityFrameworkCore.Migrations;

namespace Int20HProject.Migrations
{
    public partial class changetables4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_searches_user_info_UserInfoId",
                table: "user_searches");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "user_searches");

            migrationBuilder.AlterColumn<int>(
                name: "UserInfoId",
                table: "user_searches",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_user_searches_user_info_UserInfoId",
                table: "user_searches",
                column: "UserInfoId",
                principalTable: "user_info",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_searches_user_info_UserInfoId",
                table: "user_searches");

            migrationBuilder.AlterColumn<int>(
                name: "UserInfoId",
                table: "user_searches",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "user_searches",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_user_searches_user_info_UserInfoId",
                table: "user_searches",
                column: "UserInfoId",
                principalTable: "user_info",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
