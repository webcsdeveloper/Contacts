using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Contacts.Models
{
    public class AppUser : IdentityUser
    {
        // show wether administrator confirm user account or not
        public bool Confirmed { get; set; }
        
    }
}
