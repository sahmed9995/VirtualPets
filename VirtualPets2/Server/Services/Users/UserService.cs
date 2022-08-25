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
                        Name = a.Name,
                        Type = (Kind)a.Type,
                    });
                return userFoods.ToList();
            }
            return null;
        }

        //public async Task<IEnumerable<FoodUserDetails>> ShowFoodsbyUserIdAsync(int userId)
        //{
        //    var user = await _context.Users

        //        // Using .Include LINQ function to include virtual student table from CourseEntity
        //        .Include(entity => entity.foods)

        //        // .FirstorDefaultAsync LINQ function can be used to find any property and it only finds the first entity and cannot call multiple entites and cannot be added to a list, it cannot be used with bool task, it can be used after other LINQ functions but not before
        //        .FirstOrDefaultAsync(entity => entity.Id == userId);

        //    /* if (user == null)
        //         return null;*/

        //    // Returns list of each student's details in the course
        //    return user.foods
        //        .Select(e => new FoodUserDetails
        //        {
        //            Name = e.Name,
        //            Type = (Kind)e.Type,
        //        }).ToList();
        //}

        public async Task<bool> UpdateUserAsync(UserEdit model)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == _userId);

            if (model.Username == null)
            {
                user.Username = user.Username;
            }
            else
            {
                user.Username = model.Username;
            }

            if (model.Password == null)
            {
                user.Password = user.Password;
            }
            else
            {
                user.Password = model.Password;
            }

            if (model.Nickname == null)
            {
                user.Nickname = user.Nickname;
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
