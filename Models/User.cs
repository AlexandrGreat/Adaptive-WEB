using System.ComponentModel.DataAnnotations;

namespace LR6.Models
{
    public class User
    {
        public string Name{ get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Password { get; set; }
        public DateOnly LastLogin { get; set; }
        public int LoginAttempts { get; set; }
    }
}
