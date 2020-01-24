using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeeSpot.Models
{
    public class Breed
    {
        
            public int ID { get; set; }
            public string Name { get; set; }

            public IList<Pet> Pets { get; set; }

        
    }
}
