using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munchkin.Cards.Doors
{
    internal class Monster : Door
    {
        int level;
        int levels;
        int treasusers;
        int power;

        public void Fight() { }

        public Monster(string name,int level,int levels,int treasures,int power)
        {
            this.name = name;
            this.level = level;
            this.levels = levels;
            this.treasusers = treasures;
            this.power = power;
        }
    }
}
