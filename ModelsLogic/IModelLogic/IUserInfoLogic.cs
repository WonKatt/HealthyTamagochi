using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace ModelsLogic.IModelLogic
{
    public interface IUserInfoLogic
    {
        IEnumerable<UserInfo> GetAllUsers();
        bool IsUserWithExist(int userId);
        Task AddUser(UserInfo user);
        UserInfo GetUserById(int userId);
    }
}