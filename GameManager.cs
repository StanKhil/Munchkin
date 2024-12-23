using Munchkin.Cards;
using Munchkin.Player;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Munchkin
{
    public class GameManager : INotifyPropertyChanged
    {
        private Deck deck;
        private User user;

        public User User
        {
            get => user;
            set
            {
                user = value;
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
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }  
         
    }
}
