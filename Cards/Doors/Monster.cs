using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munchkin.Cards.Doors
{
    public class Monster : Door
    {
        public int Level { get; set; }
        public int Levels { get; set; }
        public int Treasusers { get; set; }
        private int power;
        private Active? badStuff;

        //public void Fight() { }
        public int Power
        {
            get { return power; }
            set { this.power = value; }
        }
        public Active? BadStuff
        {
            get { return badStuff; }
            set { badStuff = value; }
        }

        public Monster(string source, string name, Active? action, Active? badStuff, Condition? condition, Discard? discard, int level, int levels, int treasures, int power) 
            : base(source, name, action, condition, discard)
        {
            this.Level = level;
            this.Levels = levels;
            this.Treasusers = treasures;
            this.power = power;
            BadStuff = badStuff;
        }

    }
}
