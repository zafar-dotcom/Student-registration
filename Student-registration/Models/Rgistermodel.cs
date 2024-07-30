using System.ComponentModel.DataAnnotations;

namespace Student_registration.Models
{
    public class Rgistermodel
    {
        [Required(ErrorMessage = "FirstName is required.")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirmation Password is required.")]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone is required.")]
        public string Phone { get; set; }
        public string Gender { get; set; }
    }
}
