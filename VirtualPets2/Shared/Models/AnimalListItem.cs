using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPets2.Shared.Models
{
    //Model used to show brief description of animals
    public class AnimalListItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }
    }
}
