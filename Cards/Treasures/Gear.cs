using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munchkin.Cards.Treasures
{
    internal class Gear : Treasure
    {
        public Gear(string name,int price)
        {
            this.name = name;
            this.price = price;
        }
    }
}
