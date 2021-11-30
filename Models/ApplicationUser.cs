using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes_Api.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Hero> Heroes { get; set; }
    }
}
