using System.ComponentModel.DataAnnotations;

namespace Student_registration.Models
{
    public class Signin
    {
               
       
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
      

    }
}
