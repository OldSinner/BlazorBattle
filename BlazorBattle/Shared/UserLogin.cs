using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorBattle.Shared
{
    public class UserLogin
    {
        [Required(ErrorMessage ="Please enter a Email Address.")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
