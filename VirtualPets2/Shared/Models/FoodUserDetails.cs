using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPets2.Shared.Models
{
    //Model used to get FoodEntity details for the user to see
    public class FoodUserDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Kind Type { get; set; }
    }

   
}
