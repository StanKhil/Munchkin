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
    public class Deck
    {
        public List<Treasure> treasures = new List<Treasure>();
        public List<Door> doors = new List<Door>();

        public Deck()
        {
            treasures.Add(new Treasure("1000GoldPieces.png", "1000 Gold pieces", null, 1000));
            treasures.Add(new Armor("BootsOfButtKicking.png", "Boots Of Butt Kicking", null, 400, Size.Small, 2));
            treasures.Add(new Weapon("BowWithRibbons.png", "Bow With Ribbons", null, 800, Size.Small, 2, 4));
            treasures.Add(new Weapon("DaggerOfTreachery.png", "Dagger Of Treachery", null, 400, Size.Small, 1, 3));
            treasures.Add(new Weapon("ElevenFootPole.png", "Eleven-Foot Pole", null, 200, Size.Small, 2, 1));
            treasures.Add(new Armor("FlamingArmor.png", "Flaming Armor", null, 400, Size.Small, 2));
            treasures.Add(new Spell("FriendshipPotion.png", "Friendship Potion", null, 200));
            treasures.Add(new Armor("LeatherArmor.png", "Leather Armor", null, 200, Size.Small, 1));
            treasures.Add(new Spell("LoadedDie.png", "Loaded Die", null, 300));
            treasures.Add(new Weapon("MaceOfSharpness.png", "Mace Of Sharpness", null, 600, Size.Small, 1, 4));
            treasures.Add(new Spell("MagicLamp.png", "Magic Lamp", null, 500));
            treasures.Add(new Weapon("RapierOfUnfairness.png", "Rapier Of Unfairness", null, 600, Size.Small, 1, 3));
            treasures.Add(new Weapon("RatOnStick.png", "Rat On Stick", null, 0, Size.Small, 1, 1));
            treasures.Add(new Gear("ReallyImpressiveTitle.png", "Really Impressive Title", null, 0));
            treasures.Add(new Weapon("ShieldOfUbiquity.png", "Shield Of Ubiquity", null, 600, Size.Big, 1, 4));
            treasures.Add(new Armor("ShortWideArmor.png", "Short Wid eArmor", null, 400, Size.Small, 3));
            treasures.Add(new Gear("SingingAndDancingSword.png", "Singing And Dancing Sword", null, 400));
            treasures.Add(new Armor("SneakyBastardSword.png", "Sneaky Bastard Sword", null, 200, Size.Small, 1));
            treasures.Add(new Gear("SpikyKnees.png", "Spiky Knees", null, 200));
            treasures.Add(new Weapon("StaffOfNapalm.png", "Staff Of Napalm", null, 800, Size.Small, 1, 5));
            treasures.Add(new Weapon("SwissArmyPolearm.png", "Swiss Army Polearm", null, 600, Size.Big, 2, 4));

            //treasures[0] = new Treasure("1000GoldPieces.png", "1000 Gold pieces", null, 1000);
            //treasures[1] = new Armor("BootsOfButtKicking.png", "Boots Of Butt Kicking", null, 400, Size.Small, 2);
            //treasures[2] = new Weapon("BowWithRibbons.png", "Bow With Ribbons", null, 800, Size.Small, 2, 4);
            //treasures[3] = new Weapon("DaggerOfTreachery.png", "Dagger Of Treachery", null, 400, Size.Small, 1, 3);
            //treasures[4] = new Weapon("ElevenFootPole.png", "Eleven-Foot Pole", null, 200, Size.Small, 2, 1);
            //treasures[5] = new Armor("FlamingArmor.png", "Flaming Armor", null, 400, Size.Small, 2);
            //treasures[6] = new Spell("FriendshipPotion.png", "Friendship Potion", null, 200);
            //treasures[7] = new Armor("LeatherArmor.png", "Leather Armor", null, 200, Size.Small, 1);
            //treasures[8] = new Spell("LoadedDie.png", "Loaded Die", null, 300);
            //treasures[9] = new Weapon("MaceOfSharpness.png", "Mace Of Sharpness", null, 600, Size.Small, 1, 4);
            //treasures[10] = new Spell("MagicLamp.png", "Magic Lamp", null, 500);
            //treasures[11] = new Weapon("RapierOfUnfairness.png", "Rapier Of Unfairness", null, 600, Size.Small, 1, 3);
            //treasures[12] = new Weapon("RatOnStick.png", "Rat On Stick", null, 0, Size.Small, 1, 1);
            //treasures[13] = new Gear("ReallyImpressiveTitle.png", "Really Impressive Title", null, 0);
            //treasures[14] = new Weapon("ShieldOfUbiquity.png", "Shield Of Ubiquity", null, 600, Size.Big, 1, 4);
            //treasures[15] = new Armor("ShortWideArmor.png", "Short Wid eArmor", null, 400, Size.Small, 3);
            //treasures[16] = new Gear("SingingAndDancingSword.png", "Singing And Dancing Sword", null, 400);
            //treasures[17] = new Armor("SneakyBastardSword.png", "Sneaky Bastard Sword", null, 200, Size.Small, 1);
            //treasures[18] = new Gear("SpikyKnees.png", "Spiky Knees", null, 200);
            //treasures[19] = new Weapon("StaffOfNapalm.png", "Staff Of Napalm", null, 800, Size.Small, 1, 5);
            //treasures[20] = new Weapon("SwissArmyPolearm.png", "Swiss Army Polearm", null, 600, Size.Big, 2, 4);

            //doors[0] = new Monster("3872Orcs.png", "3872 Orcs", null, 10, 1, 3, 10);
            //doors[1] = new Monster("Amazon.png", "Amazon", null, 8, 1, 2, 8);
            //doors[2] = new Monster("Crabs.png", "Crabs", null, 1, 1, 1, 1);
            //doors[3] = new Monster("DroolingSmile.png", "Drooling Smile", null, 1, 1, 1, 1);
            //doors[4] = new Monster("Bigfoot.png", "Bigfoot", null, 12, 1, 3, 12);
            //doors[5] = new Monster("Lawers.png", "Lawers", null, 6, 1, 2, 6);
            //doors[6] = new Monster("Leperchaun.png", "Leperchaun", null, 4, 1, 2, 4);
            //doors[7] = new Monster("PitBull.png", "Pitbull", null, 2, 1, 1, 2);
            //doors[8] = new Monster("PlutoniumDragon.png", "Plutonium Dragon", null, 20, 2, 5, 20);
            //doors[9] = new Monster("ShriekingGeek.png", "Shrieking Geek", null, 6, 1, 2, 6);
            //doors[10] = new Monster("WannabeVampire.png", "Wannabe Vampire", null, 12, 1, 3, 12);
            //doors[11] = new Monster("WightBrothers.png", "Wight Brothers", null, 16, 2, 4, 16);
            //doors[12] = new PlayerClass("Cleric.png", "Cleric", null);
            //doors[13] = new PlayerClass("Thief.png", "Thief", null);
            //doors[14] = new PlayerClass("Warrior.png", "Warrior", null);
            //doors[15] = new PlayerClass("Wizard.png", "Wizard", null);
            //doors[16] = new PlayerRace("Dwarf.png", "Dwarf", null);
            //doors[17] = new PlayerRace("Elf.png", "Elf", null);
            //doors[18] = new PlayerRace("Hafling.png", "Hafling", null);
            //doors[19] = new Door("Supermunchkin.png", "Supermunchkin", null);

            doors.Add(new Monster("3872Orcs.png", "3872 Orcs", null, 10, 1, 3, 10));
            doors.Add(new Monster("Amazon.png", "Amazon", null, 8, 1, 2, 8));
            doors.Add(new Monster("Crabs.png", "Crabs", null, 1, 1, 1, 1));
            doors.Add(new Monster("DroolingSmile.png", "Drooling Smile", null, 1, 1, 1, 1));
            doors.Add(new Monster("Bigfoot.png", "Bigfoot", null, 12, 1, 3, 12));
            doors.Add(new Monster("Lawers.png", "Lawers", null, 6, 1, 2, 6));
            doors.Add(new Monster("Leperchaun.png", "Leperchaun", null, 4, 1, 2, 4));
            doors.Add(new Monster("PitBull.png", "Pitbull", null, 2, 1, 1, 2));
            doors.Add(new Monster("PlutoniumDragon.png", "Plutonium Dragon", null, 20, 2, 5, 20));
            doors.Add(new Monster("ShriekingGeek.png", "Shrieking Geek", null, 6, 1, 2, 6));
            doors.Add( new Monster("WannabeVampire.png", "Wannabe Vampire", null, 12, 1, 3, 12));
            doors.Add( new Monster("WightBrothers.png", "Wight Brothers", null, 16, 2, 4, 16));
            doors.Add( new PlayerClass("Cleric.png", "Cleric", null));
            doors.Add( new PlayerClass("Thief.png", "Thief", null));
            doors.Add( new PlayerClass("Warrior.png", "Warrior", null));
            doors.Add( new PlayerClass("Wizard.png", "Wizard", null));
            doors.Add( new PlayerRace("Dwarf.png", "Dwarf", null));
            doors.Add( new PlayerRace("Elf.png", "Elf", null));
            doors.Add( new PlayerRace("Hafling.png", "Hafling", null));
            doors.Add(new Door("Supermunchkin.png", "Supermunchkin", null));
        }
    }
}
