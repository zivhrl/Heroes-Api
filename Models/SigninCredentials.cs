using System.ComponentModel.DataAnnotations;

namespace Heroes_Api.Models
{
    public class SigninCredentials
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [RegularExpression(@"(?=.*\d)(?=.*[a-z])(?=.*\W)(?=.*[A-Z]).{8,}",ErrorMessage ="Password in Wrong Format")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}