using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munchkin.Cards.Doors
{
    internal class PlayerRace : Door
    {
        //Effect bonus
        bool active;
        //Specific specific

        public PlayerRace(string name, bool active)
        {
            this.name = name;
            this.active = active;
        }
    }
}
