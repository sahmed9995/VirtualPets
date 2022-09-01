using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtualPets2.Server.Migrations
{
    public partial class TwelvthTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceCodes",
                columns: table => new
                {
                    UserCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DeviceCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SubjectId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceCodes", x => x.UserCode);
                });

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
                name: "Keys",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Use = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Algorithm = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsX509Certificate = table.Column<bool>(type: "bit", nullable: false),
                    DataProtected = table.Column<bool>(type: "bit", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersistedGrants",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SubjectId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ConsumedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersistedGrants", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Task = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Money = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    FoodId = table.Column<int>(type: "int", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: true),
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                columns: new[] { "Id", "Diet", "Dwelling", "FoodId", "Name", "Price", "ServiceId", "Title", "Type", "UserId" },
                values: new object[,]
                {
                    { 1, 0, "Desert/Forest", null, null, 650.45000000000005, null, "Lion", "Feline", null },
                    { 2, 0, "Forest/Grasslands", null, null, 670.45000000000005, null, "Tiger", "Feline", null },
                    { 3, 0, "Desert", null, null, 630.45000000000005, null, "Cheetah", "Feline", null },
                    { 4, 0, "Forest/Grasslands", null, null, 650.45000000000005, null, "Leopard", "Feline", null },
                    { 5, 0, "Forest/Grasslands", null, null, 650.45000000000005, null, "Jaguar", "Feline", null },
                    { 6, 1, "Savannah", null, null, 550.45000000000005, null, "Hippopotamus", "Mammal", null },
                    { 7, 0, "Tundra", null, null, 850.45000000000005, null, "Polar Bear", "Mammal", null },
                    { 8, 1, "Forest", null, null, 450.44999999999999, null, "Gorilla", "Ape", null },
                    { 9, 0, "Tundra", null, null, 350.44999999999999, null, "Seal", "Mammal", null },
                    { 10, 0, "Marshes/Lakes", null, null, 650.45000000000005, null, "Otter", "Mammal", null },
                    { 11, 1, "Desert/Grasslands", null, null, 150.44999999999999, null, "Warthog", "Mammal", null },
                    { 12, 1, "Desert", null, null, 250.44999999999999, null, "Meerkat", "Mammal", null },
                    { 13, 0, "Grasslands/Forest/Savannahs", null, null, 450.44999999999999, null, "Hyena", "Mammal", null },
                    { 14, 1, "Grasslands/Forest/Savannahs/Desert", null, null, 1650.45, null, "Elephant", "Mammal", null },
                    { 15, 0, "Ocean", null, null, 2500.54, null, "Blue Whale", "Mammal", null },
                    { 16, 1, "Desert/Savannahs/Grasslands", null, null, 850.45000000000005, null, "Rhinocerous", "Mammal", null },
                    { 17, 1, "Forest", null, null, 350.44999999999999, null, "Chimpanzee", "Ape", null },
                    { 18, 1, "Forest", null, null, 950.45000000000005, null, "Orangutan", "Ape", null },
                    { 19, 0, "Desert/Forest/Grasslands", null, null, 390.44999999999999, null, "Fox", "Mammal", null },
                    { 20, 0, "Desert/Forest/Grasslands", null, null, 620.45000000000005, null, "Wolf", "Mammal", null },
                    { 21, 1, "Forest", null, null, 550.45000000000005, null, "Red Panda", "Mammal", null },
                    { 22, 1, "Forest", null, null, 550.45000000000005, null, "Panda", "Mammal", null },
                    { 23, 0, "Forest/Prairie", null, null, 850.45000000000005, null, "Grizzly Bear", "Mammal", null },
                    { 24, 1, "Desert/Savannah", null, null, 530.45000000000005, null, "Ostrich", "Bird", null },
                    { 25, 0, "Tundra", null, null, 350.44999999999999, null, "Penguin", "Bird", null },
                    { 26, 0, "Ocean", null, null, 850.45000000000005, null, "Great White Shark", "Fish", null },
                    { 27, 0, "Ocean", null, null, 950.45000000000005, null, "Orca/Killer Whale", "Mammal", null },
                    { 28, 0, "Forest/Grasslands", null, null, 750.45000000000005, null, "Pangolin", "Mammal", null },
                    { 29, 0, "Forest", null, null, 650.45000000000005, null, "Komodo Dragon", "Reptile", null },
                    { 30, 0, "Grasslands/Forest/Savannahs", null, null, 600.45000000000005, null, "Python", "Reptile", null },
                    { 31, 0, "Forest", null, null, 700.45000000000005, null, "Anaconda", "Reptile", null },
                    { 32, 0, "Savannah", null, null, 650.45000000000005, null, "Black Mamba", "Reptile", null },
                    { 33, 0, "Swamps", null, null, 800.45000000000005, null, "Crocodile", "Reptile", null },
                    { 34, 0, "Swamps", null, null, 800.45000000000005, null, "Alligator", "Reptile", null },
                    { 35, 1, "Forest", null, null, 450.44999999999999, null, "Koala", "Mammal", null },
                    { 36, 1, "Savannah", null, null, 550.45000000000005, null, "Lesser Kudu", "Mammal", null },
                    { 37, 1, "Savannah/Grasslands", null, null, 530.45000000000005, null, "Zebra", "Mammal", null },
                    { 38, 1, "Desert/Savannahs/Grasslands", null, null, 450.44999999999999, null, "Gazelle", "Mammal", null },
                    { 39, 1, "Savannah", null, null, 500.44999999999999, null, "Wildebeest", "Mammal", null },
                    { 40, 1, "Forest", null, null, 600.45000000000005, null, "Okapi", "Mammal", null },
                    { 41, 1, "Forest", null, null, 650.45000000000005, null, "Moose", "Mammal", null },
                    { 42, 1, "Savannah", null, null, 550.45000000000005, null, "Giraffe", "Mammal", null }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Diet", "Dwelling", "FoodId", "Name", "Price", "ServiceId", "Title", "Type", "UserId" },
                values: new object[,]
                {
                    { 43, 1, "Forest", null, null, 550.45000000000005, null, "Flying Squirrel", "Mammal", null },
                    { 44, 1, "Grasslands/Forest/Savannahs", null, null, 950.45000000000005, null, "Buffalo", "Mammal", null },
                    { 45, 1, "Tundra", null, null, 1000.45, null, "Yak", "Mammal", null },
                    { 46, 0, "Tundra", null, null, 750.45000000000005, null, "Snow Leopard", "Feline", null }
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
                    { 38, "Kimchi", 5, 1 }
                });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "Name", "Price", "Type" },
                values: new object[,]
                {
                    { 39, "Chicken Fettucini Alfredo", 15, 0 },
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
                    { 80, "Pistachios", 15, 1 }
                });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "Name", "Price", "Type" },
                values: new object[,]
                {
                    { 81, "Avocado", 15, 1 },
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

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Money", "Task" },
                values: new object[,]
                {
                    { 1, 45, "Bathe your pet" },
                    { 2, 50, "Play with your pet" },
                    { 3, 15, "Groom your pet" },
                    { 4, 30, "Cuddle with your pet" },
                    { 5, 25, "Take your pet on a walk" },
                    { 6, 20, "Take your pet to the park" },
                    { 7, 35, "Take your pet on a playdate" },
                    { 8, 10, "Buy your pet clothes" },
                    { 9, 5, "Give your pet scritches" },
                    { 10, 40, "Give your pet treats" },
                    { 11, 55, "Teach your pet a new trick" },
                    { 12, 15, "Take your pet to the vet" },
                    { 13, 30, "Give your pet a spa day" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_UserId",
                table: "Animals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_DeviceCode",
                table: "DeviceCodes",
                column: "DeviceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_Expiration",
                table: "DeviceCodes",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_Keys_Use",
                table: "Keys",
                column: "Use");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_ConsumedTime",
                table: "PersistedGrants",
                column: "ConsumedTime");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_Expiration",
                table: "PersistedGrants",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_ClientId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "ClientId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_SessionId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "SessionId", "Type" });

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DeviceCodes");

            migrationBuilder.DropTable(
                name: "Keys");

            migrationBuilder.DropTable(
                name: "PersistedGrants");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "UserAnimals");

            migrationBuilder.DropTable(
                name: "UserFoods");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
