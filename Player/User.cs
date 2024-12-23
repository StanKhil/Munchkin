using Munchkin.Cards;
using Munchkin.Cards.Treasures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Munchkin.Player
{
    public enum State
    {
        Men,
        Women
    }
    public class User : INotifyPropertyChanged
    {
        int level;
        int money;
        int power;
        List<Treasure> treasures = new List<Treasure>();
        List<Door> doors = new List<Door>();
        Armor? body;
        Armor? head;
        Armor? legs;

        public void Fight() { }


        private State state = State.Men;

        public State State
        {
            get => state;
            set
            {
                state = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
