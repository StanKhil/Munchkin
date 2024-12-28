using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munchkin.Cards.Doors
{
    internal class Monster : Door
    {
        private int level;
        private int levels;
        private int treasusers;
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

        public Monster(string source, string name, Active action, Active badStuff, Condition condition, int level, int levels, int treasures, int power) 
            : base(source, name, action, condition)
        {
            this.level = level;
            this.levels = levels;
            this.treasusers = treasures;
            this.power = power;
            BadStuff = badStuff;
        }

    }
}
