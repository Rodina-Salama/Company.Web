using System.ComponentModel.DataAnnotations;

namespace Company.Web.Models
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage="First Name Is Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name Is Required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email Is Required")]
        [EmailAddress(ErrorMessage = "Invalid Format for Email")]
        public string Email { get; set; }
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{6,}$",
         ErrorMessage = "Password must be at least 6 characters long, contain at least 1 uppercase letter, 1 lowercase letter, 1 digit, and 1 special character.")]
        [Required(ErrorMessage = "Password Is Required")]
        public string Password { get; set; }
        [Required(ErrorMessage = " Confirm Password Is Required")]
        [Compare(nameof(Password),ErrorMessage ="Confirm Password Doesn't Match Password")]
        public string ConfirmedPassword { get; set; }
        [Required(ErrorMessage = "Required To Agree")]
        public bool IsActive { get; set; }


    }
}
