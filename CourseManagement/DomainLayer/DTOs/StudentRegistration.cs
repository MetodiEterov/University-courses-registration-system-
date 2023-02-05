using System.ComponentModel.DataAnnotations;

namespace DomainLayer.DTOs
{
    public class StudentRegistration
    {
        [Required(ErrorMessage = "Name is required!")]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress]
        public string StudentEmail { get; set; }

        [Required(ErrorMessage = "Password is required!")]
		[DataType(DataType.Password)]
		public string StudentPassword { get; set; }

        [Compare("StudentPassword", ErrorMessage = "The password does not match!")]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; }
    }
}
