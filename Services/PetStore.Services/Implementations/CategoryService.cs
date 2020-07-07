using PetStore.Data;
using PetStore.Data.Models;
using PetStore.Services.Models.Category;
using System.Linq;

namespace PetStore.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly PetStoreDbContext context;

        public CategoryService(PetStoreDbContext context)
            => this.context = context;

        public CategoryFullInfoServiceModel SearchByName(string name)
            => this.context
                .Categories
                .Where(c => c.Name.ToLower() == name.ToLower())
                .Select(c => new CategoryFullInfoServiceModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description
                })
                .FirstOrDefault();
    }
}
