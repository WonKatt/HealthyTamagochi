using Microsoft.EntityFrameworkCore.Migrations;

namespace Int20HProject.Migrations
{
    public partial class changetables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Serving_weight_grams",
                table: "searched_food_result",
                newName: "ServingWeightGrams");

            migrationBuilder.RenameColumn(
                name: "Serving_qty",
                table: "searched_food_result",
                newName: "ServingQty");

            migrationBuilder.RenameColumn(
                name: "Nf_total_fat",
                table: "searched_food_result",
                newName: "NfTotalFat");

            migrationBuilder.RenameColumn(
                name: "Nf_total_carbohydrate",
                table: "searched_food_result",
                newName: "NfTotalCarbohydrate");

            migrationBuilder.RenameColumn(
                name: "Nf_sugars",
                table: "searched_food_result",
                newName: "NfSugars");

            migrationBuilder.RenameColumn(
                name: "Nf_saturated_fat",
                table: "searched_food_result",
                newName: "NfSaturatedFat");

            migrationBuilder.RenameColumn(
                name: "Nf_protein",
                table: "searched_food_result",
                newName: "NfProtein");

            migrationBuilder.RenameColumn(
                name: "Nf_potassium",
                table: "searched_food_result",
                newName: "NfPotassium");

            migrationBuilder.RenameColumn(
                name: "Nf_p",
                table: "searched_food_result",
                newName: "NfP");

            migrationBuilder.RenameColumn(
                name: "Nf_dietary_fiber",
                table: "searched_food_result",
                newName: "NfDietaryFiber");

            migrationBuilder.RenameColumn(
                name: "Nf_cholesterol",
                table: "searched_food_result",
                newName: "NfCholesterol");

            migrationBuilder.RenameColumn(
                name: "Nf_calories",
                table: "searched_food_result",
                newName: "NfCalories");

            migrationBuilder.RenameColumn(
                name: "Food_name",
                table: "searched_food_result",
                newName: "FoodName");

            migrationBuilder.AddColumn<string>(
                name: "UserQuery",
                table: "user_searches",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserQuery",
                table: "user_searches");

            migrationBuilder.RenameColumn(
                name: "ServingWeightGrams",
                table: "searched_food_result",
                newName: "Serving_weight_grams");

            migrationBuilder.RenameColumn(
                name: "ServingQty",
                table: "searched_food_result",
                newName: "Serving_qty");

            migrationBuilder.RenameColumn(
                name: "NfTotalFat",
                table: "searched_food_result",
                newName: "Nf_total_fat");

            migrationBuilder.RenameColumn(
                name: "NfTotalCarbohydrate",
                table: "searched_food_result",
                newName: "Nf_total_carbohydrate");

            migrationBuilder.RenameColumn(
                name: "NfSugars",
                table: "searched_food_result",
                newName: "Nf_sugars");

            migrationBuilder.RenameColumn(
                name: "NfSaturatedFat",
                table: "searched_food_result",
                newName: "Nf_saturated_fat");

            migrationBuilder.RenameColumn(
                name: "NfProtein",
                table: "searched_food_result",
                newName: "Nf_protein");

            migrationBuilder.RenameColumn(
                name: "NfPotassium",
                table: "searched_food_result",
                newName: "Nf_potassium");

            migrationBuilder.RenameColumn(
                name: "NfP",
                table: "searched_food_result",
                newName: "Nf_p");

            migrationBuilder.RenameColumn(
                name: "NfDietaryFiber",
                table: "searched_food_result",
                newName: "Nf_dietary_fiber");

            migrationBuilder.RenameColumn(
                name: "NfCholesterol",
                table: "searched_food_result",
                newName: "Nf_cholesterol");

            migrationBuilder.RenameColumn(
                name: "NfCalories",
                table: "searched_food_result",
                newName: "Nf_calories");

            migrationBuilder.RenameColumn(
                name: "FoodName",
                table: "searched_food_result",
                newName: "Food_name");
        }
    }
}
