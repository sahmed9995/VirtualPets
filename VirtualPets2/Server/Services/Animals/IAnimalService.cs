using VirtualPets2.Shared.Models;

namespace VirtualPets2.Server.Services.Animals
{
    public interface IAnimalService
    {
        Task<List<AnimalListItem>> GetAllAnimalsAsync();
        Task<List<AnimalDetails>> GetAllAnimalDetailsAsync();
        Task<AnimalDetails> GetAnimalAsync(int id);
        Task<bool> BuyAnimal(int userId, int animalId, UserAnimalCreate model);
        Task<bool> ChangeMoneyToBuyAnimal(int animalId, int userId, UserMoney model);
        Task<bool> ChangeAnimalName(int animalId, AnimalEdit model);
        Task<List<AnimalEdit>> GetAnimalNames(int userId);
        Task<List<UserAnimalDetails>> GetAnimalIds(int userId);
        Task<bool> ChangeMoneyToFeedAnimal(int userId, UserMoney model);
        Task<bool> ChangeMoneyToFeedPlantAnimal(int userId, UserMoney model);
        Task<bool> ChangeMoneyToFeedMeatAnimal(int userId, UserMoney model);
        Task<bool> ChangeAnimalFoodId(int animalId, AnimalFoodEdit model);
        Task<bool> LoseMoneyToFeedAnimalMeat(int userId, UserMoney model);
        Task<bool> LoseMoneyToFeedAnimalPlants(int userId, UserMoney model);
        Task<bool> ChangeAnimalSerivceId(int animalId, AnimalServiceEdit model);
    }
}
