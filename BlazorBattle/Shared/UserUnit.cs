using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorBattle.Shared
{
    public class UserUnit
    {
        public int id { get; set; }
        public int UserId { get; set; }
        public Unit Unit { get; set; }
        public int UnitId { get; set; }
        public int HitPoints { get; set; }
    }
}
