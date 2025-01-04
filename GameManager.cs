using Munchkin.Cards;
using Munchkin.Cards.Doors;
using Munchkin.Player;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;

namespace Munchkin
{

    public enum Stadia
    {
        Start,
        OpenDoors,
        Choice,
        LootTheRoom, //ProvideDoor
        TakeTreasures,
        Flee,
        DiscardCards,
        Battle
    }
    
    public class GameManager : INotifyPropertyChanged
    {
        public List<Treasure> discardTreasures = new List<Treasure>();
        public List<Door> discardDoors = new List<Door>();
        private Deck deck;
        private User user;
        private GameTable table;
        public Dictionary<string?, Card?> positions;
        private string tips;
        private Monster? currentMonster;
        private Stadia stadia = Stadia.Start;
        public int treasuresToTake = 4;
        public int doorsToOpen = 4;

        public string? LastCalledMethod { get; set; }
        public Card? UsedCard { get; set; }
        
        public Stadia Stadia
        {
            get => stadia;
            set
            {
                stadia = value;
                OnPropertyChanged();
            }
        }
        public Monster? CurrentMonster
        {
            get => currentMonster;
            set
            {
                if(currentMonster != value)
                {
                    currentMonster = value;
                    if(currentMonster != null)
                    {
                        Table.monster.Source = currentMonster.Image.Source;
                        positions["monster"] = currentMonster;
                    }
                }
                OnPropertyChanged();
            }
        }

        public string Tips
        {
            get => tips;
            set
            {
                tips = value;
                OnPropertyChanged();
            }
        }

        public User User
        {
            get => user;
            set
            {
                user = value;
                OnPropertyChanged();
            }
        }

        public GameTable Table
        {
            get => table;
            set
            {
                table = value;
                OnPropertyChanged();
            }
        }

        public Deck Deck
        {
            get => deck;
            set
            {
                deck = value;
                OnPropertyChanged();
            }
        }

        public GameManager()
        {
            Deck = new Deck(this);
            User = new User(this);
            User.GameManager = this;
            positions = new Dictionary<string?, Card?>();

            
            positions.Add("card1", null);
            positions.Add("card2", null);
            positions.Add("card3", null);
            positions.Add("card4", null);
            positions.Add("card5", null);
            positions.Add("card6", null);
            positions.Add("card7", null);
            positions.Add("card8", null);
            positions.Add("card9", null);
            positions.Add("card10", null);
            
            positions.Add("race1", null);
            positions.Add("race2", null);
            positions.Add("class1", null);
            positions.Add("class2", null);
            positions.Add("isHalfBlood", null);
            positions.Add("isSupermunchkin", null);

            positions.Add("active1", null);
            positions.Add("active2", null);
            positions.Add("active3", null);
            positions.Add("active4", null);
            positions.Add("active5", null);
            positions.Add("active6", null);
            positions.Add("active7", null);

            positions.Add("monster", null);

            Random random = new Random();
            deck.Doors = new ObservableCollection<Door>(deck.Doors.OrderBy(x => random.Next()));
            deck.Treasures = new ObservableCollection<Treasure>(deck.Treasures.OrderBy(x => random.Next()));
            Start();
        }

        public void OpenDoor()
        {
            Door door = deck.Doors.Last();
            if(door is Monster)
            {
                
                currentMonster = (Monster)door;
                table.monster.Source = door.Image.Source;
                positions["monster"] = currentMonster;
                //MessageBox.Show(currentMonster.Power + "");
                Stadia = Stadia.Battle;
            }
            else if(door is Curse)
            {
                table.active7.Source = door.Image.Source;
                positions["active7"] = door;
                Stadia = Stadia.Choice;
            }
            else
            {
                string path = "";
                foreach (var position in positions)
                {
                    if (position.Value == null)
                    {
                        path = position.Key;
                        break;
                    }
                }
                positions[path] = door;
                user.Hand.Add(door);
                table.SeekAddPosition(path);
                Stadia = Stadia.Choice;
            }
            deck.Doors.Remove(door);
        }
        public async Task Start()
        {
            if (Stadia == Stadia.Start)
            {
                Tips = $"Take {doorsToOpen} doors and\n {treasuresToTake} treasures";
                while(doorsToOpen != 0 || treasuresToTake != 0)
                {
                    Tips = $"Take {doorsToOpen} doors and\n {treasuresToTake} treasures";
                    await Task.Delay(500);
                }
                Tips = $"Take {doorsToOpen} doors and\n {treasuresToTake} treasures";
                Stadia = Stadia.OpenDoors;
            }
            if (Stadia == Stadia.OpenDoors)
            {
                Tips = "Open the DOOR!";
                doorsToOpen = 1;
                while(LastCalledMethod != "OpenDoor")
                {
                    await Task.Delay(500);
                }
                doorsToOpen = 0;
                OpenDoor();
            }
            if (Stadia == Stadia.Choice)
            {
                Tips = "Loot the Room OR \nLook for Troubles";
                LastCalledMethod = "";
                doorsToOpen = 1;
                while(LastCalledMethod == "") await Task.Delay(500);
                if (LastCalledMethod == "Use") Stadia = Stadia.Battle;
                else if (LastCalledMethod == "ProvideDoor") Stadia = Stadia.DiscardCards;
                doorsToOpen = 0;
            }
            if(Stadia == Stadia.Battle)
            {
                Tips = "Figting a monster\nCompare monster's \nand your power";
                table.FirstPanel.Visibility = Visibility.Visible;
                table.fightPanel.Visibility = Visibility.Visible;
                LastCalledMethod = "";
                while (LastCalledMethod == "") await Task.Delay(500);
                if (LastCalledMethod == "Fight") user.Fight(currentMonster);
                else if (LastCalledMethod == "Roll") user.Roll();

                while(currentMonster != null)
                {
                    await Task.Delay(500);
                }
                Stadia = Stadia.TakeTreasures;
            }
            if(Stadia == Stadia.DiscardCards)
            {
                Tips = $"Discard cards until\n you have {user.Limit} \nof them";
                while(user.Hand.Count > user.Limit)
                {
                    await Task.Delay(500);
                }
                Stadia = Stadia.OpenDoors;
            }
            if (Stadia == Stadia.TakeTreasures)
            {
                Tips = "Take treasures";
                while (treasuresToTake != 0)
                {
                    Tips = $"Take {treasuresToTake} treasures";
                    await Task.Delay(500);
                }
                Stadia = Stadia.DiscardCards;
            }
                await Start();
        }
        

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            try
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            catch(Exception e)
            {

            }
        }

    }
}
