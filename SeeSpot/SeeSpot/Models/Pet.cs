using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeeSpot.Models
{
    public class Pet
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public DateTime Birthday { get; set; }
        public bool Fixed { get; set; }
        public string Color { get; set; }
        public string Breed { get; set; }
        public string Photo { get; set; }
    }
}
