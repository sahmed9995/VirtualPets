using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtualPets2.Server.Services.Animals;
using VirtualPets2.Server.Services.Users;
using VirtualPets2.Shared.Models;

namespace VirtualPets2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalService _service;
        public AnimalController(IAnimalService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<AnimalListItem>> Index()
        {
            var animals = await _service.GetAllAnimalsAsync();
            return animals.ToList();
        }

        [HttpGet("{id}")]
        public async Task<AnimalDetails> Details(int id)
        {
            var animal = await _service.GetAnimalAsync(id);
            return animal;
        }

        [HttpGet("price")]
        public IActionResult Price()
        {
            return Redirect("price");
        }

        [HttpGet("price/{money}")]
        public async Task<List<AnimalListItem>> Price2(double money)
        {
            var animals = await _service.GetAllAnimalsByPriceAsync(money);
            return animals.ToList();
        }

        [HttpPost("{animalId}/buy/{userId}")]
        public async Task<IActionResult> AddAnimalToUser(int userId, int animalId, UserAnimalCreate model)
        {
            bool newPet = await _service.BuyAnimal(userId, animalId, model);

            if (newPet) return Ok();
            else
            {
                return UnprocessableEntity();
            }
        }

        [HttpPut("{userId}/buy/{animalId}")]
        public async Task<IActionResult> ChangeUserMoney(int animalId, int userId, UserMoney model)
        {

            bool wasUpdated = await _service.ChangeMoneyToBuyAnimal(animalId, userId, model);

            if (wasUpdated) return Ok();
            else
            {
                return BadRequest(0);
            }
        }

        [HttpPut("{animalId}/name")]
        public async Task<IActionResult> ChangeAnimalName(int animalId, AnimalEdit model)
        {

            bool wasUpdated = await _service.ChangeAnimalName(animalId, model);

            if (wasUpdated) return Ok();
            else
            {
                return BadRequest(0);
            }
        }

        [HttpGet("{userId}/names")]
        public async Task<List<AnimalEdit>> UserAnimalName(int userId)
        {
            var animalNames = await _service.GetAnimalNames(userId);
            return animalNames.ToList();
        }


        [HttpGet("{userId}/Ids")]
        public async Task<List<UserAnimalDetails>> UserAnimalId(int userId)
        {
            var animalIds = await _service.GetAnimalIds(userId);
            return animalIds.ToList();
        }

        [HttpPut("{userId}/meat")]
        public async Task<IActionResult> ChangeUserMoneyMeat(int userId, UserMoney model)
        {

            bool wasUpdated = await _service.ChangeMoneyToFeedMeatAnimal( userId, model);

            if (wasUpdated) return Ok();
            else
            {
                return BadRequest(0);
            }
        }

        [HttpPut("{userId}/plants")]
        public async Task<IActionResult> ChangeUserMoneyPlants(int userId, UserMoney model)
        {

            bool wasUpdated = await _service.ChangeMoneyToFeedPlantAnimal(userId, model);

            if (wasUpdated) return Ok();
            else
            {
                return BadRequest(0);
            }
        }

        [HttpPut("{userId}/dessert")]
        public async Task<IActionResult> ChangeUserMoneyDesserts(int userId, UserMoney model)
        {

            bool wasUpdated = await _service.ChangeMoneyToFeedAnimal(userId, model);

            if (wasUpdated) return Ok();
            else
            {
                return BadRequest(0);
            }
        }

        [HttpPut("{userId}/Notplants")]
        public async Task<IActionResult> LoseUserMoneyPlants(int userId, UserMoney model)
        {

            bool wasUpdated = await _service.LoseMoneyToFeedAnimalMeat(userId, model);

            if (wasUpdated) return Ok();
            else
            {
                return BadRequest(0);
            }
        }

        [HttpPut("{userId}/Notmeat")]
        public async Task<IActionResult> LoseUserMoneyMeat(int userId, UserMoney model)
        {

            bool wasUpdated = await _service.LoseMoneyToFeedAnimalPlants(userId, model);

            if (wasUpdated) return Ok();
            else
            {
                return BadRequest(0);
            }
        }

        [HttpPut("{animalId}/foodId")]
        public async Task<IActionResult> ChangeAnimalFoodId(int animalId, AnimalFoodEdit model)
        {

            bool wasUpdated = await _service.ChangeAnimalFoodId(animalId, model);

            if (wasUpdated) return Ok();
            else
            {
                return BadRequest(0);
            }
        }
    }
}
