using VirtualPets2.Shared.Models;

namespace VirtualPets2.Server.Services.Users
{
    public interface IUserService
    {
        void SetUserId(string userId);
        Task<bool> RegisterUserAsync(UserCreate model);
        Task<UserDetails> GetUserAsync();
        Task<IEnumerable<AnimalUserDetails>> ShowAnimalsbyUserIdAsync(int userId);
        //Task<IEnumerable<FoodUserDetails>> ShowFoodsbyUserIdAsync(int userId);
        Task<bool> UpdateUserAsync(UserEdit model);
    }
}
