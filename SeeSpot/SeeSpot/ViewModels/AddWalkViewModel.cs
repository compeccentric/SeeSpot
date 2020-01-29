using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeeSpot.ViewModels
{
    public class AddWalkViewModel
    {
        
        public int Distance { get; set; }
        public bool Poop { get; set; }
        public bool Pee { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }
        [StringLength(250)]
        public string Notes { get; set; }
        

        public AddWalkViewModel() { }
    }
}

    

