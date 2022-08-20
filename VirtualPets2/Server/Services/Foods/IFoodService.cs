using VirtualPets2.Shared.Models;

namespace VirtualPets2.Server.Services.Foods
{
    public interface IFoodService
    {
        Task<List<FoodDetails>> GetAllFoodsAsync();
        Task<bool> CreateFoodAsync(FoodCreate model);
    }
}
