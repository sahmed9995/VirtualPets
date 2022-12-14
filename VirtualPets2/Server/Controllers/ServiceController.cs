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

        //Gets all services in the Services table
        [HttpGet]
        public async Task<List<ServiceDetails>> GetAllServices()
        {
            var services = await _service.GetAllTasks();
            return services.ToList();
        }

        //Updates UserEntity Money by adding ServiceEntity Money to it by using the userId to access the money and then using the animalId to find the ServiceId
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

        //Gets the AnimalEntity ServiceId using the animaId
        [HttpGet("{animalId}")]
        public async Task<AnimalServiceEdit> GetAnimalServiceId(int animalId)
        {
            var serviceId = await _service.GetServiceId(animalId);
            return serviceId;
        }
    }
}
