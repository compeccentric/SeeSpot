using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeeSpot.ViewModels
{
    public class AddBreedViewModel
	{
		[Required]
		[Display(Name = "Breed")]
		public string Name { get; set; }
	}
}

