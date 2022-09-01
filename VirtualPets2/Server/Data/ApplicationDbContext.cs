using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using VirtualPets2.Server.Models;

namespace VirtualPets2.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        //Creating tables in database
        public DbSet<AnimalEntity> Animals { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<FoodEntity> Foods { get; set; }
        public DbSet<ServiceEntity> Services { get; set; }
        public DbSet<UserFood> UserFoods { get; set; }
        public DbSet<UserAnimal> UserAnimals { get; set; }

        
        //Seeding the database with animals, foods, and services
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AnimalEntity>()
                .HasData(
                new AnimalEntity { Id = 1, Title = "Lion", Type = "Feline", Price = 650.45, Dwelling = "Desert/Forest", Diet = 0 },
                new AnimalEntity { Id = 2,  Title = "Tiger", Type = "Feline", Price = 670.45, Dwelling = "Forest/Grasslands", Diet = 0 },
                new AnimalEntity { Id = 3,  Title = "Cheetah", Type = "Feline", Price = 630.45, Dwelling = "Desert", Diet = 0 },
                new AnimalEntity { Id = 4,  Title = "Leopard", Type = "Feline", Price = 650.45, Dwelling = "Forest/Grasslands", Diet = 0 },
                new AnimalEntity { Id = 5,  Title = "Jaguar", Type = "Feline", Price = 650.45, Dwelling = "Forest/Grasslands", Diet = 0 },
                new AnimalEntity { Id = 6,  Title = "Hippopotamus", Type = "Mammal", Price = 550.45, Dwelling = "Savannah", Diet = 1 },
                new AnimalEntity { Id = 7,  Title = "Polar Bear", Type = "Mammal", Price = 850.45, Dwelling = "Tundra", Diet = 0 },
                new AnimalEntity { Id = 8,  Title = "Gorilla", Type = "Ape", Price = 450.45, Dwelling = "Forest", Diet = 1 },
                new AnimalEntity { Id = 9,  Title = "Seal", Type = "Mammal", Price = 350.45, Dwelling = "Tundra", Diet = 0 },
                new AnimalEntity { Id = 10,  Title = "Otter", Type = "Mammal", Price = 650.45, Dwelling = "Marshes/Lakes", Diet = 0 },
                new AnimalEntity { Id = 11,  Title = "Warthog", Type = "Mammal", Price = 150.45, Dwelling = "Desert/Grasslands", Diet = 1 },
                new AnimalEntity { Id = 12,  Title = "Meerkat", Type = "Mammal", Price = 250.45, Dwelling = "Desert", Diet = 1 },
                new AnimalEntity { Id = 13,  Title = "Hyena", Type = "Mammal", Price = 450.45, Dwelling = "Grasslands/Forest/Savannahs", Diet = 0 },
                new AnimalEntity { Id = 14,  Title = "Elephant", Type = "Mammal", Price = 1650.45, Dwelling = "Grasslands/Forest/Savannahs/Desert", Diet = 1 },
                new AnimalEntity { Id = 15,  Title = "Blue Whale", Type = "Mammal", Price = 2500.54, Dwelling = "Ocean", Diet = 0 },
                new AnimalEntity { Id = 16,  Title = "Rhinocerous", Type = "Mammal", Price = 850.45, Dwelling = "Desert/Savannahs/Grasslands", Diet = 1 },
                new AnimalEntity { Id = 17,  Title = "Chimpanzee", Type = "Ape", Price = 350.45, Dwelling = "Forest", Diet = 1 },
                new AnimalEntity { Id = 18,  Title = "Orangutan", Type = "Ape", Price = 950.45, Dwelling = "Forest", Diet = 1 },
                new AnimalEntity { Id = 19,  Title = "Fox", Type = "Mammal", Price = 390.45, Dwelling = "Desert/Forest/Grasslands", Diet = 0 },
                new AnimalEntity { Id = 20,  Title = "Wolf", Type = "Mammal", Price = 620.45, Dwelling = "Desert/Forest/Grasslands", Diet = 0 },
                new AnimalEntity { Id = 21,  Title = "Red Panda", Type = "Mammal", Price = 550.45, Dwelling = "Forest", Diet = 1 },
                new AnimalEntity { Id = 22,  Title = "Panda", Type = "Mammal", Price = 550.45, Dwelling = "Forest", Diet = 1 },
                new AnimalEntity { Id = 23,  Title = "Grizzly Bear", Type = "Mammal", Price = 850.45, Dwelling = "Forest/Prairie", Diet = 0 },
                new AnimalEntity { Id = 24,  Title = "Ostrich", Type = "Bird", Price = 530.45, Dwelling = "Desert/Savannah", Diet = 1 },
                new AnimalEntity { Id = 25,  Title = "Penguin", Type = "Bird", Price = 350.45, Dwelling = "Tundra", Diet = 0 },
                new AnimalEntity { Id = 26,  Title = "Great White Shark", Type = "Fish", Price = 850.45, Dwelling = "Ocean", Diet = 0 },
                new AnimalEntity { Id = 27,  Title = "Orca/Killer Whale", Type = "Mammal", Price = 950.45, Dwelling = "Ocean", Diet = 0 },
                new AnimalEntity { Id = 28,  Title = "Pangolin", Type = "Mammal", Price = 750.45, Dwelling = "Forest/Grasslands", Diet = 0 },
                new AnimalEntity { Id = 29,  Title = "Komodo Dragon", Type = "Reptile", Price = 650.45, Dwelling = "Forest", Diet = 0 },
                new AnimalEntity { Id = 30,  Title = "Python", Type = "Reptile", Price = 600.45, Dwelling = "Grasslands/Forest/Savannahs", Diet = 0 },
                new AnimalEntity { Id = 31,  Title = "Anaconda", Type = "Reptile", Price = 700.45, Dwelling = "Forest", Diet = 0 },
                new AnimalEntity { Id = 32,  Title = "Black Mamba", Type = "Reptile", Price = 650.45, Dwelling = "Savannah", Diet = 0 },
                new AnimalEntity { Id = 33,  Title = "Crocodile", Type = "Reptile", Price = 800.45, Dwelling = "Swamps", Diet = 0 },
                new AnimalEntity { Id = 34,  Title = "Alligator", Type = "Reptile", Price = 800.45, Dwelling = "Swamps", Diet = 0 },
                new AnimalEntity { Id = 35,  Title = "Koala", Type = "Mammal", Price = 450.45, Dwelling = "Forest", Diet = 1 },
                new AnimalEntity { Id = 36,  Title = "Lesser Kudu", Type = "Mammal", Price = 550.45, Dwelling = "Savannah", Diet = 1 },
                new AnimalEntity { Id = 37,  Title = "Zebra", Type = "Mammal", Price = 530.45, Dwelling = "Savannah/Grasslands", Diet = 1 },
                new AnimalEntity { Id = 38,  Title = "Gazelle", Type = "Mammal", Price = 450.45, Dwelling = "Desert/Savannahs/Grasslands", Diet = 1 },
                new AnimalEntity { Id = 39,  Title = "Wildebeest", Type = "Mammal", Price = 500.45, Dwelling = "Savannah", Diet = 1 },
                new AnimalEntity { Id = 40, Title = "Okapi", Type = "Mammal", Price = 600.45, Dwelling = "Forest", Diet = 1 },
                new AnimalEntity { Id = 41, Title = "Moose", Type = "Mammal", Price = 650.45, Dwelling = "Forest", Diet = 1 },
                new AnimalEntity { Id = 42, Title = "Giraffe", Type = "Mammal", Price = 550.45, Dwelling = "Savannah", Diet = 1 },
                new AnimalEntity { Id = 43, Title = "Flying Squirrel", Type = "Mammal", Price = 550.45, Dwelling = "Forest", Diet = 1 },
                new AnimalEntity { Id = 44, Title = "Buffalo", Type = "Mammal", Price = 950.45, Dwelling = "Grasslands/Forest/Savannahs", Diet = 1 },
                new AnimalEntity { Id = 45, Title = "Yak", Type = "Mammal", Price = 1000.45, Dwelling = "Tundra", Diet = 1 },
                new AnimalEntity { Id = 46, Title = "Snow Leopard", Type = "Feline", Price = 750.45, Dwelling = "Tundra", Diet = 0 });

            modelBuilder.Entity<FoodEntity>()
                .HasData(
                new FoodEntity { Id = 1, Name = "Ribeye Steak", Price = 45, Type = 0 },
                new FoodEntity { Id = 2, Name = "Leg of Lamb", Price = 15, Type = 0 },
                new FoodEntity { Id = 3, Name = "Beef Shank", Price = 15, Type = 0 },
                new FoodEntity { Id = 4, Name = "New York Style Cheesecake", Price = 59, Type = 2 },
                new FoodEntity { Id = 5, Name = "Deep Fried Oreos", Price = 15, Type = 2 },
                new FoodEntity { Id = 6, Name = "Freshly Baked Chocolate Chip Cookies", Price = 15, Type = 2 },
                new FoodEntity { Id = 7, Name = "Watermelon", Price = 15, Type = 1 },
                new FoodEntity { Id = 8, Name = "Honeydew", Price = 15, Type = 1 },
                new FoodEntity { Id = 9, Name = "Honey", Price = 45, Type = 2 },
                new FoodEntity { Id = 10, Name = "Bluefin Tuna", Price = 425, Type = 0 },
                new FoodEntity { Id = 11, Name = "Escargot", Price = 121, Type = 0 },
                new FoodEntity { Id = 12, Name = "Eucalyptus Leaves", Price = 45, Type = 1 },
                new FoodEntity { Id = 13, Name = "Bamboo Shoots", Price = 59, Type = 1 },
                new FoodEntity { Id = 14, Name = "Jumbo Shrimp", Price = 15, Type = 0 },
                new FoodEntity { Id = 15, Name = "Cotton Candy", Price = 5, Type = 2 },
                new FoodEntity { Id = 16, Name = "Rainbow Trout", Price = 45, Type = 0 },
                new FoodEntity { Id = 17, Name = "Bang Bang Shrimp", Price = 45, Type = 0 },
                new FoodEntity { Id = 18, Name = "Quail Egg", Price = 15, Type = 0 },
                new FoodEntity { Id = 19, Name = "Caterpillars", Price = 5, Type = 0 },
                new FoodEntity { Id = 20, Name = "Bird Seed", Price = 15, Type = 1 },
                new FoodEntity { Id = 21, Name = "Smoked Texan Brisket", Price = 59, Type = 0 },
                new FoodEntity { Id = 22, Name = "Zucchini", Price = 15, Type = 1 },
                new FoodEntity { Id = 23, Name = "Carrots", Price = 5, Type = 1 },
                new FoodEntity { Id = 24, Name = "Lettuce", Price = 5, Type = 1 },
                new FoodEntity { Id = 25, Name = "Wagyu Chunk", Price = 425, Type = 0 },
                new FoodEntity { Id = 26, Name = "Chocolate Fudge", Price = 45, Type = 2 },
                new FoodEntity { Id = 27, Name = "Apples", Price = 15, Type = 1 },
                new FoodEntity { Id = 28, Name = "Sweet Corn", Price = 15, Type = 1 },
                new FoodEntity { Id = 29, Name = "Sugar Snap Peas", Price = 15, Type = 1 },
                new FoodEntity { Id = 30, Name = "Deep Dish Pizza", Price = 45, Type = 1 },
                new FoodEntity { Id = 31, Name = "Grapes", Price = 15, Type = 1 },
                new FoodEntity { Id = 32, Name = "Spare Ribs", Price = 45, Type = 0 },
                new FoodEntity { Id = 33, Name = "Orange Chicken", Price = 15, Type = 0 },
                new FoodEntity { Id = 34, Name = "Green Bean Casserole", Price = 15, Type = 1 },
                new FoodEntity { Id = 35, Name = "Potato Salad", Price = 15, Type = 1 },
                new FoodEntity { Id = 36, Name = "Lobster Roll", Price = 45, Type = 0 },
                new FoodEntity { Id = 37, Name = "Seafood Gumbo", Price = 15, Type = 0 },
                new FoodEntity { Id = 38, Name = "Kimchi", Price = 5, Type = 1 },
                new FoodEntity { Id = 39, Name = "Chicken Fettucini Alfredo", Price = 15, Type = 0 },
                new FoodEntity { Id = 40, Name = "Chicken Fajitas", Price = 15, Type = 0 },
                new FoodEntity { Id = 41, Name = "Raw Whole Chicken", Price = 45, Type = 0 },
                new FoodEntity { Id = 42, Name = "Cheeseburger", Price = 15, Type = 0 },
                new FoodEntity { Id = 43, Name = "Ice Cream", Price = 15, Type = 2 },
                new FoodEntity { Id = 44, Name = "Nachos", Price = 5, Type = 0 },
                new FoodEntity { Id = 45, Name = "Chocolate Eclairs", Price = 15, Type = 2 },
                new FoodEntity { Id = 46, Name = "Donuts", Price = 5, Type = 2 },
                new FoodEntity { Id = 47, Name = "Red Velvet Cake", Price = 15, Type = 2 },
                new FoodEntity { Id = 48, Name = "Bananas", Price = 5, Type = 1 },
                new FoodEntity { Id = 49, Name = "Clementines", Price = 5, Type = 1 },
                new FoodEntity { Id = 50, Name = "Doritos", Price = 5, Type = 1 },
                new FoodEntity { Id = 51, Name = "Dill Pickles", Price = 5, Type = 1 },
                new FoodEntity { Id = 52, Name = "Mozzeralla Cheese Sticks", Price = 5, Type = 1 },
                new FoodEntity { Id = 53, Name = "Smoked Turkey Leg", Price = 15, Type = 0 },
                new FoodEntity { Id = 54, Name = "Cup of Soup Ramen", Price = 5, Type = 1 },
                new FoodEntity { Id = 55, Name = "Raspberries", Price = 15, Type = 1 },
                new FoodEntity { Id = 56, Name = "Blackberries", Price = 15, Type = 1 },
                new FoodEntity { Id = 57, Name = "Strawberries", Price = 15, Type = 1 },
                new FoodEntity { Id = 58, Name = "Blueberries", Price = 15, Type = 1 },
                new FoodEntity { Id = 59, Name = "Tripe", Price = 45, Type = 0 },
                new FoodEntity { Id = 60, Name = "Beef Liver", Price = 15, Type = 0 },
                new FoodEntity { Id = 61, Name = "Goat Heart", Price = 45, Type = 0 },
                new FoodEntity { Id = 62, Name = "Popeye's Chicken Sandwich", Price = 5, Type = 0 },
                new FoodEntity { Id = 63, Name = "Hershey's Chocolate Bar", Price = 5, Type = 2 },
                new FoodEntity { Id = 64, Name = "Strawberry Rhubarb Pie", Price = 15, Type = 2 },
                new FoodEntity { Id = 65, Name = "Funnel Cake", Price = 5, Type = 2 },
                new FoodEntity { Id = 66, Name = "Chicken Skewers", Price = 15, Type = 0 },
                new FoodEntity { Id = 67, Name = "Philly Cheesesteak", Price = 15, Type = 0 },
                new FoodEntity { Id = 68, Name = "Red Sockeye Salmon", Price = 15, Type = 0 },
                new FoodEntity { Id = 69, Name = "Ahi Tuna", Price = 45, Type = 0 },
                new FoodEntity { Id = 70, Name = "Deer Meat", Price = 15, Type = 0 },
                new FoodEntity { Id = 71, Name = "Spanokopita", Price = 15, Type = 1 },
                new FoodEntity { Id = 72, Name = "Shiitake Mushrooms", Price = 15, Type = 1 },
                new FoodEntity { Id = 73, Name = "Mussels", Price = 59, Type = 0 },
                new FoodEntity { Id = 74, Name = "Frog Legs", Price = 45, Type = 0 },
                new FoodEntity { Id = 75, Name = "Grass", Price = 5, Type = 1 },
                new FoodEntity { Id = 76, Name = "Hay", Price = 5, Type = 1 },
                new FoodEntity { Id = 77, Name = "Yams", Price = 15, Type = 1 },
                new FoodEntity { Id = 78, Name = "Walnuts", Price = 15, Type = 1 },
                new FoodEntity { Id = 79, Name = "Almonds", Price = 5, Type = 1 },
                new FoodEntity { Id = 80, Name = "Pistachios", Price = 15, Type = 1 },
                new FoodEntity { Id = 81, Name = "Avocado", Price = 15, Type = 1 },
                new FoodEntity { Id = 82, Name = "Jambalaya", Price = 15, Type = 0 },
                new FoodEntity { Id = 83, Name = "Star Fruit", Price = 15, Type = 1 },
                new FoodEntity { Id = 84, Name = "Croissant", Price = 15, Type = 1 },
                new FoodEntity { Id = 85, Name = "Figs", Price = 15, Type = 1 },
                new FoodEntity { Id = 86, Name = "Kumquats", Price = 15, Type = 1 },
                new FoodEntity { Id = 87, Name = "Mango", Price = 15, Type = 1 },
                new FoodEntity { Id = 88, Name = "Scallops", Price = 45, Type = 0 },
                new FoodEntity { Id = 89, Name = "Anchovies", Price = 5, Type = 0 },
                new FoodEntity { Id = 90, Name = "Nutella", Price = 5, Type = 2 });

            modelBuilder.Entity<ServiceEntity>()
                .HasData(
                new ServiceEntity { Id = 1, Task = "Bathe your pet", Money = 45 },
                new ServiceEntity { Id = 2, Task = "Play with your pet", Money = 50},
                new ServiceEntity { Id = 3, Task = "Groom your pet", Money = 15},
                new ServiceEntity { Id = 4, Task = "Cuddle with your pet", Money = 30},
                new ServiceEntity { Id = 5, Task = "Take your pet on a walk", Money = 25},
                new ServiceEntity { Id = 6, Task = "Take your pet to the park", Money = 20},
                new ServiceEntity { Id = 7, Task = "Take your pet on a playdate", Money = 35},
                new ServiceEntity { Id = 8, Task = "Buy your pet clothes", Money = 10},
                new ServiceEntity { Id = 9, Task = "Give your pet scritches", Money = 5},
                new ServiceEntity { Id = 10, Task = "Give your pet treats", Money = 40},
                new ServiceEntity { Id = 11, Task = "Teach your pet a new trick", Money = 55},
                new ServiceEntity { Id = 12, Task = "Take your pet to the vet", Money = 15},
                new ServiceEntity { Id = 13, Task = "Give your pet a spa day", Money = 30});
        }
    }
}