using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using VideoRental.EntityModel.Entities;

namespace VideoRental.Web.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Gender> Genders { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
    }
}