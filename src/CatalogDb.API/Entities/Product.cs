﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogDb.API.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(300)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(300)]
        public string ImageUrl { get; set; } = string.Empty;

        public float Stock { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int CategoryId { get; set; }
    }
}
