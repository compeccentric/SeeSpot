﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SeeSpot.Data;
using SeeSpot.Models;
using SeeSpot.ViewModels;

namespace SeeSpot.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BreedController : Controller
    {
        
        public IActionResult Index()
        {
            List<Breed> breeds;
            breeds = context.Breeds.ToList();
            return View(breeds);
        }

        private readonly Data.SeeSpotDbContext context;

        public BreedController(SeeSpotDbContext dbContext)
        {
            context = dbContext;
        }



        public IActionResult Add()
        {
            AddBreedViewModel addBreedViewModel = new AddBreedViewModel();
            return View(addBreedViewModel);

        }
        [HttpPost]
        public IActionResult Add(AddBreedViewModel addBreedViewModel)
        {
            if (ModelState.IsValid)
            {
                // Add the new cheese to my existing cheeses
                Breed newBreed = new Breed
                {
                    Name = addBreedViewModel.Name,
                };

                context.Breeds.Add(newBreed);
                context.SaveChanges();

                return Redirect("/Breed");
            }

            return View(addBreedViewModel);
        }
        public IActionResult Delete()
        {
            List<Breed> breeds = context.Breeds.ToList();
            return View(breeds);
        }

        [HttpPost]
        public IActionResult Delete(int[] categoryIds)
        {
            foreach (int categoryId in categoryIds)
            {
                Breed theBreed = context.Breeds.Single(c => c.ID == categoryId);
                context.Breeds.Remove(theBreed);
            }
            context.SaveChanges();
            return Redirect("/Breed");
        }
    }
}