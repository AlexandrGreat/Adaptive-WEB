using System.ComponentModel.DataAnnotations;

namespace LR6.Models
{
    public class RegistrationModel
    {
        [MaxLength(15, ErrorMessage = "Maximum length 15")]
        public string Name { get; set; }
        [MaxLength(15, ErrorMessage = "Maximum length 15")]
        public string Surname { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email address")]
        public string Email { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Password { get; set; }
    }
}