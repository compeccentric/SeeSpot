using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SeeSpot.Data;
using SeeSpot.Models;
using SeeSpot.ViewModels;

namespace SeeSpot.Controllers
{
    public class PetController : Controller
    {
        private readonly SeeSpotDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHostingEnvironment hostingEnvironment;

        public PetController(SeeSpotDbContext dbContext,
                            IHostingEnvironment hostingEnvironment, UserManager<ApplicationUser> userManager)

        {
            context = dbContext;
            this.hostingEnvironment = hostingEnvironment;
            this.userManager = userManager;

        }
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);// will give the user's userId
            var userName = User.FindFirstValue(ClaimTypes.Name); // will give the user's userName

            ApplicationUser applicationUser = await userManager.GetUserAsync(User);
            string userEmail = applicationUser?.Email; // will give the user's Email
            var OwnerPets = from m in context.Pets
                            where m.OwnerId == userId
                            select m;
            ViewBag.OwnerPets = OwnerPets;
            return View();
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

                //Breed newBreed =
                //    context.Breeds.Single(c => c.ID == model.BreedID);

                // Add the new cheese to my existing cheeses
                Pet newPet = new Pet
                {
                    Name = model.Name,
                    OwnerId = model.OwnerId,
                    Weight = model.Weight,
                    BreedName = model.BreedName,
                    PhotoPath = uniqueFileName,
                    Gender = model.Gender,
                    Color = model.Color,
                    Birthday = model.Birthday,
                    Microchipped = model.Microchipped,
                    Fixed = model.Fixed
                };

                context.Pets.Add(newPet);
                context.SaveChanges();

                return Redirect("/Pet");
            }

            return View(model);
        }

        public ActionResult Profile(int ID)
        {
            
            Pet pet = context.Pets.Find(ID);
            ProfileViewModel profileViewModel = new ProfileViewModel
            {
                ID = pet.ID,
                Name = pet.Name,
                Birthday = pet.Birthday,
                Color = pet.Color,
                Weight = pet.Weight,
                Gender = pet.Gender,
                BreedName = pet.BreedName,                
                Microchipped = pet.Microchipped,
                Fixed = pet.Fixed,
                ExistingPhotoPath = pet.PhotoPath,
                
                
            };
            return View(profileViewModel);
            
            
        }

        [HttpGet]
        public ActionResult EditProfile(int ID)
        {

            Pet pet = context.Pets.Find(ID);
            EditProfileViewModel editProfileViewModel = new EditProfileViewModel(context.Breeds.ToList())
            {
                ID = pet.ID,
                Name = pet.Name,
                Birthday = pet.Birthday,
                Color = pet.Color,
                Weight = pet.Weight,
                Gender = pet.Gender,
                BreedName = pet.BreedName,
                Microchipped = pet.Microchipped,
                Fixed = pet.Fixed,
                ExistingPhotoPath = pet.PhotoPath
                
            };
            return View(editProfileViewModel);
        }

        [HttpPost]
        public IActionResult EditProfile(EditProfileViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                
               
                Pet pet = context.Pets.Find(model.ID);
                pet.Name = model.Name;
                pet.Birthday = model.Birthday;
                pet.Color = model.Color;
                pet.Weight = model.Weight;
                pet.Gender = model.Gender;
                pet.BreedName = model.BreedName;
                pet.Microchipped = model.Microchipped;
                pet.Fixed = model.Fixed;
                pet.PhotoPath = model.ExistingPhotoPath;

                if (model.Photo != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath,
                            "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    pet.PhotoPath = ProcessUploadedFile(model);

                }

                

                context.Update(pet);
                context.SaveChanges();
                return RedirectToAction("index");
            }
            return View(model);
        }

        private string ProcessUploadedFile(AddPetViewModel model)
        {
            string uniqueFileName = null;

            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
        public async Task<IActionResult> Delete(int id)
        {
            var pet = await context.Pets.FindAsync(id);
            context.Pets.Remove(pet);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");

        }
    }
}