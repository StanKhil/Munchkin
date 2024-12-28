using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Munchkin.Cards.Treasures
{
    public class Armor : Treasure
    {
        Size size;
        int bonus;
        public Armor(string source, string name, Active action, Condition condition, Discard discard, int price, Size size, int bonus)
        : base(source, name, action, condition, discard, price)
        {
            this.size = size;
            this.bonus = bonus;
        }
    }
}
