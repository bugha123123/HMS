﻿using System.ComponentModel.DataAnnotations;

namespace HMS.DTO
{
    public class RegisterDTO
    {

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Gender { get; set; }
    }
}
