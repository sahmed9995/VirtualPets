using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtualPets2.Server.Services.Foods;
using VirtualPets2.Server.Services.Users;
using VirtualPets2.Shared.Models;

namespace VirtualPets2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _service;
        public FoodController(IFoodService service)
        {
            _service = service;
        }

        //Gets all the foods for the index page
        [HttpGet]
        public async Task<List<FoodDetails>> Index()
        {
            var foods = await _service.GetAllFoodsAsync();
            return foods.ToList();
        }

        //Creates a new food
        [HttpPost]
        public async Task<IActionResult> Create(FoodCreate model)
        {
            bool wasCreated = await _service.CreateFoodAsync(model);

            if (wasCreated) return Ok();
            else
            {
                return UnprocessableEntity();
            }
        }

        //Creates a new UserFoodEntity using a foodId and userId when you buy a food
        [HttpPost("{foodId}/buy/{userId}")]
        public async Task<IActionResult> AddFoodToUser(int userId, int foodId, UserFoodCreate model)
        {
            bool newFood = await _service.BuyFood(userId, foodId, model);

            if (newFood) return Ok();
            else
            {
                return UnprocessableEntity();
            }
        }

        //Updates UserEntity Money by subtracting FoodEntity Price from it when you buy a food using the userId and the food Id
        [HttpPut("{userId}/buy/{foodId}")]
        public async Task<IActionResult> ChangeUserMoney(int foodId, int userId, UserMoney model)
        {
            bool wasUpdated = await _service.ChangeMoneyFood(foodId, userId, model);

            if (wasUpdated) return Ok();
            else
            {
                return BadRequest(0);
            }
        }

        //Gets the details about FoodEntity from the AnimalEntity FoodId
        [HttpGet("{animalId}/details")]
        public async Task<FoodDetails> GetFoodDetails(int animalId)
        {
            var food = await _service.GetFoodDetails(animalId);
            return food;
        }


    }
}
