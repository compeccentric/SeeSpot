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
        public IActionResult Add()
        {
            AddPetViewModel addPetViewModel = new AddPetViewModel(context.Breeds.ToList());
            return View(addPetViewModel);
        }
        
        [HttpPost]
        public IActionResult Add(AddPetViewModel addPetViewModel)
        { 
     
            if (ModelState.IsValid)
            {
                Breed newBreed =
                    context.Breeds.Single(c => c.ID == addPetViewModel.BreedID);

                // Add the new cheese to my existing cheeses
                Pet newPet = new Pet
                {
                    Name = addPetViewModel.Name,
                    Weight = addPetViewModel.Weight,
                    Breed = newBreed,
                     
                };

                context.Pets.Add(newPet);
                context.SaveChanges();

                return Redirect("/Pet");
            }

            return View(addPetViewModel);
        }

        //public IActionResult Remove()
        //{
        //    ViewBag.title = "Remove Cheeses";
        //    ViewBag.cheeses = context.Cheeses.ToList();
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Remove(int[] cheeseIds)
        //{
        //    foreach (int cheeseId in cheeseIds)
        //    {
        //        Cheese theCheese = context.Cheeses.Single(c => c.ID == cheeseId);
        //        context.Cheeses.Remove(theCheese);
        //    }

        //    context.SaveChanges();

        //    return Redirect("/");
        //}
    }
}