using SeeSpot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeeSpot.ViewModels
{
    public class ProfileViewModel : AddPetViewModel
    {
        public Pet Pet { get; set; }
        public int ID { get; set; }
        public string ExistingPhotoPath { get; set; }
        public string Breed { get; set; }
        
    }
}
