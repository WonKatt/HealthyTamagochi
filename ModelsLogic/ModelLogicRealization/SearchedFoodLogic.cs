using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using Models;
using ModelsLogic.HelpClasses;
using ModelsLogic.IModelLogic;

namespace ModelsLogic.ModelLogicRealization
{
    public class SearchedFoodLogic:ISearchedFoodLogic
    {
        private readonly TeencyBarkerContext _context;

        public SearchedFoodLogic(TeencyBarkerContext context)
        {
            _context = context;
        }

        public IEnumerable<SearchedFoodResult> GetAllSearchedFoodResults() =>
            _context.SearchedFoodResult.Include(x => x.UserSearches);

        public async Task AddSearchedFoodList(List<SearchedFoodResult> searchedFood)
        {            
            await _context.SearchedFoodResult.AddRangeAsync(searchedFood);
            await _context.SaveChangesAsync();
        }

        public SearchedFoodResult GetResultsForDay(List<UserSearches> userSearcheses)
        {
            var searchesList = new List<SearchedFoodResult>();
            foreach (var searches in userSearcheses)
            {
                searchesList.AddRange(searches.SearchedFoodResults);
            }
            if (searchesList.Count != 0)
            {
             return new SearchedFoodResult()
             {
               NfCalories= searchesList.Sum(x=>x.NfCalories),
               NfTotalFat= searchesList.Sum(x=>x.NfTotalFat),
               NfProtein = searchesList.Sum(x=>x.NfProtein),
               NfTotalCarbohydrate= searchesList.Sum(x=>x.NfTotalCarbohydrate),
               NfP= searchesList.Sum(x=>x.NfP),
               NfSugars= searchesList.Sum(x=>x.NfSugars),
               NfPotassium= searchesList.Sum(x=>x.NfPotassium),
               NfCholesterol= searchesList.Sum(x=>x.NfCholesterol),
               NfDietaryFiber= searchesList.Sum(x=>x.NfDietaryFiber),
               NfSaturatedFat= searchesList.Sum(x=>x.NfSaturatedFat)
             };   
            }
            else
            {
                return null;
            }                
        }
    }
}