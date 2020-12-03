using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorBattle.Shared
{
    public class UserRegister
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(20, ErrorMessage = "Too long Username, max 16")]
        public string Username { get; set; }

        public string Bio { get; set; }
        [Required, StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Password do not match")]
        public string ConfrimPassword { get; set; }
        [Range(0, 1000, ErrorMessage = "Use numbe in range 0-1000")]
        public int Bananas { get; set; } = 100;

        public string StartUserId { get; set; } = "1";
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        [Range(typeof(bool), "true", "true", ErrorMessage = "Only Confirmed users an play")]
        public bool isConfirmed { get; set; } = true;

    }
}
