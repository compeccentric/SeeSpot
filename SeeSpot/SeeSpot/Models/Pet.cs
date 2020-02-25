using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeeSpot.Models
{
    public class Pet
    {
        public int ID { get; set; }
        public string OwnerId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Weight { get; set; }
        public DateTime Birthday { get; set; }
        public string Fixed { get; set; }
        public string Microchipped { get; set; }
        public string Color { get; set; }
        public Breed Breed { get; set; }
        public string BreedName { get; set; }
        public string PhotoPath { get; set; }
        

        public virtual ICollection<Walk> Walks { get; set; }
    }

    
}
