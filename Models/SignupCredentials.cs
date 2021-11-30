using System.ComponentModel.DataAnnotations;

namespace Heroes_Api.Models
{
    public class SignupCredentials
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"(?=.*\d)(?=.*[a-z])(?=.*\W)(?=.*[A-Z]).{8,}")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}