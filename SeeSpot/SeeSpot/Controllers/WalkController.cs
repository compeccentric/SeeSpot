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
        public ActionResult Details(int ID)
        {

            Walk walk = context.Walks.Find(ID);
            DetailsWalkViewModel detailsWalkViewModel = new DetailsWalkViewModel
            {
                ID = walk.ID,
                Distance = walk.Distance,
                Poop = walk.Poop,
                Pee = walk.Pee,
                Date = walk.Date,
                Time = walk.Time,
                Notes = walk.Notes



            };
            return View(detailsWalkViewModel);

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
        [HttpGet]
        public ActionResult Edit(int ID)
        {

            Walk walk = context.Walks.Find(ID);
            EditWalkViewModel editWalkViewModel = new EditWalkViewModel
            {
                ID = walk.ID,
                Distance = walk.Distance,
                Poop = walk.Poop,
                Pee = walk.Pee,
                Date = walk.Date,
                Time = walk.Time,
                Notes = walk.Notes,
                

            };
            return View(editWalkViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditWalkViewModel model)
        {

            if (ModelState.IsValid)
            {


                Walk walk = context.Walks.Find(model.ID);
                walk.ID = model.ID;
                walk.Distance = model.Distance;
                walk.Poop = model.Poop;
                walk.Pee = model.Pee;
                walk.Date = model.Date;
                walk.Time = model.Time;
                walk.Notes = model.Notes;

                context.Update(walk);
                context.SaveChanges();
                return RedirectToAction("index");
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var walk = await context.Walks.FindAsync(id);
            context.Walks.Remove(walk);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");

        }
    }
}