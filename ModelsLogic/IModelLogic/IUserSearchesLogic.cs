using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace ModelsLogic.IModelLogic
{
    public interface IUserSearchesLogic
    {
        Task<int> Add(int userId, string userQuery);
        IEnumerable<UserSearches> GetAllUsersSearcheses();
        UserSearches GetById(int id);
        List<UserSearches> GetAllSearchesesForCurrentDay(int userId);
    }
}