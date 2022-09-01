using VirtualPets2.Shared.Models;

namespace VirtualPets2.Server.Services.Services
{
    public interface IServiceRepository
    {
        Task<List<ServiceDetails>> GetAllTasks();
        Task<bool> ChangeMoney(int userId, int animalId, UserMoney model);
        Task<AnimalServiceEdit> GetServiceId(int animalId);
    }
}
