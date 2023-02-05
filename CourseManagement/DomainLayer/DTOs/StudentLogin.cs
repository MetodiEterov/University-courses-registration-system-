using System.ComponentModel.DataAnnotations;

namespace DomainLayer.DTOs
{
    public class StudentLogin
    {
        [Required]
        [EmailAddress]
        public string StudentEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string StudentPassword { get; set; }
    }
}
