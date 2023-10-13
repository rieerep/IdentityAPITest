using Microsoft.AspNetCore.Identity;

namespace IdentityAPIWorkshop.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Nick { get; set; }
    }
}