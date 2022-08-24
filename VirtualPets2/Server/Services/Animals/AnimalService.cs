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

        public async Task<List<AnimalListItem>> GetAllAnimalsByPriceAsync(double money)
        {
            var animals = _context.Animals
                .Where(a => a.Price <= money)
                .Select(a => new AnimalListItem
                {
                    Id = a.Id,
                    Title = a.Title,
                    Price = a.Price,
                    Type = a.Type
                });
            return await animals.ToListAsync();
        }

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

        public async Task<bool> ChangeMoney(int animalId, int userId, UserMoney model)
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

        public async Task<bool> ChangeAnimalName(int animalId, AnimalEdit model)
        {
            var animal = await _context.UserAnimals
                .FirstOrDefaultAsync(u => u.AnimalId == animalId);

            animal.Name = model.Name;

            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;

        }

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


        //    _context.UserAnimals.Add(new UserAnimal()
        //    {
        //        UserId = model.UserId,
        //        AnimalId = model.AnimalId
        //    })
        //    var user = await _context.Users
        //        .Include(user => user.animals)
        //        .FirstOrDefaultAsync();

        //    var animal = await _context.Animals
        //        .Where(entity => entity.Id == animalId)
        //        .FirstOrDefaultAsync();
        //    if (animal == null)
        //        return false;

        //    if (animal.Price > user.Money)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        user.Money -= animal.Price;

        //        user.animals.Add(animal);

        //        var numberOfChanges = await _context.SaveChangesAsync();
        //        return numberOfChanges == 1;
        //    }
        //}

        //private async Task<bool> CanUserBuyAnimal(int userId, int animalId)
        //{
        //    var animal = await _context.Animals
        //        .FirstOrDefaultAsync(a => a.Id == animalId);

        //    if (animal == null) return false;

        //    var user = await _context.Users
        //        .FirstOrDefaultAsync(a => a.Id == userId);

        //    if (user == null) return false;

        //    if (user.Money < animal.Price)
        //    {
        //        return false;
        //    }
        //    else
        //    {

        //        return true;
        //    }

        
    }
}
