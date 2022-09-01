using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPets2.Shared.Models
{
    //Model used to create a new FoodEntity
    public class FoodCreate
    {
        public string Name { get; set; }
        public Kind Type { get; set; }
        public int Price { get; set; }
    }

    public enum Kind
    {
        Meat,
        Plants,
        Dessert
    }
}
