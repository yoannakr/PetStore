using PetStore.Data;
using System.Linq;
using PetStore.Data.Models;
using PetStore.Services.Models.Brand;
using System;
using System.Collections.Generic;
using static PetStore.Data.Models.DataValidation;

namespace PetStore.Services.Implementations
{
    public class BrandService : IBrandService
    {
        private readonly PetStoreDbContext context;

        public BrandService(PetStoreDbContext context)
            => this.context = context;


        public int Create(string name)
        {
            if (name == null)
            {
                throw new NullReferenceException($"Brand name cannot be empty.");

            }

            if (this.context.Brands.Any(b => b.Name == name))
            {
                throw new InvalidOperationException($"This brand name already exists.");
            }

            if (name.Length > NameMaxLength)
            {
                throw new InvalidOperationException($"Brand name cannot be more than {NameMaxLength} charachters.");
            }

            var brand = new Brand
            {
                Name = name
            };

            this.context.Brands.Add(brand);

            this.context.SaveChanges();

            return brand.Id;
        }

        public IEnumerable<BrandListingServiceModel> SearchByName(string name)
            => this.context
                   .Brands
                   .Where(b => b.Name.ToLower().Contains(name.ToLower()))
                   .Select(b => new BrandListingServiceModel
                   {
                       Id = b.Id,
                       Name = b.Name
                   })
                   .ToList();
    }
}
