﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPets2.Shared.Models
{
    public class AnimalUserDetails
    {
        public string Title { get; set; }
        public string? Name { get; set; }
        public string Type { get; set; }
        public string Dwelling { get; set; }
        public Food Diet { get; set; }
        
    }
}