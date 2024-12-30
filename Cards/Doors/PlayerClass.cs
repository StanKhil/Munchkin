using Munchkin.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munchkin.Cards.Doors
{
    internal class PlayerClass : Door
    {
        //Specific specific
        public Class pClass;
        public PlayerClass(string source, string name, Class pClass, Active action, Condition condition, Discard discard) : base(source, name, action, condition, discard)
        {
            this.pClass = pClass;
        }
    }
}
