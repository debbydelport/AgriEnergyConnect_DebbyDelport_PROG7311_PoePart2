using AgriEnergyConnect_DebbyDelport_PROG7311_PoePart2.Data;
using System.ComponentModel.DataAnnotations;

namespace AgriEnergyConnect_DebbyDelport_PROG7311_PoePart2.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Register as Employee")]
        public bool IsEmployee { get; set; } // ✅ Checkbox
        public UserRole UserRole { get; internal set; }
    }
}
