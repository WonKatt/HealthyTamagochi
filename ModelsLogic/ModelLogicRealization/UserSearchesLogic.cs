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
    public class UserSearchesLogic:IUserSearchesLogic
    {
        private readonly TeencyBarkerContext _context;

        public UserSearchesLogic(TeencyBarkerContext context)
        {
            _context = context;
        }

        public IEnumerable<UserSearches> GetAllUsersSearcheses() =>
            _context.UserSearchese.Include(x => x.SearchedFoodResults);

        public async Task<int> Add(int userId, string userQuery)
        {
            var userSearches = new UserSearches
            {
                SearchDateTime=DateTime.Now,
                UserInfoId= userId,
                UserQuery=userQuery
            };
            await _context.UserSearchese.AddAsync(userSearches);
            await _context.SaveChangesAsync();
            return userSearches.Id;
        }

        public List<UserSearches> GetAllSearchesesForCurrentDay(int userId)
        {
            return GetAllUsersSearcheses().Where(searches => searches.UserInfoId==userId &&
                                                            searches.SearchDateTime.Date == DateTime.Today.Date)
                 .ToList();
        }
        public UserSearches GetById(int id) =>
            GetAllUsersSearcheses().FirstOrDefault(searches => searches.Id == id);
    }
}