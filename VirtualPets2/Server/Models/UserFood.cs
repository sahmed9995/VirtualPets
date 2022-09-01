namespace VirtualPets2.Server.Models
{
    // UserFood Joining Table
    public class UserFood
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FoodId { get; set; }

        public virtual UserEntity User { get; set; }
        public virtual FoodEntity Food { get; set; }
    }
}
