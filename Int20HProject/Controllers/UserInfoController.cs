using System.Threading.Tasks;
using Int20HProject.Model;
using Microsoft.AspNetCore.Mvc;
using Models;
using ModelsLogic.IModelLogic;

namespace Int20HProject.Controllers
{  
    [Route("/api/[controller]/[action]")]
    public class UserInfoController : Controller
    {
        private readonly INutritionApi _nutritionApi;
        private readonly IUserInfoLogic _userInfoLogic;
        private readonly ISearchedFoodLogic _userFoodLogic;
        private readonly IUserSearchesLogic _userSearchesLogicLogic;

        public UserInfoController(INutritionApi nutritionApi,
            ISearchedFoodLogic userFoodLogic, 
            IUserSearchesLogic userSearchesLogicLogic, 
            IUserInfoLogic userInfoLogic)
        {
            _nutritionApi = nutritionApi;
            _userFoodLogic = userFoodLogic;
            _userSearchesLogicLogic = userSearchesLogicLogic;
            _userInfoLogic = userInfoLogic;
        }

        public async Task<DataPerDay> GetInformationAboutUserForDay([FromQuery] int userId, [FromQuery] string query)
        {
            await _nutritionApi.WriteInformationAboutFoodInDb(query, userId);
            var userSearcheses = _userSearchesLogicLogic.GetAllSearchesesForCurrentDay(userId);            
            var userTotalStatistic = _userFoodLogic.GetResultsForDay(userSearcheses);
            return new DataPerDay
            {
                Calories = userTotalStatistic.NfCalories,
                Carbohydrates = userTotalStatistic.NfTotalCarbohydrate,
                Fat = userTotalStatistic.NfTotalFat,
                Squirrels = userTotalStatistic.NfProtein
            };
        }
        public async Task<IActionResult> UserRegistration([FromQuery] string firstName,[FromQuery] string lastName, 
            [FromQuery] string gender, [FromQuery]double weight,[FromQuery] double height, [FromQuery]int fullYears )
        {
            await _userInfoLogic.AddUser(new UserInfo
            {
                FirstName=firstName,LastName=lastName,FullYears=fullYears,Gender=gender,
                Height=height,Weight=weight
            });
            return Ok();
        }

        public DataPerDay GetNormalInformationForUserParameters([FromQuery] int userId)
        {
            _userInfoLogic.GetUserById(userId);
            return new DataPerDay()
            {
                
            };
        }
    }
}