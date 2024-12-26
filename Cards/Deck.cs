using Munchkin.Cards;
using Munchkin.Cards.Treasures;
using Munchkin.Cards.Doors;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Munchkin.Cards
{
    public class Deck : INotifyPropertyChanged
    {
        private ObservableCollection<Treasure> treasures;
        private ObservableCollection<Door> doors;

        public ObservableCollection<Treasure> Treasures
        {
            get => treasures;
            set
            {
                if (treasures != value)
                {
                    treasures = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<Door> Doors
        {
            get => doors;
            set
            {
                if (doors != value)
                {
                    doors = value;
                    OnPropertyChanged();
                }
            }
        }

        public Deck()
        {
            Treasures = new ObservableCollection<Treasure>
            {
                new Treasure("1000GoldPieces.png", "1000 Gold pieces", null, 1000),
                new Armor("BootsOfButtKicking.png", "Boots Of Butt Kicking", null, 400, Size.Small, 2),
                new Weapon("BowWithRibbons.png", "Bow With Ribbons", null, 800, Size.Small, 2, 4),
                new Weapon("DaggerOfTreachery.png", "Dagger Of Treachery", null, 400, Size.Small, 1, 3),
                new Weapon("ElevenFootPole.png", "Eleven-Foot Pole", null, 200, Size.Small, 2, 1),
                new Armor("FlamingArmor.png", "Flaming Armor", null, 400, Size.Small, 2),
                new Spell("FriendshipPotion.png", "Friendship Potion", null, 200),
                new Armor("LeatherArmor.png", "Leather Armor", null, 200, Size.Small, 1),
                new Spell("LoadedDie.png", "Loaded Die", null, 300),
                new Weapon("MaceOfSharpness.png", "Mace Of Sharpness", null, 600, Size.Small, 1, 4),
                new Spell("MagicLamp.png", "Magic Lamp", null, 500),
                new Weapon("RapierOfUnfairness.png", "Rapier Of Unfairness", null, 600, Size.Small, 1, 3),
                new Weapon("RatOnStick.png", "Rat On Stick", null, 0, Size.Small, 1, 1),
                new Gear("ReallyImpressiveTitle.png", "Really Impressive Title", null, 0),
                new Weapon("ShieldOfUbiquity.png", "Shield Of Ubiquity", null, 600, Size.Big, 1, 4),
                new Armor("ShortWideArmor.png", "Short Wide Armor", null, 400, Size.Small, 3),
                new Gear("SingingAndDancingSword.png", "Singing And Dancing Sword", null, 400),
                new Armor("SneakyBastardSword.png", "Sneaky Bastard Sword", null, 200, Size.Small, 1),
                new Gear("SpikyKnees.png", "Spiky Knees", null, 200),
                new Weapon("StaffOfNapalm.png", "Staff Of Napalm", null, 800, Size.Small, 1, 5),
                new Weapon("SwissArmyPolearm.png", "Swiss Army Polearm", null, 600, Size.Big, 2, 4)
            };

            Doors = new ObservableCollection<Door>
            {
                new Monster("3872Orcs.png", "3872 Orcs", null, 10, 1, 3, 10),
                new Monster("Amazon.png", "Amazon", null, 8, 1, 2, 8),
                new Monster("Crabs.png", "Crabs", null, 1, 1, 1, 1),
                new Monster("DroolingSmile.png", "Drooling Smile", null, 1, 1, 1, 1),
                new Monster("Bigfoot.png", "Bigfoot", null, 12, 1, 3, 12),
                new Monster("Lawers.png", "Lawers", null, 6, 1, 2, 6),
                new Monster("Leperchaun.png", "Leperchaun", null, 4, 1, 2, 4),
                new Monster("PitBull.png", "Pitbull", null, 2, 1, 1, 2),
                new Monster("PlutoniumDragon.png", "Plutonium Dragon", null, 20, 2, 5, 20),
                new Monster("ShriekingGeek.png", "Shrieking Geek", null, 6, 1, 2, 6),
                new Monster("WannabeVampire.png", "Wannabe Vampire", null, 12, 1, 3, 12),
                new Monster("WightBrothers.png", "Wight Brothers", null, 16, 2, 4, 16),
                new PlayerClass("Cleric.png", "Cleric", null),
                new PlayerClass("Thief.png", "Thief", null),
                new PlayerClass("Warrior.png", "Warrior", null),
                new PlayerClass("Wizard.png", "Wizard", null),
                new PlayerRace("Dwarf.png", "Dwarf", null),
                new PlayerRace("Elf.png", "Elf", null),
                new PlayerRace("Hafling.png", "Hafling", null),
                new Door("Supermunchkin.png", "Supermunchkin", null)
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
