

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SeeSpot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeeSpot.Data
{
    public class SeeSpotDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
               
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public SeeSpotDbContext(DbContextOptions<SeeSpotDbContext> options) : base(options)
        {

        }

        
        
        

    }
}
