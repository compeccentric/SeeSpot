using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using SeeSpot.Models;

namespace SeeSpot.ViewModels
{
    public class EditProfileViewModel : AddPetViewModel
    {
        public EditProfileViewModel() { }
        public int ID { get; set; }
        public string ExistingPhotoPath { get; set; }

        public List<SelectListItem> Breeds { get; set; }


        public EditProfileViewModel(IEnumerable<Breed> breeds)
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

        
    }
}
