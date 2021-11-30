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

    }
}
