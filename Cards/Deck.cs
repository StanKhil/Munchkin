using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Munchkin.Cards;

namespace Munchkin.Cards
{
    internal class Deck
    {
        List<Treasure> treasures = new List<Treasure>(16);
        List<Door> doors = new List<Door>(16);

        public Deck()
        {
            //treasures[0] = new Armor();
            //doors[0] = new Curse();
        }
    }
}
