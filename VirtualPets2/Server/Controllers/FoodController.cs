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


    }
}
