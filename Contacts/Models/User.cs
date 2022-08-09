using Microsoft.AspNetCore.Identity;

namespace Contacts.Models
{
    public class AppUser : IdentityUser
    {
        // show wether administrator confirm user account or not
        public bool Confirmed { get; set; }
    }
}
