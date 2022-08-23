using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPets2.Shared.Models
{
    public class UserAnimalCreate
    {
        public int UserId { get; set; }
        public int AnimalId { get; set; }
        public string Name { get; set; }
    }
}
