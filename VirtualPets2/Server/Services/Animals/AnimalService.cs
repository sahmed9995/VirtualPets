using Microsoft.EntityFrameworkCore;
using VirtualPets2.Server.Data;
using VirtualPets2.Server.Services.Users;
using VirtualPets2.Shared.Models;
using VirtualPets2.Server.Models;

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

            if (animal.Price > user.Money)
            {
                return false;
            }
            else
            {
                user.Money -= animal.Price;

                var aniUser = new UserAnimal
                {
                    UserId = user.Id,
                    AnimalId = animal.Id
                };

                await _context.UserAnimals.AddAsync(aniUser);
                var numberOfChanges = await _context.SaveChangesAsync();
                return numberOfChanges == 1;
            }
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


    }
}
