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

        //public void Fight() { }

        public Monster(string source, string name, Active action, int level, int levels, int treasures, int power) 
            : base(source, name, action)
        {
            this.level = level;
            this.levels = levels;
            this.treasusers = treasures;
            this.power = power;
        }
    }
}
