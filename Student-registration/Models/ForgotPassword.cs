using System.ComponentModel.DataAnnotations;

namespace Student_registration.Models
{
    public class ForgotPassword
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
