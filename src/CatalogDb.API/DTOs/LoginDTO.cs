﻿using System.ComponentModel.DataAnnotations;

namespace CatalogDb.API.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Username is required")]
        public string Password { get; set; } = string.Empty;
    }
}
