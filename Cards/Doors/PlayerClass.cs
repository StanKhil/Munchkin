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

        public PlayerClass(string source, string name, Active action, Condition condition, Discard discard) : base(source, name, action, condition, discard)
        {

        }
    }
}
