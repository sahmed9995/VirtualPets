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


        [HttpGet]
        public async Task<List<FoodDetails>> Index()
        {
            var foods = await _service.GetAllFoodsAsync();
            return foods.ToList();
        }

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


    }
}
