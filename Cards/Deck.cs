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
            treasures[0] = new Treasure("1000GoldPieces.png", "1000 Gold pieces", null, 1000);
            treasures[1] = new Armor("BootsOfButtKicking.png", "Boots Of Butt Kicking", null, 400, Size.Small, 2);
            treasures[2] = new Weapon("BowWithRibbons.png", "Bow With Ribbons", null, 800, Size.Small, 2, 4);
            treasures[3] = new Weapon("DaggerOfTreachery.png", "Dagger Of Treachery", null, 400, Size.Small, 1, 3);
            treasures[4] = new Weapon("ElevenFootPole.png", "Eleven-Foot Pole", null, 200, Size.Small, 2, 1);


            doors[0] = new Monster("3872Orcs.png", "3872 Orcs", null, 10, 1, 3, 10);
            doors[1] = new Monster("Amazon.png", "Amazon", null, 8, 1, 2, 8);
            doors[2] = new Monster("Crabs.png", "Crabs", null, 1, 1, 1, 1);
            doors[3] = new Monster("DroolingSmile.png", "Drooling Smile", null, 1, 1, 1, 1);
            doors[4] = new Monster("Bigfoot.png", "Bigfoot", null, 12, 1, 3, 12);
            doors[5] = new Monster("Lawers.png", "Lawers", null, 6, 1, 2, 6);
            doors[6] = new Monster("Leperchaun.png", "Leperchaun", null, 4, 1, 2, 4);
            doors[7] = new Monster("PitBull.png", "Pitbull", null, 2, 1, 1, 2);
            doors[8] = new Monster("PlutoniumDragon.png", "Plutonium Dragon", null, 20, 2, 5, 20);
            doors[9] = new Monster("ShriekingGeek.png", "Shrieking Geek", null, 6, 1, 2, 6);
            doors[10] = new Monster("WannabeVampire.png", "Wannabe Vampire", null, 12, 1, 3, 12);
            doors[11] = new Monster("WightBrothers.png", "Wight Brothers", null, 16, 2, 4, 16);
            doors[12] = new PlayerClass("Cleric.png", "Cleric", null);
            doors[13] = new PlayerClass("Thief.png", "Thief", null);
            doors[14] = new PlayerClass("Warrior.png", "Warrior", null);
            doors[15] = new PlayerClass("Wizard.png", "Wizard", null);
            doors[16] = new PlayerRace("Dwarf.png", "Dwarf", null);
            doors[17] = new PlayerRace("Elf.png", "Elf", null);
            doors[18] = new PlayerRace("Hafling.png", "Hafling", null);
            doors[19] = new Door("Suoermunchkin.png", "Supermunchkin", null);
        }
    }
}
