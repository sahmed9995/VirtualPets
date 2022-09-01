using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPets2.Shared.Models
{
    //Model used to get ServiceEntity details
    public class ServiceDetails
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public int Money { get; set; }
    }
}
