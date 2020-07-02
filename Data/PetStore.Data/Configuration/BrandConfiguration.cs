﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStore.Data.Models;

namespace PetStore.Data.Configuration
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder
                .HasMany(b => b.Foods)
                .WithOne(f => f.Brand)
                .HasForeignKey(f => f.BrandId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasMany(b => b.Toys)
               .WithOne(t => t.Brand)
               .HasForeignKey(t => t.BrandId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
