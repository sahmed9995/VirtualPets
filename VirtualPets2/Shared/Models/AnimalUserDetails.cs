using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPets2.Shared.Models
{
    //Model used to access animal details
    public class AnimalUserDetails
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Name { get; set; }
        public int? FoodId { get; set; }
        public int? ServiceId { get; set; }
        public string Type { get; set; }
        public string Dwelling { get; set; }
        public Food Diet { get; set; }
        
    }
}
