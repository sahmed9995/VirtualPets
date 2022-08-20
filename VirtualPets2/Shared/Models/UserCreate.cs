using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPets2.Shared.Models
{
    public class UserCreate
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
    }

}
