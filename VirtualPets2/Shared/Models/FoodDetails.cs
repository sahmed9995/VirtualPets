using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPets2.Shared.Models
{
    //Model used to see FoodEntity details at the shop
    public class FoodDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Kind Type { get; set; }
        public int Price { get; set; }
    }
}
