using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorBattle.Shared
{
    public class UserStatistic
    {
        public int Rank { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public int Battles  { get; set; }
        public int Victories { get; set; }
        public int Deafeat { get; set; }


    }
}
