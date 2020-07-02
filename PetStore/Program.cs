using PetStore.Data;
using PetStore.Services.Implementations;

namespace PetStore
{
    public class Program
    {
        public static void Main()
        {
            using var context = new PetStoreDbContext();

            var brandService = new BrandService(context);

            brandService.Create("Bevola");
        }
    }
}
