﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using SeeSpot.Models;

namespace SeeSpot.ViewModels
{
    public class AddPetViewModel
    {
        [Required]
        [Display(Name = "Pet Name")]
        public string Name { get; set; }
        public string OwnerId { get; set; }

        [Required(ErrorMessage = "You must give your pet a Name")]
        public string Gender { get; set; }
        public int Weight { get; set; }

        [Required]
        [Display(Name = "Breed")]
        public string BreedName { get; set; }

        public List<SelectListItem> Breeds { get; set; }


        public AddPetViewModel(IEnumerable<Breed> breeds)
        {

            Breeds = new List<SelectListItem>();

            foreach (Breed breed in breeds)
            {
                Breeds.Add(new SelectListItem
                {
                    Value = breed.Name.ToString(),
                    Text = breed.Name.ToString()
                });


            }

        }
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        public string Fixed { get; set; }
        public string Microchipped { get; set; }
        public string Color { get; set; }
        public IFormFile Photo { get; set; }
        
        public AddPetViewModel() { }
    }
}
