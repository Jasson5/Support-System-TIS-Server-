using Authentication.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Authentication.DataAccess.Context
{
    public abstract class AuthContext : IdentityDbContext
    {
        public AuthContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //Creacion de usuario admin por defecto en el sistema
        {
            modelBuilder.Entity<User>()
                .HasData(new
                {
                    Id = 1,
                    Username = "admin",
                    FirstName = "Admin",
                    LastName = "Admin",
                    GivenName = "jeyson",
                    Email = "jeysonerikvaldiviabernal@gmail.com",
                    IsEnabled = true
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
