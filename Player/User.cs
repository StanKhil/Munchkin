using Munchkin.Cards;
using Munchkin.Cards.Treasures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;

namespace Munchkin.Player
{
    public enum State
    {
        Man,
        Woman
    }
    public enum Race
    {
        Human,
        Elf,
        Hafling,
        Dwarf,
        None
    }
    public enum Class
    {
        None,
        Warrior,
        Wizard,
        Thief,
        Cleric
    }

    public class User : INotifyPropertyChanged
    {
        public GameTable? GameTable { get; set; }
        private int level = 1;
        private int money;
        private int power = 1;
        /*private List<Treasure> treasures = new List<Treasure>();
        private List<Door> doors = new List<Door>();*/
        private List<Treasure> activeTreasures = new List<Treasure>();
        List<Card> hand = new List<Card>();
        private Armor? body;
        private Armor? head;
        private Armor? legs;
        private Weapon? weapon1;
        private Weapon? weapon2;
        private Gear? accessory;


        private State state = State.Man;
        private Race firstRace = Race.Human;
        private Class firstClass = Class.None;
        private Race secondRace = Race.None;
        private Class secondClass = Class.None;

        private bool isSuperMunchkin;
        private bool isHalfBlood;
        public bool HasBig { get; set; }


        public Gear? Accessory
        {
            get => accessory;
            set => accessory = value;
        }
        public Weapon? Weapon1
        {
            get => weapon1;
            set
            {
                if(weapon1 != value)
                {
                    weapon1 = value;
                    OnPropertyChanged();
                }
            }
        }
        public Weapon? Weapon2
        {
            get => weapon2;
            set
            {
                if (weapon2 != value)
                {
                    weapon2 = value;
                    OnPropertyChanged();
                }
            }
        }
        public List<Card> Hand
        {
            get => hand;
            set
            {
                if (hand != value)
                {
                    hand = value;
                    OnPropertyChanged();
                }
            }
        }

        public List<Treasure> ActiveTreasures
        {
            get => activeTreasures;
            set
            {
                if (activeTreasures != value)
                {
                    activeTreasures = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Level
        {
            get => level;
            set
            {
                if (level != value)
                {
                    level = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Money
        {
            get => money;
            set
            {
                if (money != value)
                {
                    money = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Power
        {
            get => power;
            set
            {
                if (power != value)
                {
                    power = value;
                    OnPropertyChanged();
                }
            }
        }


        public Armor? Body
        {
            get => body;
            set
            {
                if (body != value)
                {
                    body = value;
                    OnPropertyChanged();
                }
            }
        }

        public Armor? Head
        {
            get => head;
            set
            {
                if (head != value)
                {
                    head = value;
                    OnPropertyChanged();
                }
            }
        }

        public Armor? Legs
        {
            get => legs;
            set
            {
                if (legs != value)
                {
                    legs = value;
                    OnPropertyChanged();
                }
            }
        }

        public State State
        {
            get => state;
            set
            {
                if (state != value)
                {
                    state = value;
                    OnPropertyChanged();
                }
            }
        }
        public Class FirstClass
        {
            get => firstClass;
            set
            {
                if (firstClass != value)
                {
                    firstClass = value;
                    OnPropertyChanged();
                }
            }
        }

        public Class SecondClass
        {
            get => secondClass;
            set
            {
                if (secondClass != value)
                {
                    secondClass = value;
                    OnPropertyChanged();
                }
            }
        }
        public Race FirstRace
        {
            get => firstRace;
            set
            {
                if (firstRace != value)
                {
                    firstRace = value;
                    OnPropertyChanged();
                }
            }
        }
        public Race SecondRace
        {
            get => secondRace;
            set
            {
                if (secondRace != value)
                {
                    secondRace = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsSuperMunchkin
        {
            get => isSuperMunchkin;
            set
            {
                if (isSuperMunchkin != value)
                {
                    isSuperMunchkin = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsHalfBlood
        {
            get => isHalfBlood;
            set
            {
                if (isHalfBlood != value)
                {
                    isHalfBlood = value;
                    OnPropertyChanged();
                }
            }
        }

        public void Fight() { }
        public int Roll()
        {
            return new Random().Next(1, 7);
        }
        public void Death() { }


        public void ClearRaces()
        {
            FirstRace = Race.Human;
            SecondRace= Race.None;
            GameTable.race1.Source = null;
            GameTable.race2.Source = null;
            GameTable.gameManager.positions["race1"] = null;
            GameTable.gameManager.positions["race2"] = null;
            FirstRace = Race.Human;
            SecondRace = Race.None;
        }

        public void ClearClasses()
        {
            FirstClass = Class.None;
            SecondClass = Class.None;
            GameTable.class1.Source = null;
            GameTable.class2.Source = null;
            GameTable.gameManager.positions["class1"] = null;
            GameTable.gameManager.positions["class2"] = null;
            FirstClass = Class.None;
            SecondClass = Class.None;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
