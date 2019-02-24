using Microsoft.EntityFrameworkCore.Migrations;

namespace Int20HProject.Migrations
{
    public partial class iditenahuy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Searched_Food_Result_User_Searches_User_Searches",
                table: "Searched_Food_Result");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Searches_User_Info_User_Info",
                table: "User_Searches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User_Searches",
                table: "User_Searches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User_Info",
                table: "User_Info");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Searched_Food_Result",
                table: "Searched_Food_Result");

            migrationBuilder.RenameTable(
                name: "User_Searches",
                newName: "user_searches");

            migrationBuilder.RenameTable(
                name: "User_Info",
                newName: "user_info");

            migrationBuilder.RenameTable(
                name: "Searched_Food_Result",
                newName: "searched_food_result");

            migrationBuilder.RenameIndex(
                name: "IX_User_Searches_User_Info",
                table: "user_searches",
                newName: "IX_user_searches_User_Info");

            migrationBuilder.RenameIndex(
                name: "IX_Searched_Food_Result_User_Searches",
                table: "searched_food_result",
                newName: "IX_searched_food_result_User_Searches");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_searches",
                table: "user_searches",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_info",
                table: "user_info",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_searched_food_result",
                table: "searched_food_result",
                column: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_searched_food_result_user_searches_User_Searches",
                table: "searched_food_result");

            migrationBuilder.DropForeignKey(
                name: "FK_user_searches_user_info_User_Info",
                table: "user_searches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_searches",
                table: "user_searches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_info",
                table: "user_info");

            migrationBuilder.DropPrimaryKey(
                name: "PK_searched_food_result",
                table: "searched_food_result");

            migrationBuilder.RenameTable(
                name: "user_searches",
                newName: "User_Searches");

            migrationBuilder.RenameTable(
                name: "user_info",
                newName: "User_Info");

            migrationBuilder.RenameTable(
                name: "searched_food_result",
                newName: "Searched_Food_Result");

            migrationBuilder.RenameIndex(
                name: "IX_user_searches_User_Info",
                table: "User_Searches",
                newName: "IX_User_Searches_User_Info");

            migrationBuilder.RenameIndex(
                name: "IX_searched_food_result_User_Searches",
                table: "Searched_Food_Result",
                newName: "IX_Searched_Food_Result_User_Searches");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_Searches",
                table: "User_Searches",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_Info",
                table: "User_Info",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Searched_Food_Result",
                table: "Searched_Food_Result",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Searched_Food_Result_User_Searches_User_Searches",
                table: "Searched_Food_Result",
                column: "User_Searches",
                principalTable: "User_Searches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Searches_User_Info_User_Info",
                table: "User_Searches",
                column: "User_Info",
                principalTable: "User_Info",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
