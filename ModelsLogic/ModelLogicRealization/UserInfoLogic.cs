using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;
using ModelsLogic.IModelLogic;

namespace ModelsLogic.ModelLogicRealization
{
    public class UserInfoLogic:IUserInfoLogic
    {
        private TeencyBarkerContext _context;

        public UserInfoLogic(TeencyBarkerContext context)
        {
            _context = context;
        }

        public IEnumerable<UserInfo> GetAllUsers() =>
            _context.UserInfo;

        public bool IsUserWithExist(int userId) => GetAllUsers().Any(user => user.Id == userId);

        public UserInfo GetUserById(int userId)
        {
            return  GetAllUsers().FirstOrDefault(user => user.Id == userId);
        }
        public async Task AddUser(UserInfo user)
        {
            await _context.UserInfo.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}