namespace VirtualPets2.Server.Models
{
    public class FoodEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public int Price { get; set; }

        public ICollection<UserFood> UserFoods { get; set; }
    }
    

   
}

