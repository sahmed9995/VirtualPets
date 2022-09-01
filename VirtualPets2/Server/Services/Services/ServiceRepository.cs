using Microsoft.EntityFrameworkCore;
using VirtualPets2.Server.Data;
using VirtualPets2.Shared.Models;

namespace VirtualPets2.Server.Services.Services
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ApplicationDbContext _context;
        public ServiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //Method to get all services in the Service table
        public async Task<List<ServiceDetails>> GetAllTasks()
        {
            var services = _context.Services
                .Select(s => new ServiceDetails
                {
                    Id = s.Id,
                    Task = s.Task,
                    Money = s.Money
                });
            return await services.ToListAsync();
        }

        //Method to adjust UserEntity Money based on which task the user chose
        public async Task<bool> ChangeMoney(int userId, int animalId, UserMoney model)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(a => a.Id == userId);

            if (user == null) return false;

            var animal = await _context.Animals
                .FindAsync(animalId);

            if (animal == null) return false;

            var service = await _context.Services
                .FirstOrDefaultAsync(s => s.Id == animal.ServiceId);
            if (service == null) return false;

            user.Money += service.Money;

            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        //Method to get service Id from AnimalEntity to show correct modal
        public async Task<AnimalServiceEdit> GetServiceId(int animalId)
        {
            var animal = await _context.Animals
                .FindAsync(animalId);

            var serviceId = new AnimalServiceEdit
            {
                ServiceId = (int)animal.ServiceId
            };

            if (serviceId == null) return null;

            return serviceId;

        }
    }
}
