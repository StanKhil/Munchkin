using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Munchkin.Cards.Treasures
{
    internal class Armor : Treasure
    {
        Size size;
        int bonus;
        public Armor(string source, string name, Active action, int price, Size size, int bonus)
        : base(source, name, action, price)
        {
            this.size = size;
            this.bonus = bonus;
        }
    }
}
