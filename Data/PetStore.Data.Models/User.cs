﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static PetStore.Data.Models.DataValidation;
using static PetStore.Data.Models.DataValidation.User;

namespace PetStore.Data.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(EmailMaxLength)]
        public string Email { get; set; }

        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
