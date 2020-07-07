using PetStore.Services.Models.Category;

namespace PetStore.Services
{
    public interface ICategoryService
    {
        CategoryFullInfoServiceModel SearchByName(string name);
    }
}
