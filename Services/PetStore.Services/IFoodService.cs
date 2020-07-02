using PetStore.Services.Models.Food;
using System;

namespace PetStore.Services
{
    public interface IFoodService
    {
        void BuyFromDistributor(string name, double weight, decimal price, double profit, DateTime expiryDate, string brandName, string categoryName);

        void BuyFromDistributor(AddingFoodServiceModel model);
    }
}
