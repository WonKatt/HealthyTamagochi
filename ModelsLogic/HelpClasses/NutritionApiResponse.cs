using System.Collections.Generic;

namespace ModelsLogic.HelpClasses
{
    public class NutritionApiResponse
    {
      public List<Food> Foods { get; set; }
      public string Message { get; set; }
    }
}