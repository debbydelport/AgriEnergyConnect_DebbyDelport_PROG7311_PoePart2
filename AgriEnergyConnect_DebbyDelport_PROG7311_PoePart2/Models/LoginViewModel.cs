using System.ComponentModel.DataAnnotations;

namespace AgriEnergyConnect_DebbyDelport_PROG7311_PoePart2.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
