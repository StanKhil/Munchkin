using Munchkin.Cards;
using Munchkin.Cards.Doors;
using Munchkin.Cards.Treasures;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

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
        public GameManager? GameManager { get; set; }
        private int level = 1;
        private int money;
        private int power = 1;
        private int limit = 5;
        private bool canFlee = false;
        private bool hasBig = false;
        private bool sellDoublePrice = false;
        private int rollNumber = -1;
        private int rollMin = 4;
        private int discarded = 0;

        private List<Treasure> activeTreasures = new List<Treasure>();
        List<Card> hand = new List<Card>();

        private Armor? body;
        private Headgear? head;
        private Footgear? legs;
        private Weapon? weapon1;
        private Weapon? weapon2;
        private Gear? accessory;
        private Curse? curse;

        private PlayerClass? class1;
        private PlayerClass? class2;
        private PlayerRace? race1;
        private PlayerRace? race2;
        private PlayerClass? supermunchkin;
        private PlayerRace? halfBlood;

        private State state = State.Man;
        private Race firstRace = Race.Human;
        private Class firstClass = Class.None;
        private Race secondRace = Race.None;
        private Class secondClass = Class.None;

        private bool isSuperMunchkin;
        private bool isHalfBlood;
        public bool SellDoublePrice
        {
            get => sellDoublePrice;
            set => sellDoublePrice = value;
        }
        public bool HasBig { 
            get => hasBig;
            set 
            {
                if (firstRace == Race.Dwarf || secondRace == Race.Dwarf) hasBig = false;
                else hasBig = value;
            }
        }
        public bool CanFlee { get; set; }
     
        public int Discarded
        { 
            get => discarded;
            set => discarded = value;
        }
        public int Limit 
        { 
            get => limit; 
            set => limit = value; 
        }
        public int RollNumber
        {
            get => rollNumber;
            set
            {
                if (rollNumber != value)
                {
                    rollNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        public int RollMin
        {
            get => rollMin;
            set
            {
                if (rollMin != value)
                {
                    rollMin = value;
                    OnPropertyChanged();
                }
            }
        }
        public User(GameManager gm)
        {
            GameManager = gm;
        }
        
        public Curse? Curse
        {
            get => curse;
            set
            {
                if (curse != value)
                {
                    curse = value;
                    if(curse != null)
                    {
                        GameTable.active7.Source = curse.Image.Source;
                        GameManager.positions["active7"] = curse;
                    }
                }
            }
        }

        public Gear? Accessory
        {
            get => accessory;
            set
            {
                if(accessory != value)
                {
                    accessory = value;
                    if (accessory != null)
                    { 
                        GameTable.active6.Source = accessory.Image.Source;
                        GameManager.positions["active6"] = accessory;
                    }
                    OnPropertyChanged(nameof(Accessory));
                    OnPropertyChanged(nameof(Accessory.Image.Source));
                }
            }
        }
        public Weapon? Weapon1
        {
            get => weapon1;
            set
            {
                if(weapon1 != value)
                {
                    weapon1 = value;
                    if (weapon1 != null)
                    {
                        GameTable.active1.Source = weapon1.Image.Source;
                        GameManager.positions["active1"] = weapon1;
                    }
                    OnPropertyChanged(nameof(Weapon1));
                    OnPropertyChanged(nameof(Weapon1.Image.Source));
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
                    if (weapon2 != null)
                    {
                        GameTable.active2.Source = weapon2.Image.Source;
                        GameManager.positions["active2"] = weapon2;
                    }
                    OnPropertyChanged(nameof(Weapon2));
                    OnPropertyChanged(nameof(Weapon2.Image.Source));
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
                    Power -= level;
                    level = value;
                    Power = level + Power;
                    if(Level == 10)
                    {
                        MessageBox.Show("You won");
                        GameTable.ToMainMenu(null, null);
                    }
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
                power = value;
                OnPropertyChanged();
                
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
                    if (body != null)
                    {
                        GameTable.active4.Source = body.Image.Source;
                        GameManager.positions["active4"] = body;
                    }
                    OnPropertyChanged(nameof(Body));
                    OnPropertyChanged(nameof(Body.Image.Source));
                }
            }
        }

        public Headgear? Head
        {
            get => head;
            set
            {
                if (head != value)
                {
                    head = value;
                    if (head != null)
                    {
                        GameTable.active3.Source = head.Image.Source;
                        GameManager.positions["active3"] = head;
                    }
                    OnPropertyChanged(nameof(Head));
                    OnPropertyChanged(nameof(Head.Image.Source));
                }
            }
        }
        public Footgear? Legs
        {
            get => legs;
            set
            {
                if (legs != value)
                {
                    legs = value;
                    if (legs != null)
                    {
                        GameTable.active5.Source = legs.Image.Source;
                        GameManager.positions["active5"] = legs;
                    }
                    OnPropertyChanged(nameof(Legs));
                    OnPropertyChanged(nameof(Legs.Image.Source));
                }
            }
        }
        public PlayerClass? Class1
        {
            get => class1;
            set
            {
                if(class1 != value)
                {
                    class1 = value;
                    if (class1 != null)
                    {
                        GameTable.class1.Source = class1.Image.Source;
                        GameManager.positions["class1"] = class1;
                    }
                    OnPropertyChanged(nameof(Class1));
                }
            }
        }
        public PlayerClass? Class2
        {
            get => class2;
            set
            {
                if (class2 != value)
                {
                    class2 = value;
                    if (class2 != null)
                    {
                        GameTable.class2.Source = class2.Image.Source;
                        GameManager.positions["class2"] = class2;
                    }
                    OnPropertyChanged(nameof(Class2));
                }
            }
        }
        public PlayerClass? Supermunchkin
        {
            get => supermunchkin;
            set
            {
                if (supermunchkin != value)
                {
                    supermunchkin = value;
                    if (supermunchkin != null)
                    { 
                        GameTable.supermunchkin.Source = supermunchkin.Image.Source;
                        GameManager.positions["isSupermunchkin"] = supermunchkin;
                    }
                    OnPropertyChanged(nameof(Supermunchkin));
                }
            }
        }
        public PlayerRace? Race1
        {
            get => race1;
            set
            {
                if (race1 != value)
                {
                    race1 = value;
                    if (race1 != null)
                    {
                        GameTable.race1.Source = race1.Image.Source;
                        GameManager.positions["race1"] = race1;
                    }

                    OnPropertyChanged(nameof(Race1));
                }
            }
        }
        public PlayerRace? Race2
        {
            get => race2;
            set
            {
                if (race2 != value)
                {
                    race2 = value;
                    if (race2 != null)
                    { 
                        GameTable.race2.Source = race2.Image.Source;
                        GameManager.positions["race2"] = race2;
                    }
                    OnPropertyChanged(nameof(Race2));
                }
            }
        }
        public PlayerRace? HalfBlood
        {
            get => halfBlood;
            set
            {
                if (halfBlood != value)
                {
                    halfBlood = value;
                    if (halfBlood != null) 
                    { 
                        GameTable.halfBlood.Source = halfBlood.Image.Source;
                        GameManager.positions["isHalfBlood"] = halfBlood;
                    }
                    OnPropertyChanged(nameof(HalfBlood));
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
                    GameTable.OnClassChanged();
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
                    GameTable.OnClassChanged();
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
                    GameTable.OnClassChanged();
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
                    GameTable.OnClassChanged();
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
                    GameTable.OnClassChanged();
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

        public void Fight(Monster? monster)
        {
            MessageBox.Show("Fighting");
            if(Power > GameManager.CurrentMonster.Power || ((firstClass == Class.Warrior || secondClass == Class.Warrior) && Power >= GameManager.CurrentMonster.Power))
            {
                MessageBox.Show("You won");
                Level += GameManager.CurrentMonster.Levels;
                GameManager.treasuresToTake = GameManager.CurrentMonster.Treasusers;
            }
            else
            {
                MessageBox.Show("You lost");
                GameManager.CurrentMonster.BadStuff(this);
            }
            GameTable.fightPanel.Visibility = Visibility.Hidden;
            GameManager.discardDoors.Add(GameManager.CurrentMonster);
            GameManager.CurrentMonster = null;
            GameTable.monster.Source = null;
            GameManager.positions["monster"] = null;
            
        }
        public async void Flee()
        {
            MessageBox.Show("Fleeing");
            if (RollNumber >= RollMin)
            {
                MessageBox.Show("You fled");
            }
            else
            {
                MessageBox.Show("You didn't flee " + RollMin + " " + RollNumber);
                GameManager.CurrentMonster.BadStuff(this);
            }
            GameTable.fightPanel.Visibility = Visibility.Hidden;
            GameTable.RollResult.Visibility = Visibility.Hidden;
            GameManager.discardDoors.Add(GameManager.CurrentMonster);
            GameManager.CurrentMonster = null;
            GameTable.monster.Source = null;
            GameManager.positions["monster"] = null;
            
        }
        public async void Roll()
        {
            MessageBox.Show("Roll");
            RollNumber = new Random().Next(1, 7);
            if (firstRace == Race.Elf || secondRace == Race.Elf) RollNumber++;
            GameTable.FirstPanel.Visibility = Visibility.Hidden;
            GameTable.RollResult.Visibility = Visibility.Visible;
            if (RollNumber < RollMin && (firstRace == Race.Hafling || secondRace == Race.Hafling)) GameManager.Tips = "You are Hafling.\nYou can discard\n a card and flee\nagain";
            GameManager.LastCalledMethod = "";
            while (GameManager.LastCalledMethod == "") await Task.Delay(500);
            if(FirstClass == Class.Wizard || SecondClass == Class.Wizard)
            {
                if (Discarded > 3) RollNumber += 3;
                else RollNumber += Discarded;
            }
            if (GameManager.LastCalledMethod == "Discard" && (firstRace == Race.Hafling || secondRace == Race.Hafling)) Roll();
            else if(GameManager.LastCalledMethod == "Flee") Flee();
        }
        public void Death()
        {
            MessageBox.Show("You died");
            GameTable.ToMainMenu(null, null);
        }


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
