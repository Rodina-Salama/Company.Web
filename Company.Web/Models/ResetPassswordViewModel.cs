using System.ComponentModel.DataAnnotations;

namespace Company.Web.Models
{
	public class ResetPassswordViewModel
	{
		[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{6,}$",
		ErrorMessage = "Password must be at least 6 characters long, contain at least 1 uppercase letter, 1 lowercase letter, 1 digit, and 1 special character.")]
		[Required(ErrorMessage = "Password Is Required")]
		public string Password { get; set; }
		[Required(ErrorMessage = " Confirm Password Is Required")]
		[Compare(nameof(Password), ErrorMessage = "Confirm Password Doesn't Match Password")]
		public string ConfirmedPassword { get; set; }
		public string Email { get; set; }
		public string Token { get; set; }
	}
}
