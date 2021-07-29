using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models.User
{
    public class Register
    {
        [Required(ErrorMessage = "Nazwa użytkownika jest wymagana")]
        [StringLength(32, ErrorMessage = "Nazwa użytkownika jest za długa (max 32 znaki)")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email jest wymagany")]
        [StringLength(64, ErrorMessage = "Email jest za długi (max 64 znaki)")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane")]
        [StringLength(64, ErrorMessage = "Hasło jest za długie (max 64 znaki)")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Hasła muszą być identyczne!")]
        public string ConfirmPassword { get; set; }


    }
}
