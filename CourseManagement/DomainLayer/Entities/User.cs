using Microsoft.AspNetCore.Identity;

namespace DomainLayer.Entities
{
    public class User : IdentityUser
    {
        public string StudentId { get; set; }

        public string StudentName { get; set; }

        public string StudentPassword { get; set; }

        public string StudentEmail { get; set; }
    }
}
