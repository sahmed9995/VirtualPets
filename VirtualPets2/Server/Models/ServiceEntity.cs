namespace VirtualPets2.Server.Models
{
    public class ServiceEntity
    {
        public int Id { get; set; }
        public UserEntity User { get; set; }
        public string Task { get; set; }
        public double Money { get; set; }
    }
}
