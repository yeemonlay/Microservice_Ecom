using Microsoft.AspNetCore.Identity;

namespace Ecom.Services.AuthAPI.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
    }
}
