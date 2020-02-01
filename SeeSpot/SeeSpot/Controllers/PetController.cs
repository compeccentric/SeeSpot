using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SeeSpot.Data;
using SeeSpot.Models;
using SeeSpot.ViewModels;

namespace SeeSpot.Controllers
{
    public class PetController : Controller
    {
        private SeeSpotDbContext context;
        private readonly IHostingEnvironment hostingEnvironment;

        public PetController(SeeSpotDbContext dbContext, IHostingEnvironment hostingEnvironment)
        {
            context = dbContext;
            this.hostingEnvironment = hostingEnvironment;
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
        public IActionResult Add(AddPetViewModel model)
        { 
     
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Photo != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }








                Breed newBreed =
                    context.Breeds.Single(c => c.ID == model.BreedID);

                // Add the new cheese to my existing cheeses
                Pet newPet = new Pet
                {
                    Name = model.Name,
                    Weight = model.Weight,
                    Breed = newBreed,
                    PhotoPath = uniqueFileName
                     
                };

                context.Pets.Add(newPet);
                context.SaveChanges();

                return Redirect("/Pet");
            }

            return View(model);
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