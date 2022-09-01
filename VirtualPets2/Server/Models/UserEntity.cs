
namespace VirtualPets2.Server.Models
{
    //User Table that contains user details
    public class UserEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public double Money { get; set; }
        public virtual ICollection<UserAnimal> UserAnimals { get; set; }
        public virtual ICollection<UserFood> UserFoods { get; set; }
    }
}
