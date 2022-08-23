namespace VirtualPets2.Server.Models
{
    public class UserAnimal
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AnimalId { get; set; }
        public string Name { get; set; }


        public UserEntity User { get; set; }
        public AnimalEntity Animal { get; set; }
    }
}
