﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VirtualPets2.Server.Data;
using VirtualPets2.Server.Models;
using VirtualPets2.Shared.Models;

namespace VirtualPets2.Server.Services.Foods
{
    public class FoodService : IFoodService
    {
        private readonly ApplicationDbContext _context;
        public FoodService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<FoodDetails>> GetAllFoodsAsync()
        {
            var foods = _context.Foods
                .Select(f => new FoodDetails
                {
                    Id = f.Id,
                    Name = f.Name,
                    Type = (Kind)f.Type,
                    Price = f.Price
                });
            return await foods.ToListAsync();
        }

        public async Task<bool> CreateFoodAsync(FoodCreate model)
        {

            var entity = new FoodEntity
            {
                Name = model.Name,
                Type = (int)model.Type,
                Price = model.Price
            };

            _context.Foods.Add(entity);
            var numberOfChanges = await _context.SaveChangesAsync();

            return numberOfChanges == 1;
        }
        //public async Task<bool> BuyFood(int foodId)
        //{
        //    var user = await _context.Users
        //        .Include(user => user.foods)
        //        .FirstOrDefaultAsync();

        //    var food = await _context.Animals
        //        .Where(entity => entity.Id == foodId)
        //        .FirstOrDefaultAsync();
        //    if (food == null)
        //        return false;

        //    if (food.Price > user.Money)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        user.Money -= food.Price;

        //        user.animals.Add(food);

        //        var numberOfChanges = await _context.SaveChangesAsync();
        //        return numberOfChanges == 1;
        //    }
        //}


    }
}