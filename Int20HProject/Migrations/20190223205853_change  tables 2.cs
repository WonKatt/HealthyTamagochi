using Microsoft.EntityFrameworkCore.Migrations;

namespace Int20HProject.Migrations
{
    public partial class changetables2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_searched_food_result_user_searches_User_Searches",
                table: "searched_food_result");

            migrationBuilder.DropForeignKey(
                name: "FK_user_searches_user_info_User_Info",
                table: "user_searches");

            migrationBuilder.DropIndex(
                name: "IX_searched_food_result_User_Searches",
                table: "searched_food_result");

            migrationBuilder.DropColumn(
                name: "User_Searches",
                table: "searched_food_result");

            migrationBuilder.RenameColumn(
                name: "User_Info",
                table: "user_searches",
                newName: "UserInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_user_searches_User_Info",
                table: "user_searches",
                newName: "IX_user_searches_UserInfoId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "user_searches",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserSearchesId",
                table: "searched_food_result",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_searched_food_result_UserSearchesId",
                table: "searched_food_result",
                column: "UserSearchesId");

            migrationBuilder.AddForeignKey(
                name: "FK_searched_food_result_user_searches_UserSearchesId",
                table: "searched_food_result",
                column: "UserSearchesId",
                principalTable: "user_searches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_searches_user_info_UserInfoId",
                table: "user_searches",
                column: "UserInfoId",
                principalTable: "user_info",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_searched_food_result_user_searches_UserSearchesId",
                table: "searched_food_result");

            migrationBuilder.DropForeignKey(
                name: "FK_user_searches_user_info_UserInfoId",
                table: "user_searches");

            migrationBuilder.DropIndex(
                name: "IX_searched_food_result_UserSearchesId",
                table: "searched_food_result");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "user_searches");

            migrationBuilder.DropColumn(
                name: "UserSearchesId",
                table: "searched_food_result");

            migrationBuilder.RenameColumn(
                name: "UserInfoId",
                table: "user_searches",
                newName: "User_Info");

            migrationBuilder.RenameIndex(
                name: "IX_user_searches_UserInfoId",
                table: "user_searches",
                newName: "IX_user_searches_User_Info");

            migrationBuilder.AddColumn<int>(
                name: "User_Searches",
                table: "searched_food_result",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_searched_food_result_User_Searches",
                table: "searched_food_result",
                column: "User_Searches");

            migrationBuilder.AddForeignKey(
                name: "FK_searched_food_result_user_searches_User_Searches",
                table: "searched_food_result",
                column: "User_Searches",
                principalTable: "user_searches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_user_searches_user_info_User_Info",
                table: "user_searches",
                column: "User_Info",
                principalTable: "user_info",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
