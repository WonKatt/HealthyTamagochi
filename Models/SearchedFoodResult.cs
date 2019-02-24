using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Models
{
    [Table("searched_food_result")]
    public class SearchedFoodResult
    {
            public int Id { get; set; }
            public int UserSearchesId { get; set; }
            public virtual UserSearches UserSearches{ get; set; }
            public string FoodName { get; set; }
            public int ServingQty { get; set; }
            public double ServingWeightGrams { get; set; }
            public double NfCalories {get;set;}
            public double NfTotalFat {get;set;}
            public double NfSaturatedFat {get;set;}
            public double NfCholesterol {get;set;}
            public double NfTotalCarbohydrate {get;set;}
            public double NfDietaryFiber{get;set;}
            public double NfSugars {get;set;}
            public double NfProtein {get;set;}
            public double NfPotassium {get;set;}
            public double NfP { get; set; }
    }
}