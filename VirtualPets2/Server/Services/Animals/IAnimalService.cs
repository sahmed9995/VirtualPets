using VirtualPets2.Shared.Models;

namespace VirtualPets2.Server.Services.Animals
{
    public interface IAnimalService
    {
        Task<List<AnimalListItem>> GetAllAnimalsAsync();
        Task<AnimalDetails> GetAnimalAsync(int id);
        Task<List<AnimalListItem>> GetAllAnimalsByPriceAsync(double money);
        Task<bool> BuyAnimal(int userId, int animalId, UserAnimalCreate model);
    }
}
