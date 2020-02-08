using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeeSpot.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
    }
}
