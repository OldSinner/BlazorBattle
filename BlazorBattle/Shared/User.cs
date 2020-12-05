using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorBattle.Shared
{
    public class User
    {
        public int id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int Bananas { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool isConfirmed { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;

        public List<UserUnit> Units { get; set; }

        public int Battles { get; set; }
        public int Victories { get; set; }
    }
}
