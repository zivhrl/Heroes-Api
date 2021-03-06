using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Heroes_Api.Models
{
    public class Credentials
    {
        [Required]
        public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"(?=.*\d)(?=.*[a-z])(?=.*\W)(?=.*[A-Z]).{8,}")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}