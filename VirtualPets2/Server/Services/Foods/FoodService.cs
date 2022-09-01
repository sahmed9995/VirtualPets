using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VirtualPets2.Server.Data;
using VirtualPets2.Server.Models;
using VirtualPets2.Shared.Models;

namespace VirtualPets2.Server.Services.Foods
{
    public class FoodService : IFoodService
    {
        private readonly ApplicationDbContext _context;
        public FoodService(ApplicationDbContext context)
        {
            _context = context;
        }

        //Method to show all foods in the Foods table
        public async Task<List<FoodDetails>> GetAllFoodsAsync()
        {
            var foods = _context.Foods
                .Select(f => new FoodDetails
                {
                    Id = f.Id,
                    Name = f.Name,
                    Type = (Kind)f.Type,
                    Price = f.Price
                });
            return await foods.ToListAsync();
        }

        //Method to create a new FoodEntity
        public async Task<bool> CreateFoodAsync(FoodCreate model)
        {

            var entity = new FoodEntity
            {
                Name = model.Name,
                Type = (int)model.Type,
                Price = model.Price
            };

            _context.Foods.Add(entity);
            var numberOfChanges = await _context.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        //Method to add foodId and userId to UserFood table
        public async Task<bool> BuyFood(int userId, int foodId, UserFoodCreate model)
        {
            var food = await _context.Foods
                .FirstOrDefaultAsync(f => f.Id == foodId);

            if (food == null) return false;

            var user = await _context.Users
                .FirstOrDefaultAsync(a => a.Id == userId);

            if (user == null) return false;

            var userFood = new UserFood
            {
                UserId = user.Id,
                FoodId = food.Id,
            };

            _context.UserFoods.Add(userFood);
            return await _context.SaveChangesAsync() == 1;
        }

        //Method to subtract AnimalEntity Price from UserEntity Money when buying an animal
        public async Task<bool> ChangeMoneyFood(int foodId, int userId, UserMoney model)
        {
            var food = await _context.Foods
                .FirstOrDefaultAsync(f => f.Id == foodId);

            if (food == null) return false;

            var user = await _context.Users
                .FirstOrDefaultAsync(a => a.Id == userId);

            if (user == null) return false;

            var money = user.Money - food.Price;

            user.Money = money;

            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        //Method to get food details from Animal foodId to have correct money adjustment and show the correct modal
        public async Task<FoodDetails> GetFoodDetails(int animalId)
        {
            var animal = await _context.Animals
                .FirstOrDefaultAsync(a => a.Id == animalId);

            if (animal == null) return null;

            var food = await _context.Foods
                .FirstOrDefaultAsync(f => f.Id == animal.FoodId);

            if (food == null) return null;

            var foodDetails = new FoodDetails
            {
                Id = food.Id,
                Name = food.Name,
                Type = (Kind)food.Type,
                Price = food.Price
            };
            return foodDetails;
        }
    }
}
