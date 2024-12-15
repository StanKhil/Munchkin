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

        public Weapon(string name,int price,Size size,int hands)
        {
            this.name = name;
            this.price = price;
            this.size = size;
            this.hands = hands;

        }
    }
}
