using System;

namespace PetStore.Services.Models.Food
{
    public class AddingFoodServiceModel
    {
        public string Name { get; set; }

        public double Weight { get; set; }

        public decimal Price { get; set; }

        public double Profit { get; set; }

        public DateTime ExpiryDate { get; set; }

        public string BrandName { get; set; }

        public string CategoryName { get; set; }
    }
}
