using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SeeSpot.Data;
using SeeSpot.Models;
using SeeSpot.ViewModels;

namespace SeeSpot.Controllers
{

    public class WalkController : Controller
    {
        private readonly SeeSpotDbContext context;

        public WalkController(SeeSpotDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            IList<Walk> walks = context.Walks.ToList();

            return View(walks);
        }


        public IActionResult Add()
        {
            AddWalkViewModel addWalkViewModel = new AddWalkViewModel();
            return View(addWalkViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddWalkViewModel addWalkViewModel)
        {

            if (ModelState.IsValid)
            {
                
                // Add the new cheese to my existing cheeses
                Walk newWalk = new Walk
                {
                    Distance = addWalkViewModel.Distance,
                    Poop = addWalkViewModel.Poop,
                    Pee = addWalkViewModel.Pee,
                    Date = addWalkViewModel.Date,
                    Time = addWalkViewModel.Time,
                    Notes = addWalkViewModel.Notes,


                };

                context.Walks.Add(newWalk);
                context.SaveChanges();

                return Redirect("/Walk");
            }

            return View(addWalkViewModel);
        }
    }
}