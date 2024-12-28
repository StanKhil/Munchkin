using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munchkin.Cards.Treasures
{
    
    internal class Weapon : Treasure
    {
        Size size;
        int hands;
        int bonus;

        public Weapon(string source, string name, Active action, Condition condition, int price, Size size, int hands, int bonus)
        : base(source, name, action, condition, price)
        {
            this.hands = hands;
            this.size = size;
            this.bonus = bonus;
        }
    }
}
