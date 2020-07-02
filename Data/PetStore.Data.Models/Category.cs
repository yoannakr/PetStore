using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static PetStore.Data.Models.DataValidation;

namespace PetStore.Data.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        public ICollection<Pet> Pets { get; set; }

        public ICollection<Food> Foods { get; set; }

        public ICollection<Toy> Toys { get; set; }


    }
}
