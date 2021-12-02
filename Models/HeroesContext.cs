using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes_Api.Models
{
    public class HeroesContext: IdentityDbContext<ApplicationUser>
    {
        public HeroesContext(DbContextOptions<HeroesContext> opts): base(opts) { }

        public DbSet<Hero> Heroes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            seedUsers(builder);
        }

        private void seedUsers(ModelBuilder builder)
        {
            PasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();
            ApplicationUser user1 = new ApplicationUser
            {

                UserName = "ziv",
                NormalizedUserName = "ziv".ToUpper(),
                Email = "ziv@t.com",
                NormalizedEmail = "ziv@t.com".ToUpper(),
                PasswordHash = hasher.HashPassword(null, "Zaqwer123!")
            };
            ApplicationUser user2 = new ApplicationUser
            {

                UserName = "rony",
                NormalizedUserName = "rony".ToUpper(),
                Email = "rony@t.com",
                NormalizedEmail = "rony@t.com".ToUpper(),
                PasswordHash = hasher.HashPassword(null, "Zaqwer123!")
            };
            ApplicationUser user3 = new ApplicationUser
            {

                UserName = "dani",
                NormalizedUserName = "dani".ToUpper(),
                Email = "dani@t.com",
                NormalizedEmail = "dani@t.com".ToUpper(),
                PasswordHash = hasher.HashPassword(null, "Zaqwer123!")
            };
            builder.Entity<ApplicationUser>().HasData(user1, user2, user3);

        }
    }
}
