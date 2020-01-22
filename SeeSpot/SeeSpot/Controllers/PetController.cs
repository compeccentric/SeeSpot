using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SeeSpot.Data;
using SeeSpot.Models;

namespace SeeSpot.Controllers
{
    public class PetController : Controller
    {
        private SeeSpotDbContext context;
        
        public PetController(SeeSpotDbContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Index()
        {
            IList<Pet> pets = context.Pets.ToList();
            
            return View(pets);
        }

    }
}