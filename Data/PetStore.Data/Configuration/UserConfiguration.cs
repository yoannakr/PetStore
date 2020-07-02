﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStore.Data.Models;

namespace PetStore.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
