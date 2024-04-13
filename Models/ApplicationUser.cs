using Microsoft.AspNetCore.Identity;

namespace COMP2139_Assignment.Models {
    public class ApplicationUser : IdentityUser {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
