using Microsoft.EntityFrameworkCore;
using VirtualPets2.Server.Data;
using VirtualPets2.Server.Services.Users;
using VirtualPets2.Shared.Models;
using VirtualPets2.Server.Models;
using VirtualPets2.Client.Pages.User;

namespace VirtualPets2.Server.Services.Animals
{
    public class AnimalService : IAnimalService
    {
        private readonly ApplicationDbContext _context;
        public AnimalService(ApplicationDbContext context)
        {
            _context = context;
        }

        //Method to show all animals in the agency
        public async Task<List<AnimalListItem>> GetAllAnimalsAsync()
        {
            var animals = _context.Animals
                .Select(a => new AnimalListItem
                {
                    Id = a.Id,
                    Title = a.Title,
                    Price = a.Price,
                    Type = a.Type
                });
            return await animals.ToListAsync();
        }

        //Method to get the details of all the animals 
        public async Task<List<AnimalDetails>> GetAllAnimalDetailsAsync()
        {
            var animals = _context.Animals
                .Select(a => new AnimalDetails
                {
                    Title = a.Title,
                    Price = a.Price,
                    Type = a.Type,
                    Dwelling = a.Dwelling,
                    Diet = (Food)a.Diet
                });
            return await animals.ToListAsync();
        }

        //Method to get the details of a specific animal
        public async Task<AnimalDetails> GetAnimalAsync(int id)
        {
            var animal = await _context.Animals
                .FirstOrDefaultAsync(a => a.Id == id);
            if (animal == null) return null;

            var details = new AnimalDetails
            {
                Title = animal.Title,
                Type = animal.Type,
                Dwelling = animal.Dwelling,
                Diet = (Food)animal.Diet,
                Price = animal.Price
            };
            return details;

        }

        //Method to add animalId and userId to UserAnimal table when buying an animal
        public async Task<bool> BuyAnimal(int userId, int animalId, UserAnimalCreate model)
        {
            var animal = await _context.Animals
                .FirstOrDefaultAsync(a => a.Id == animalId);

            if (animal == null) return false;

            var user = await _context.Users
                .FirstOrDefaultAsync(a => a.Id == userId);

            if (user == null) return false;

            var aniUser = new UserAnimal
            {
                UserId = user.Id,
                AnimalId = animal.Id,
            };

            _context.UserAnimals.Add(aniUser);
            return await _context.SaveChangesAsync() == 1;
        }

        //Method to subtract AnimalEntity Price from UserEntity Money when buying an animal
        public async Task<bool> ChangeMoneyToBuyAnimal(int animalId, int userId, UserMoney model)
        {
            var animal = await _context.Animals
                .FirstOrDefaultAsync(a => a.Id == animalId);

            if (animal == null) return false;

            var user = await _context.Users
                .FirstOrDefaultAsync(a => a.Id == userId);

            if (user == null) return false;

            var money = user.Money - animal.Price;

            user.Money = money;

            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        //Method to change name of animal in the UserAnimal Table
        public async Task<bool> ChangeAnimalName(int animalId, AnimalEdit model)
        {
            var animal = await _context.UserAnimals
                .FirstOrDefaultAsync(u => u.AnimalId == animalId);

            animal.Name = model.Name;

            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;

        }

        //Method to get all the animal names in the UserAnimal table
        public async Task<List<AnimalEdit>> GetAnimalNames(int userId)
        {
            var animalNames = _context.UserAnimals
                .Where(u => u.UserId == userId)
                .Select(u => new AnimalEdit
                {
                    Name = u.Name
                });
            return await animalNames.ToListAsync();
        }

        //Method to get all the animal ids in the UserAnimal table
        public async Task<List<UserAnimalDetails>> GetAnimalIds(int userId)
        {
            var animalIds = _context.UserAnimals
                .Where(u => u.UserId == userId)
                .Select(u => new UserAnimalDetails
                {
                    AnimalId = u.AnimalId
                });
            return await animalIds.ToListAsync();

        }

        //Method to add 35 to UserEntity Money when you feed a carnivorous animal meat
        public async Task<bool> ChangeMoneyToFeedMeatAnimal(int userId, UserMoney model)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(a => a.Id == userId);

            if (user == null) return false;

            var money = user.Money + 35;

            user.Money = money;

            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        //Method to add 15 to UserEntity Money when you feed a herbivorous animal plants
        public async Task<bool> ChangeMoneyToFeedPlantAnimal(int userId, UserMoney model)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(a => a.Id == userId);

            if (user == null) return false;

            var money = user.Money + 15;

            user.Money = money;

            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        //Method to add 50 to UserEntity Money when the user feeds their pet dessert
        public async Task<bool> ChangeMoneyToFeedAnimal(int userId, UserMoney model)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(a => a.Id == userId);

            if (user == null) return false;

            var money = user.Money + 50;

            user.Money = money;

            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        //Method to subtract 35 from UserEntity Money when the user feed their herbivorous pet meat
        public async Task<bool> LoseMoneyToFeedAnimalMeat(int userId, UserMoney model)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(a => a.Id == userId);

            if (user == null) return false;

            var money = user.Money - 35;

            user.Money = money;

            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        //Method to subtract 50 from UserEntity Money when the user feed their carnivorous pet plants
        public async Task<bool> LoseMoneyToFeedAnimalPlants(int userId, UserMoney model)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(a => a.Id == userId);

            if (user == null) return false;

            var money = user.Money - 50;

            user.Money = money;

            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        //Method to feed pet by changing the AnimalEntity FoodId
        public async Task<bool> ChangeAnimalFoodId(int animalId, AnimalFoodEdit model)
        {
            var animal = await _context.Animals
                .FirstOrDefaultAsync(u => u.Id == animalId);

            if (animal == null) return false;

            if (animal.FoodId == model.FoodId)
            {
                return true;
            }
            else
            {
                animal.FoodId = model.FoodId;

                var numberOfChanges = await _context.SaveChangesAsync();
                return numberOfChanges == 1;
            }
        }

        //Method to take care of pet by changing AnimalEntity ServiceId
        public async Task<bool> ChangeAnimalSerivceId(int animalId, AnimalServiceEdit model)
        {
            var animal = await _context.Animals
                .FirstOrDefaultAsync(u => u.Id == animalId);

            if (animal == null) return false;

            if (animal.ServiceId == model.ServiceId)
            {
                return true;
            }
            else
            {
                animal.ServiceId = model.ServiceId;

                var numberOfChanges = await _context.SaveChangesAsync();
                return numberOfChanges == 1;
            }
        }
    }
}
