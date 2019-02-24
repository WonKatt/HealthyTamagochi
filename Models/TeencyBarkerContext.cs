using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class TeencyBarkerContext:DbContext
    {
        public TeencyBarkerContext(DbContextOptions<TeencyBarkerContext> options):base(options:options)
        {
           
        }

        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<UserSearches> UserSearchese { get; set; }
        public virtual DbSet<SearchedFoodResult> SearchedFoodResult { get; set; }
    }
}