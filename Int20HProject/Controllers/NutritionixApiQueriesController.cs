using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ModelsLogic.IModelLogic;

namespace Int20HProject.Controllers
{
    [Route("/api/Nutrition/[action]")]
    public class NutritionixApiQueriesController:Controller
    {
        private readonly INutritionApi _nutritionApi;

        public NutritionixApiQueriesController(INutritionApi nutritionApi)
        {
            _nutritionApi = nutritionApi;
        }

        public async Task<IActionResult> PutObject([FromQuery] string query, [FromQuery] int id)
        {
            await _nutritionApi.WriteInformationAboutFoodInDb(query, id);
            return Ok();
        } 
    }
}