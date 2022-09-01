using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPets2.Shared.Models
{
    //Model to add data to UserFood Table in database
    public class UserFoodCreate
    {
        public int UserId { get; set; }
        public int FoodId { get; set; }
    }
}
