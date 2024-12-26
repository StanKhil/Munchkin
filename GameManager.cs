using Munchkin.Cards;
using Munchkin.Player;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Munchkin
{
    public class GameManager : INotifyPropertyChanged
    {
        private Deck deck;
        private User user;
        private Table table;
        public Dictionary<string?, Card?> positions;

        public User User
        {
            get => user;
            set
            {
                user = value;
                OnPropertyChanged();
            }
        }

        public Table Table
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
            Deck = new Deck();
            User = new User();
            //Table = new Table();

            //positions.Add("card1", null);
            //positions.Add("card2", null);
            //positions.Add("card3", null);
            //positions.Add("card4", null);
            //positions.Add("card5", null);
            //positions.Add("card6", null);
            //positions.Add("card7", null);
            //positions.Add("card8", null);
            //positions.Add("card9", null);
            //positions.Add("card10", null);
            //
            //positions.Add("race1", null);
            //positions.Add("race2", null);
            //positions.Add("class1", null);
            //positions.Add("class2", null);
            //positions.Add("isHalfBlood", null);
            //positions.Add("isSupermunchkin", null);
            //
            //positions.Add("hand1", null);
            //positions.Add("hand2", null);
            //positions.Add("footgear", null);
            //positions.Add("headgear", null);
            //positions.Add("armor", null);
            //positions.Add("accessory", null);
            //positions.Add("curse", null);


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
        }
        

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
