using Munchkin.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munchkin.Cards.Doors
{
    internal class PlayerRace : Door
    {
        //Specific specific
        public Race race;
        public PlayerRace(string source, string name, Race race, Active? action, Condition? condition, Discard? discard) 
            : base(source, name, action, condition, discard)
        {
            this.race = race;
        }
    }
}
