using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtualPets2.Server.Data.Migrations
{
    public partial class EighthTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Money = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Dwelling = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diet = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Task = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Money = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFoods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FoodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFoods_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFoods_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAnimals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dwelling = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diet = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAnimals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAnimals_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAnimals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Diet", "Dwelling", "Name", "Price", "Title", "Type", "UserId" },
                values: new object[,]
                {
                    { 1, 0, "Desert/Forest", null, 650.45000000000005, "Lion", "Feline", null },
                    { 2, 0, "Forest/Grasslands", null, 670.45000000000005, "Tiger", "Feline", null },
                    { 3, 0, "Desert", null, 630.45000000000005, "Cheetah", "Feline", null },
                    { 4, 0, "Forest/Grasslands", null, 650.45000000000005, "Leopard", "Feline", null },
                    { 5, 0, "Forest/Grasslands", null, 650.45000000000005, "Jaguar", "Feline", null },
                    { 6, 1, "Savannah", null, 550.45000000000005, "Hippopotamus", "Mammal", null },
                    { 7, 0, "Tundra", null, 850.45000000000005, "Polar Bear", "Mammal", null },
                    { 8, 1, "Forest", null, 450.44999999999999, "Gorilla", "Ape", null },
                    { 9, 0, "Tundra", null, 350.44999999999999, "Seal", "Mammal", null },
                    { 10, 0, "Marshes/Lakes", null, 650.45000000000005, "Otter", "Mammal", null },
                    { 11, 1, "Desert/Grasslands", null, 150.44999999999999, "Warthog", "Mammal", null },
                    { 12, 1, "Desert", null, 250.44999999999999, "Meerkat", "Mammal", null },
                    { 13, 0, "Grasslands/Forest/Savannahs", null, 450.44999999999999, "Hyena", "Mammal", null },
                    { 14, 1, "Grasslands/Forest/Savannahs/Desert", null, 1650.45, "Elephant", "Mammal", null },
                    { 15, 0, "Ocean", null, 2500.54, "Blue Whale", "Mammal", null },
                    { 16, 1, "Desert/Savannahs/Grasslands", null, 850.45000000000005, "Rhinocerous", "Mammal", null },
                    { 17, 1, "Forest", null, 350.44999999999999, "Chimpanzee", "Ape", null },
                    { 18, 1, "Forest", null, 950.45000000000005, "Orangutan", "Ape", null },
                    { 19, 0, "Desert/Forest/Grasslands", null, 390.44999999999999, "Fox", "Mammal", null },
                    { 20, 0, "Desert/Forest/Grasslands", null, 620.45000000000005, "Wolf", "Mammal", null },
                    { 21, 1, "Forest", null, 550.45000000000005, "Red Panda", "Mammal", null },
                    { 22, 1, "Forest", null, 550.45000000000005, "Panda", "Mammal", null },
                    { 23, 0, "Forest/Prairie", null, 850.45000000000005, "Grizzly Bear", "Mammal", null },
                    { 24, 1, "Desert/Savannah", null, 530.45000000000005, "Ostrich", "Bird", null },
                    { 25, 0, "Tundra", null, 350.44999999999999, "Penguin", "Bird", null },
                    { 26, 0, "Ocean", null, 850.45000000000005, "Great White Shark", "Fish", null },
                    { 27, 0, "Ocean", null, 950.45000000000005, "Orca/Killer Whale", "Mammal", null },
                    { 28, 0, "Forest/Grasslands", null, 750.45000000000005, "Pangolin", "Mammal", null },
                    { 29, 0, "Forest", null, 650.45000000000005, "Komodo Dragon", "Reptile", null },
                    { 30, 0, "Grasslands/Forest/Savannahs", null, 600.45000000000005, "Python", "Reptile", null },
                    { 31, 0, "Forest", null, 700.45000000000005, "Anaconda", "Reptile", null },
                    { 32, 0, "Savannah", null, 650.45000000000005, "Black Mamba", "Reptile", null },
                    { 33, 0, "Swamps", null, 800.45000000000005, "Crocodile", "Reptile", null },
                    { 34, 0, "Swamps", null, 800.45000000000005, "Alligator", "Reptile", null },
                    { 35, 1, "Forest", null, 450.44999999999999, "Koala", "Mammal", null },
                    { 36, 1, "Savannah", null, 550.45000000000005, "Lesser Kudu", "Mammal", null },
                    { 37, 1, "Savannah/Grasslands", null, 530.45000000000005, "Zebra", "Mammal", null },
                    { 38, 1, "Desert/Savannahs/Grasslands", null, 450.44999999999999, "Gazelle", "Mammal", null },
                    { 39, 1, "Savannah", null, 500.44999999999999, "Wildebeest", "Mammal", null },
                    { 40, 1, "Forest", null, 600.45000000000005, "Okapi", "Mammal", null },
                    { 41, 1, "Forest", null, 650.45000000000005, "Moose", "Mammal", null },
                    { 42, 1, "Savannah", null, 550.45000000000005, "Giraffe", "Mammal", null }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Diet", "Dwelling", "Name", "Price", "Title", "Type", "UserId" },
                values: new object[,]
                {
                    { 43, 1, "Forest", null, 550.45000000000005, "Flying Squirrel", "Mammal", null },
                    { 44, 1, "Grasslands/Forest/Savannahs", null, 950.45000000000005, "Buffalo", "Mammal", null },
                    { 45, 1, "Tundra", null, 1000.45, "Yak", "Mammal", null }
                });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "Name", "Price", "Type" },
                values: new object[,]
                {
                    { 1, "Ribeye Steak", 45, 0 },
                    { 2, "Leg of Lamb", 15, 0 },
                    { 3, "Beef Shank", 15, 0 },
                    { 4, "New York Style Cheesecake", 59, 2 },
                    { 5, "Deep Fried Oreos", 15, 2 },
                    { 6, "Freshly Baked Chocolate Chip Cookies", 15, 2 },
                    { 7, "Watermelon", 15, 1 },
                    { 8, "Honeydew", 15, 1 },
                    { 9, "Honey", 45, 2 },
                    { 10, "Bluefin Tuna", 425, 0 },
                    { 11, "Escargot", 121, 0 },
                    { 12, "Eucalyptus Leaves", 45, 1 },
                    { 13, "Bamboo Shoots", 59, 1 },
                    { 14, "Jumbo Shrimp", 15, 0 },
                    { 15, "Cotton Candy", 5, 2 },
                    { 16, "Rainbow Trout", 45, 0 },
                    { 17, "Bang Bang Shrimp", 45, 0 },
                    { 18, "Quail Egg", 15, 0 },
                    { 19, "Caterpillars", 5, 0 },
                    { 20, "Bird Seed", 15, 1 },
                    { 21, "Smoked Texan Brisket", 59, 0 },
                    { 22, "Zucchini", 15, 1 },
                    { 23, "Carrots", 5, 1 },
                    { 24, "Lettuce", 5, 1 },
                    { 25, "Wagyu Chunk", 425, 0 },
                    { 26, "Chocolate Fudge", 45, 2 },
                    { 27, "Apples", 15, 1 },
                    { 28, "Sweet Corn", 15, 1 },
                    { 29, "Sugar Snap Peas", 15, 1 },
                    { 30, "Deep Dish Pizza", 45, 1 },
                    { 31, "Grapes", 15, 1 },
                    { 32, "Spare Ribs", 45, 0 },
                    { 33, "Orange Chicken", 15, 0 },
                    { 34, "Green Bean Casserole", 15, 1 },
                    { 35, "Potato Salad", 15, 1 },
                    { 36, "Lobster Roll", 45, 0 },
                    { 37, "Seafood Gumbo", 15, 0 },
                    { 38, "Kimchi", 5, 1 },
                    { 39, "Chicken Fettucini Alfredo", 15, 0 }
                });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "Name", "Price", "Type" },
                values: new object[,]
                {
                    { 40, "Chicken Fajitas", 15, 0 },
                    { 41, "Raw Whole Chicken", 45, 0 },
                    { 42, "Cheeseburger", 15, 0 },
                    { 43, "Ice Cream", 15, 2 },
                    { 44, "Nachos", 5, 0 },
                    { 45, "Chocolate Eclairs", 15, 2 },
                    { 46, "Donuts", 5, 2 },
                    { 47, "Red Velvet Cake", 15, 2 },
                    { 48, "Bananas", 5, 1 },
                    { 49, "Clementines", 5, 1 },
                    { 50, "Doritos", 5, 1 },
                    { 51, "Dill Pickles", 5, 1 },
                    { 52, "Mozzeralla Cheese Sticks", 5, 1 },
                    { 53, "Smoked Turkey Leg", 15, 0 },
                    { 54, "Cup of Soup Ramen", 5, 1 },
                    { 55, "Raspberries", 15, 1 },
                    { 56, "Blackberries", 15, 1 },
                    { 57, "Strawberries", 15, 1 },
                    { 58, "Blueberries", 15, 1 },
                    { 59, "Tripe", 45, 0 },
                    { 60, "Beef Liver", 15, 0 },
                    { 61, "Goat Heart", 45, 0 },
                    { 62, "Popeye's Chicken Sandwich", 5, 0 },
                    { 63, "Hershey's Chocolate Bar", 5, 2 },
                    { 64, "Strawberry Rhubarb Pie", 15, 2 },
                    { 65, "Funnel Cake", 5, 2 },
                    { 66, "Chicken Skewers", 15, 0 },
                    { 67, "Philly Cheesesteak", 15, 0 },
                    { 68, "Red Sockeye Salmon", 15, 0 },
                    { 69, "Ahi Tuna", 45, 0 },
                    { 70, "Deer Meat", 15, 0 },
                    { 71, "Spanokopita", 15, 1 },
                    { 72, "Shiitake Mushrooms", 15, 1 },
                    { 73, "Mussels", 59, 0 },
                    { 74, "Frog Legs", 45, 0 },
                    { 75, "Grass", 5, 1 },
                    { 76, "Hay", 5, 1 },
                    { 77, "Yams", 15, 1 },
                    { 78, "Walnuts", 15, 1 },
                    { 79, "Almonds", 5, 1 },
                    { 80, "Pistachios", 15, 1 },
                    { 81, "Avocado", 15, 1 }
                });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "Name", "Price", "Type" },
                values: new object[,]
                {
                    { 82, "Jambalaya", 15, 0 },
                    { 83, "Star Fruit", 15, 1 },
                    { 84, "Croissant", 15, 1 },
                    { 85, "Figs", 15, 1 },
                    { 86, "Kumquats", 15, 1 },
                    { 87, "Mango", 15, 1 },
                    { 88, "Scallops", 45, 0 },
                    { 89, "Anchovies", 5, 0 },
                    { 90, "Nutella", 5, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_UserId",
                table: "Animals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_UserId",
                table: "Services",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnimals_AnimalId",
                table: "UserAnimals",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnimals_UserId",
                table: "UserAnimals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFoods_FoodId",
                table: "UserFoods",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFoods_UserId",
                table: "UserFoods",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "UserAnimals");

            migrationBuilder.DropTable(
                name: "UserFoods");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
