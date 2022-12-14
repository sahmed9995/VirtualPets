using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VirtualPets2.Server.Services.Users;
using VirtualPets2.Shared.Models;

namespace VirtualPets2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        private string GetUserId()
        {
            string userIdClaim = User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value;
            if (userIdClaim == null) return null;
            return userIdClaim;
        }

        private bool SetUserIdInService()
        {
            var userId = GetUserId();
            if (userId == null) return false;
            _service.SetUserId(userId);
            return true;
        }

        //Gets User details for Index page
        [HttpGet]
        public async Task<UserDetails> Index()
        {
            if (!SetUserIdInService()) return new UserDetails();
            var user = await _service.GetUserAsync();
            return user;
        }

        //Gets animals in UserAnimal table using userId
        [HttpGet("{userId}/animals")]
        public async Task<List<AnimalUserDetails>> UserAnimal(int userId)
        { 
            if (!SetUserIdInService()) return new List<AnimalUserDetails>();
            var animals = await _service.ShowAnimalsbyUserIdAsync(userId);
            return animals.ToList();
        }

        //Gets foods in UserFood table using userId
        [HttpGet("{id}/foods")]
        public async Task<IEnumerable<FoodUserDetails>> Foods(int id)
        {
            if (!SetUserIdInService()) return new List<FoodUserDetails>();

            var foods = await _service.ShowFoodsbyUserIdAsync(id);
            return foods.ToList();
        }

        //Creates a new user
        [HttpPost]
        public async Task <IActionResult> Create(UserCreate model)
        {
            if (!SetUserIdInService()) return Unauthorized();

            bool wasCreated = await _service.RegisterUserAsync(model);

            if (wasCreated) return Ok();
            else
            {
                return UnprocessableEntity();
            }
        }

        //Updates user details
        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id, UserEdit model)
        {
            if (!SetUserIdInService()) return Unauthorized();

            bool wasUpdated = await _service.UpdateUserAsync(model);
            if (wasUpdated) return Ok();
            else
            {
                return BadRequest(0);
            }
        }

        //Deletes food from UserFood table using foodId
        [HttpDelete("{foodId}")]
        public async Task<IActionResult> Delete(int foodId)
        {
            bool deleted = await _service.DeleteFoodFromUser(foodId);

            if (deleted) return Ok();
            else
            {
                return BadRequest();
            }
        }
    }
}
