using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Authentication.WebApi.Models
{
    public class RegisterUser
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
