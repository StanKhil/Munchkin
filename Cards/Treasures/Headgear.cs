using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munchkin.Cards.Treasures
{
    public class Headgear : Armor
    {
        public Headgear(string source, string name, Active? action, Condition? condition, Discard? discard, int price, Size size, int bonus)
        : base(source, name, action, condition, discard, price, size, bonus)
        {
        }
    }
}
