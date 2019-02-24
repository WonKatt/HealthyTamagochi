using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("user_searches")]
    public class UserSearches
    {
        public int Id { get; set; }
        public int UserInfoId { get; set; }
        public UserInfo UserInfo { get; set; }
        public DateTime SearchDateTime { get; set; }
        public List<SearchedFoodResult> SearchedFoodResults { get; set; }
        public string UserQuery { get; set; }
    }
}