using PetStore.Data;
using PetStore.Data.Models;
using PetStore.Services.Models.Food;
using System;
using System.Linq;

namespace PetStore.Services.Implementations
{
    public class FoodService : IFoodService
    {
        private readonly PetStoreDbContext context;
        private readonly IBrandService brandService;
        private readonly ICategoryService categoryService;

        public FoodService(PetStoreDbContext context, IBrandService brandService, ICategoryService categoryService)
        {
            this.context = context;
            this.brandService = brandService;
            this.categoryService = categoryService;
        }

        public void BuyFromDistributor(string name, double weight, decimal price, double profit, DateTime expiryDate, string brandName, string categoryName)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new InvalidOperationException("Name cannot be empty!");
            }

            if (price <= 0)
            {
                throw new InvalidOperationException("Price cannot be less than 0 or equal to 0!");
            }

            if (profit < 0 || profit > 1)
            {
                throw new InvalidOperationException("Profit must be between 0 and 1!");
            }

            if (String.IsNullOrEmpty(brandName))
            {
                throw new InvalidOperationException("Brand Name cannot be empty!");
            }

            if (String.IsNullOrEmpty(categoryName))
            {
                throw new InvalidOperationException("Category Name cannot be empty!");
            }

            var brand = this.brandService
                .SearchByName(brandName)
                .FirstOrDefault();

            if (brand == null)
            {
                throw new InvalidOperationException("Brand with this name not exist!");

            }

            var category = this.categoryService
                .SearchByName(categoryName);

            if (category == null)
            {
                throw new InvalidOperationException("Category with this name not exist!");
            }

            var food = new Food()
            {
                Name = name,
                Weight = weight,
                DistributorPrice = price,
                Price = price + (price * (decimal)profit),
                ExpiryDate = expiryDate,
                BrandId = brand.Id,
                CategoryId = category.Id
            };

            this.context.Foods.Add(food);
            this.context.SaveChanges();
        }

        public void BuyFromDistributor(AddingFoodServiceModel model)
        {
            if (String.IsNullOrEmpty(model.Name))
            {
                throw new InvalidOperationException("Name cannot be empty!");
            }

            if (model.Price <= 0)
            {
                throw new InvalidOperationException("Price cannot be less than 0 or equal to 0!");
            }

            if (model.Profit < 0 || model.Profit > 1)
            {
                throw new InvalidOperationException("Profit must be between 0 and 1!");
            }

            if (String.IsNullOrEmpty(model.BrandName))
            {
                throw new InvalidOperationException("Brand Name cannot be empty!");
            }

            if (String.IsNullOrEmpty(model.CategoryName))
            {
                throw new InvalidOperationException("Category Name cannot be empty!");
            }

            var brand = this.brandService
                .SearchByName(model.BrandName)
                .FirstOrDefault();

            if (brand == null)
            {
                throw new InvalidOperationException("Brand with this name not exist!");

            }

            var category = this.categoryService
                .SearchByName(model.CategoryName);

            if (category == null)
            {
                throw new InvalidOperationException("Category with this name not exist!");
            }

            var food = new Food()
            {
                Name = model.Name,
                Weight = model.Weight,
                DistributorPrice = model.Price,
                Price = model.Price + (model.Price * (decimal)model.Profit),
                BrandId = brand.Id,
                CategoryId = category.Id
            };

            this.context.Foods.Add(food);
            this.context.SaveChanges();
        }
    }
}
