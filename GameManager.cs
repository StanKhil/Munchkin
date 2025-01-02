using Munchkin.Cards;
using Munchkin.Cards.Doors;
using Munchkin.Player;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Munchkin
{

    public enum Stadia
    {
        Start,
        OpenDoors,
        TakeTreasures,
        UseCards,
        DiscardCards,
        Battle
    }
    public class GameManager : INotifyPropertyChanged
    {
        private Deck deck;
        private User user;
        private GameTable table;
        public Dictionary<string?, Card?> positions;
        private string tips;
        private Monster currentMonster;
        private Stadia stadia;
        public int treasuresToTake = 4;
        public int doorsToOpen = 4;

        public Stadia Stadia
        {
            get => stadia;
            set
            {
                stadia = value;
                OnPropertyChanged();
            }
        }
        public Monster CurrentMonster
        {
            get => currentMonster;
            set
            {
                currentMonster = value;
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


            Random random = new Random();
            deck.Doors = new ObservableCollection<Door>(deck.Doors.OrderBy(x => random.Next()));
            deck.Treasures = new ObservableCollection<Treasure>(deck.Treasures.OrderBy(x => random.Next()));
            Start();
        }

        public void Start()
        {
            //----------------------------
            // 0) Use cards
            // 1) Open doors
            // 2) Discard cards
            //----------------------------

            //while (true)
            //{
            //    if (Stadia == Stadia.Start)
            //    {
            //        //
            //        Stadia = Stadia.OpenDoors;
            //    }
            //    else if (Stadia == Stadia.OpenDoors || Stadia == Stadia.UseCards)
            //    {
            //        //
            //        Stadia = Stadia.DiscardCards;
            //        //Stadia = Stadia.Battle;
            //    }
            //    else if (Stadia == Stadia.DiscardCards)
            //    {
            //        //
            //        Stadia = Stadia.OpenDoors;
            //    }
            //    else if (Stadia == Stadia.Battle)
            //    {
            //        //
            //        Stadia = Stadia.TakeTreasures;
            //    }
            //    else if (Stadia == Stadia.TakeTreasures)
            //    {
            //        //
            //        Stadia = Stadia.UseCards;
            //    }
            //}
        }
        

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
