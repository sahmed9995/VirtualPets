using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPets2.Shared.Models
{
    public class AnimalDetails
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public string Dwelling { get; set; }
        public Food Diet { get; set; }
        public double Price { get; set; }
    }

    public enum Food
    {
        Carnivore,
        Herbivore
    }
}
