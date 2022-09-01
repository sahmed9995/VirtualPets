using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtualPets2.Server.Services.Services;
using VirtualPets2.Server.Services.Users;
using VirtualPets2.Shared.Models;

namespace VirtualPets2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepository _service;
        public ServiceController(IServiceRepository service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<ServiceDetails>> GetAllServices()
        {
            var services = await _service.GetAllTasks();
            return services.ToList();
        }

        [HttpPut("{animalId}/user/{userId}")]
        public async Task<IActionResult> AddMoney(int userId, int animalId, UserMoney model)
        {
            bool changed = await _service.ChangeMoney(userId, animalId, model);
            if (changed)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{animalId}")]
        public async Task<AnimalServiceEdit> GetAnimalServiceId(int animalId)
        {
            var serviceId = await _service.GetServiceId(animalId);
            return serviceId;
        }
    }
}
