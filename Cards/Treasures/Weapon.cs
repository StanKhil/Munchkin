using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Munchkin.Cards.Treasures
{
    
    public class Weapon : Treasure
    {
        Size size;
        public int hands;
        int bonus;

        public Weapon() : base ("UnusedSlot.png", "", null, null, null, 0)
        {
        }
        public Weapon(string source, string name, Active? action, Condition? condition, Discard? discard, int price, Size size, int hands, int bonus)
        : base(source, name, action, condition, discard, price)
        {
            this.hands = hands;
            this.size = size;
            this.bonus = bonus;
        }
    }
}
