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
        public PlayerRace(string source, string name, Active action, Condition condition) 
            : base(source, name, action, condition)
        {

        }
    }
}
