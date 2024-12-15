using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munchkin.Cards.Treasures
{
    internal class Armor :Treasure
    {
        Size size;

        public Armor(string name,int price,Size size)
        {
            this.name = name;
            this.price = price;
            this.size = size;
        }
    }
}
