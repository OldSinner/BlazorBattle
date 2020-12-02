using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorBattle.Shared
{
    public class Unit
    {
        public int id { get; set; }
        public string name { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int HitPoints { get; set; } = 100;
        public int BananaCost { get; set; }

    }
}
