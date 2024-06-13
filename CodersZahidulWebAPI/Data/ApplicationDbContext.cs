using CodersZahidul.Models;
using CodersZahidulWebAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CodersZahidul.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Category> categories { get; set; }
        public DbSet<ShoppingCart> shoppingCarts { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<ApplicationUser> applicationUsers {get; set;}
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
