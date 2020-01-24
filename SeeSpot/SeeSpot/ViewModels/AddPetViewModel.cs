using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using SeeSpot.Models;

namespace SeeSpot.ViewModels
{
    public class AddPetViewModel
    {
        [Required]
        [Display(Name = "Pet Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must give your pet a Name")]
        public int Weight { get; set; }

        [Required]
        [Display(Name = "Breed")]
        public int BreedID { get; set; }

        public List<SelectListItem> Breeds { get; set; }


        public AddPetViewModel(IEnumerable<Breed> breeds)
        {

            Breeds = new List<SelectListItem>();

            foreach (Breed breed in breeds)
            {
                Breeds.Add(new SelectListItem
                {
                    Value = breed.ID.ToString(),
                    Text = breed.Name.ToString()
                });


            }

        }
        public AddPetViewModel() { }
    }
}
