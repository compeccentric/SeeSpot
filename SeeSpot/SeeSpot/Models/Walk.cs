using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeeSpot.Models
{
    public class Walk
    {
        public int ID { get; set; }
        public int Distance { get; set; }
        public bool Poop { get; set; }
        public bool Pee { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string Notes { get; set; }

        public virtual Pet Pets { get; set; }
        
    }
}
