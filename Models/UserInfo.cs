using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("user_info")]
    public class UserInfo
    {
        public int Id { get; set; }        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int FullYears { get; set; }
        public double Weight { get; set; }
        public string Gender { get; set; }
        public double Height { get; set; }
    }
}