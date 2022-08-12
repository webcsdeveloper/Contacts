using Contacts.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Contacts.Models.DB;

namespace Contacts.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public  DbSet<WorkInfo> WorkInfos { get; set; }
        public DbSet<HomeInfo> HomeInfos { get; set; }
    }
}