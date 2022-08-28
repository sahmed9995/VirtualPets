using VirtualPets2.Shared.Models;

namespace VirtualPets2.Server.Services.Foods
{
    public interface IFoodService
    {
        Task<List<FoodDetails>> GetAllFoodsAsync();
        Task<bool> CreateFoodAsync(FoodCreate model);
        Task<bool> BuyFood(int userId, int foodId, UserFoodCreate model);
        Task<bool> ChangeMoneyFood(int foodId, int userId, UserMoney model);
        Task<FoodDetails> GetFoodDetails(int animalId);
    }
}
