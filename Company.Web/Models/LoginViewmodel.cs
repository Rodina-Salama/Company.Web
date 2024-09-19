using System.ComponentModel.DataAnnotations;

namespace Company.Web.Models
{
	public class LoginViewmodel
	{
		[Required(ErrorMessage = "Email Is Required")]
		[EmailAddress(ErrorMessage = "Invalid Format for Email")]
		public string Email { get; set; }
		
		
		[Required(ErrorMessage = "Password Is Required")]
		public string Password { get; set; }
		public bool RememberMe { get; set; }

	}
}
