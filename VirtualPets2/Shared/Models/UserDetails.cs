using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPets2.Shared.Models
{
    public class UserDetails
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Nickname { get; set; }
        public double Money { get; set; }
    }
}
