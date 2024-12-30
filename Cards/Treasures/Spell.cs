using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munchkin.Cards.Treasures
{
    internal class Spell : Treasure
    {
        public Spell(string source, string name, Active? action, Condition? condition, Discard? discard, int price) 
            : base(source, name, action, condition, discard, price) { }
    }
}
