using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPets2.Shared.Models
{
    //Model used to add data to UserEntity table in database
    public class UserCreate
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
    }

}
