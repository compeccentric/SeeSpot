using Microsoft.EntityFrameworkCore;
using SeeSpot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeeSpot.Data
{
    public class SeeSpotDbContext : DbContext
    {
        public DbSet<Pet> Pets { get; set; }
        public SeeSpotDbContext(DbContextOptions<SeeSpotDbContext> options) : base(options)
        {

        }
    }
}
