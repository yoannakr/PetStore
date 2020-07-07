using PetStore.Data;
using PetStore.Services.Implementations;
using PetStore.Services.Models.Food;
using System;

namespace PetStore
{
    public class Program
    {
        public static void Main()
        {
            using var context = new PetStoreDbContext();

            var brandService = new BrandService(context);

            var categoryService = new CategoryService(context);

            var foodService = new FoodService(context, brandService, categoryService);

            var addingFoodModel = new AddingFoodServiceModel()
            {
                Name = "Banana",
                Weight = 5,
                Price = 6m,
                Profit = 0.4,
                ExpiryDate = DateTime.Now,
                BrandName = "Bevola",
                CategoryName = "Food" // error, because not exist
            };

            foodService.BuyFromDistributor(addingFoodModel);
        }
    }
}
