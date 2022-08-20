using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualPets2.Server.Models
{
    public class AnimalEntity
    {
        public int Id { get; set; }

        public int? UserId { get; set; }
        public virtual UserEntity User { get; set; }

        public string Title { get; set; }
        public string? Name { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public string Dwelling { get; set; }
        public int Diet { get; set; }

        public virtual ICollection<UserAnimal> UserAnimals { get; set; }
    }
}