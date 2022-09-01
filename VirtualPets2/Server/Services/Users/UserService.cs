using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VirtualPets2.Client.Pages.Animals;
using VirtualPets2.Server.Data;
using VirtualPets2.Server.Models;
using VirtualPets2.Shared.Models;


namespace VirtualPets2.Server.Services.Users
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        private string _userId;

        public void SetUserId(string userId) => _userId = userId;

        public async Task<bool> RegisterUserAsync(UserCreate model)
        {

            var entity = new UserEntity
            {
                UserId = _userId,
                Username = model.Username,
                Password = model.Password,
                Nickname = model.Nickname,
                Money = 650.54,
            };

            var passwordHasher = new PasswordHasher<UserEntity>();
            entity.Password = passwordHasher.HashPassword(entity, model.Password);

            _context.Users.Add(entity);
            var numberOfChanges = await _context.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        public async Task<UserDetails> GetUserAsync()
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == _userId);
            if (user is null) return null;
            var details = new UserDetails
            {
                Id = user.Id,
                Username = user.Username,
                Nickname = user.Nickname,
                Money = user.Money
            };
            return details;
        }

        public async Task<List<AnimalUserDetails>> ShowAnimalsbyUserIdAsync(int userId)
        {
            List<AnimalEntity> animalList = new List<AnimalEntity>();

            var animals = await _context.UserAnimals
                .Where(u => u.UserId == userId).ToListAsync();

            if (animals != null)
            {
                foreach (var animal in animals)
                {
                    var details = await _context.Animals
                    .FirstOrDefaultAsync(a => a.Id == animal.AnimalId);

                    animalList.Add(details);
                }
                var userAnimals = animalList
                    .Select(a => new AnimalUserDetails
                    {
                        Id = a.Id,
                        FoodId = a.FoodId,
                        Title = a.Title,
                        Name = a.Name,
                        Type = a.Type,
                        Dwelling = a.Dwelling,
                        Diet = (Food)a.Diet
                    });
                return userAnimals.ToList();
            }
            return null;
        }

        public async Task<List<FoodUserDetails>> ShowFoodsbyUserIdAsync(int userId)
        {
            List<FoodEntity> foodList = new List<FoodEntity>();

            var foods = await _context.UserFoods
                .Where(u => u.UserId == userId).ToListAsync();

            if (foods != null)
            {
                foreach (var food in foods)
                {
                    var details = await _context.Foods
                    .FirstOrDefaultAsync(a => a.Id == food.FoodId);

                    foodList.Add(details);
                }
                var userFoods = foodList
                    .Select(a => new FoodUserDetails
                    { 
                        Id = a.Id,
                        Name = a.Name,
                        Type = (Kind)a.Type,
                    });
                return userFoods.ToList();
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> DeleteFoodFromUser(int animalId)
        {
            var animal = await _context.Animals
                .FindAsync(animalId);

            if (animal == null) return false;

            var food = await _context.UserFoods
                .FirstOrDefaultAsync(f => f.FoodId == animal.FoodId);

            if (food == null) return false;

            _context.UserFoods.Remove(food);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> UpdateUserAsync(UserEdit model)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == _userId);

            if (model.Username == null)
            {
                return true;
            }
            else
            {
                user.Username = model.Username;
            }

            if (model.Password == null)
            {
                return true;
            }
            else
            {
                user.Password = model.Password;
            }

            if (model.Nickname == null)
            {
                return true;
            }
            else
            {
                user.Nickname = model.Nickname;
            }

            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

    }
}
