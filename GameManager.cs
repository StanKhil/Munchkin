using Munchkin.Cards;
using Munchkin.Player;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace Munchkin
{
    public class GameManager : INotifyPropertyChanged
    {
        private Deck deck;
        private User user;
        private Table table;

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
            Table = new Table();

            Random random = new Random();
            deck.Doors = new ObservableCollection<Door>(deck.Doors.OrderBy(x => random.Next()));
            deck.Treasures = new ObservableCollection<Treasure>(deck.Treasures.OrderBy(x => random.Next()));

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
