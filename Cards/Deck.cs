using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Munchkin.Cards;
using Munchkin.Cards.Treasures;
using Munchkin.Cards.Doors;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace Munchkin.Cards
{
    internal class Deck
    {
        List<Treasure> treasures = new List<Treasure>(20);
        List<Door> doors = new List<Door>(20);

        public Deck()
        {
            //treasures[0] = new Armor();
            //doors[0] = new Curse();
            treasures[0] = new Treasure("1000GoldPieces.png", "1000 Gold pieces", null, 1000);
            treasures[1] = new Armor("BootsOfButtKicking.png", "Boots Of Butt Kicking", null, 400, Size.Small, 2);
            treasures[2] = new Weapon("BowWithRibbons.png", "Bow With Ribbons", null, 800, Size.Small, 2, 4);
            treasures[3] = new Weapon("DaggerOfTreachery.png", "Dagger Of Treachery", null, 400, Size.Small, 1, 3);
            treasures[4] = new Weapon("ElevenFootPole.png", "Eleven-Foot Pole", null, 200, Size.Small, 2, 1);



        }
    }
}
