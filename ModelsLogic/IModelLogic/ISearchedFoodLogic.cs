using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace ModelsLogic.IModelLogic
{
    public interface ISearchedFoodLogic
    {
        Task AddSearchedFoodList(List<SearchedFoodResult> searchedFood);
        SearchedFoodResult GetMaxResultsForDay(List<UserSearches> userSearcheses);
        List<SearchedFoodResult> GetAllResultsPerDay(List<UserSearches> userSearcheses);
    }
}