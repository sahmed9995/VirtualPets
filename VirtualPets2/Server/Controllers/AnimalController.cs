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

        //Gets brief details about all the animals in the Animals table
        [HttpGet]
        public async Task<List<AnimalListItem>> Index()
        {
            var animals = await _service.GetAllAnimalsAsync();
            return animals.ToList();
        }

        //Gets all the details of all the animals
        [HttpGet("details")]
        public async Task<List<AnimalDetails>> GetAnimalDetails()
        {
            var animals = await _service.GetAllAnimalDetailsAsync();
            return animals.ToList();
        }

        //Gets all the details of a specific animal using the animalId
        [HttpGet("{id}")]
        public async Task<AnimalDetails> Details(int id)
        {
            var animal = await _service.GetAnimalAsync(id);
            return animal;
        }

        //Creates a new UserAnimalEntity using the animalId and userId when buying an animal
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

        //Updates UserEntity Money by subtracting AnimalEntity Price from it when buying an animal by using the userId and animalId
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

        //Updates animal name in the UserAnimal table
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

        //Gets the names of all the animals in the UserAnimal table using the user Id
        [HttpGet("{userId}/names")]
        public async Task<List<AnimalEdit>> UserAnimalName(int userId)
        {
            var animalNames = await _service.GetAnimalNames(userId);
            return animalNames.ToList();
        }


        //Gets all the animal Ids in the UserAnimal table to get the AnimalEntity details using the userId
        [HttpGet("{userId}/Ids")]
        public async Task<List<UserAnimalDetails>> UserAnimalId(int userId)
        {
            var animalIds = await _service.GetAnimalIds(userId);
            return animalIds.ToList();
        }

        //Updates User Money when you feed a carnivorous animal meat using the userId
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

        //Updates User Money when you feed a herbivorous animal plants using the userId
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

        //Updates User Money when you feed an animal dessert using the userId
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

        //Updates User Money when you feed a herbivorous animal meat using the userId
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

        //Updates User Money when you feed a carnivorous animal plants using the userId
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

        //Updates AnimalEntity FoodId when you feed an animal using the animalId and foodId
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

        //Updates AnimalEntity ServiceId when you take care of your pet using the animalId and the serivce Id
        [HttpPut("{animalId}/serviceId")]
        public async Task<IActionResult> ChangeAnimalServiceId(int animalId, AnimalServiceEdit model)
        {

            bool wasUpdated = await _service.ChangeAnimalSerivceId(animalId, model);

            if (wasUpdated) return Ok();
            else
            {
                return BadRequest(0);
            }
        }
    }
}
