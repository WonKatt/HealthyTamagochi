using System.Collections.Generic;
using System.Linq;
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
            var userTotalStatistic = _userFoodLogic.GetMaxResultsForDay(userSearcheses);
            return new DataPerDay
            {
                Calories = userTotalStatistic.NfCalories,
                Carbohydrates = userTotalStatistic.NfTotalCarbohydrate,
                Fat = userTotalStatistic.NfTotalFat,
                Squirrels = userTotalStatistic.NfProtein
            };
        }
        public async Task<int> UserRegistration([FromQuery] string firstName,[FromQuery] string lastName, 
            [FromQuery] string gender, [FromQuery]double weight,[FromQuery] double height, [FromQuery]int fullYears )
        {
           return await _userInfoLogic.AddUser(new UserInfo
            {
                FirstName=firstName,LastName=lastName,FullYears=fullYears,Gender=gender,
                Height=height,Weight=weight
            });            
        }
        private List<SearchedFoodResult> GetAllFoodResultPerDayForUser(int userId)
        {
            var userSearcheses = _userSearchesLogicLogic.GetAllSearchesesForCurrentDay(userId);            
            return _userFoodLogic.GetAllResultsPerDay(userSearcheses);
        }
        
        public List<CcalPerDay> GetAllCcalFromProductsPerDay([FromQuery] int userId)
        {
            return GetAllFoodResultPerDayForUser(userId).Select(x=>new CcalPerDay()
            {
                Calories=x.NfCalories,
                Name=x.FoodName
            }).ToList();
        }

        public List<AllInformationAboutPFC> GetAllInformtaionAboutDailyPFCs([FromQuery]int userId)
        {
            return GetAllFoodResultPerDayForUser(userId).Select(result => new AllInformationAboutPFC
            {
                Name=result.FoodName,
                Carbohydrates=result.NfTotalCarbohydrate,
                Fat=result.NfTotalFat,
                Proteins=result.NfProtein
            }).ToList();
        } 
        
    }
}