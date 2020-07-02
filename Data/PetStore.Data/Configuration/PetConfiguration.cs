using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStore.Data.Models;

namespace PetStore.Data.Configuration
{
    public class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder
                   .HasOne(p => p.Breed)
                   .WithMany(b => b.Pets)
                   .HasForeignKey(p => p.BreedId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
