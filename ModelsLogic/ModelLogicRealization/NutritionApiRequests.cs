using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Extensions.Logging;
using Models;
using ModelsLogic.HelpClasses;
using ModelsLogic.IModelLogic;
using Newtonsoft.Json;

namespace ModelsLogic.ModelLogicRealization
{
    public class NutritionApiRequests:INutritionApi
    {
        private readonly HttpClient _client;
        private readonly ILogger _logger;
        private readonly IUserInfoLogic _userInfoLogic;
        private readonly ISearchedFoodLogic _userFoodLogic;
        private readonly IUserSearchesLogic _userSearchesLogicLogic;
        public NutritionApiRequests(HttpClient client, ILogger<NutritionApiRequests> logger, 
            IUserInfoLogic userInfoLogic, ISearchedFoodLogic userFoodLogic, IUserSearchesLogic userSearchesLogicLogic)
        {
            _client = client;
            _logger = logger;
            _userInfoLogic = userInfoLogic;
            _userFoodLogic = userFoodLogic;
            _userSearchesLogicLogic = userSearchesLogicLogic;
        }

        public async Task<string> GetJsonSchema(string query)
        {
            var httpRequestMessage =new HttpRequestMessage()
            {
                Method=HttpMethod.Post,
                Content = new StringContent($"{{\n \"query\":\"{query}\"\n}}",Encoding.UTF8,"application/json"),
                RequestUri = new Uri("https://trackapi.nutritionix.com/v2/natural/nutrients"),                
                Version = HttpVersion.Version11
            };            
            httpRequestMessage.Headers.Add("Accept","application/json");
            httpRequestMessage.Headers.Add("x-app-id","0e727c2b");
            httpRequestMessage.Headers.Add("x-app-key","9c92be2299a0b997c6cda29f59f85be3");
            var response = await _client.SendAsync(httpRequestMessage);
            
            var responseContext = await response.Content.ReadAsStringAsync();
            _logger.LogInformation($"Response gaped from query: {query}  " +
                                   $"with status code {response.StatusCode}");
            return responseContext;
        }

        public NutritionApiResponse ParseJson(string jsonRaw)
        {
                return  JsonConvert.DeserializeObject<NutritionApiResponse>(jsonRaw);
        }

        public async Task WriteInformationAboutFoodInDb(string query, int userId)
        {
            if (_userInfoLogic.IsUserWithExist(userId))
            {                
                var searchId= await _userSearchesLogicLogic.Add(userId, query);
                var jsonSchema = await GetJsonSchema(query);
                if (!string.IsNullOrWhiteSpace(jsonSchema))
                {
                    var responseObject = ParseJson(jsonSchema);
                    if (responseObject.Message == null)
                    {
                        var searchedList = new List<SearchedFoodResult>();
                        foreach (var nutrition in responseObject.Foods)
                        {
                            searchedList.Add(new SearchedFoodResult
                            {                                
                                FoodName = nutrition.Food_name,
                                NfP = nutrition.Nf_p,
                                NfCalories = nutrition.Nf_calories,
                                NfCholesterol = nutrition.Nf_cholesterol,
                                NfSugars = nutrition.Nf_sugars,
                                NfProtein = nutrition.Nf_protein,
                                NfPotassium = nutrition.Nf_potassium,
                                NfTotalFat = nutrition.Nf_total_fat,
                                NfDietaryFiber = nutrition.Nf_dietary_fiber,
                                NfSaturatedFat = nutrition.Nf_saturated_fat,
                                NfTotalCarbohydrate = nutrition.Nf_total_carbohydrate,
                                ServingQty = nutrition.Serving_qty,
                                ServingWeightGrams = nutrition.Serving_weight_grams,
                                UserSearchesId = searchId,
                                
                            });
                        }
                        await _userFoodLogic.AddSearchedFoodList(searchedList);
                    }
                }
            }
        }
    }
}