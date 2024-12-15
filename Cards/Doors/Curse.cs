using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munchkin.Cards.Doors
{
    internal class Curse : Door
    {
        //Effect bonus
        bool active;
        //Specific specific
        public Curse(string name, bool active)
        {
            this.name = name;
            this.active = active;
        }
    }
}
