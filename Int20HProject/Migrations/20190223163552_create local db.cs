using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Int20HProject.Migrations
{
    public partial class createlocaldb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User_Info",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Info", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User_Searches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    User_Info = table.Column<int>(nullable: true),
                    SearchDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Searches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Searches_User_Info_User_Info",
                        column: x => x.User_Info,
                        principalTable: "User_Info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Searched_Food_Result",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    User_Searches = table.Column<int>(nullable: true),
                    Food_name = table.Column<string>(nullable: true),
                    Serving_qty = table.Column<int>(nullable: false),
                    Serving_weight_grams = table.Column<double>(nullable: false),
                    Nf_calories = table.Column<double>(nullable: false),
                    Nf_total_fat = table.Column<double>(nullable: false),
                    Nf_saturated_fat = table.Column<double>(nullable: false),
                    Nf_cholesterol = table.Column<double>(nullable: false),
                    Nf_total_carbohydrate = table.Column<double>(nullable: false),
                    Nf_dietary_fiber = table.Column<double>(nullable: false),
                    Nf_sugars = table.Column<double>(nullable: false),
                    Nf_protein = table.Column<double>(nullable: false),
                    Nf_potassium = table.Column<double>(nullable: false),
                    Nf_p = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Searched_Food_Result", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Searched_Food_Result_User_Searches_User_Searches",
                        column: x => x.User_Searches,
                        principalTable: "User_Searches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Searched_Food_Result_User_Searches",
                table: "Searched_Food_Result",
                column: "User_Searches");

            migrationBuilder.CreateIndex(
                name: "IX_User_Searches_User_Info",
                table: "User_Searches",
                column: "User_Info");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Searched_Food_Result");

            migrationBuilder.DropTable(
                name: "User_Searches");

            migrationBuilder.DropTable(
                name: "User_Info");
        }
    }
}
