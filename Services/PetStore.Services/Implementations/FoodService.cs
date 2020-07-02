using PetStore.Data;
using PetStore.Data.Models;
using PetStore.Services.Models.Food;
using System;

namespace PetStore.Services.Implementations
{
    public class FoodService : IFoodService
    {
        private readonly PetStoreDbContext context;

        public FoodService(PetStoreDbContext context)
            => this.context = context;

        public void BuyFromDistributor(string name, double weight, decimal price, double profit, DateTime expiryDate, string brandName, string categoryName)
        {
            var food = new Food()
            {
                Name = name,
                Weight = weight,
                DistributorPrice = price,
                Price = price + (price * (decimal)profit),
                ExpiryDate = expiryDate
            };
        }

        public void BuyFromDistributor(AddingFoodServiceModel model)
        {
            throw new NotImplementedException();
        }
    }
}
