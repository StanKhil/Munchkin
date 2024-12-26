using Munchkin.Cards;
using Munchkin.Cards.Treasures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Munchkin.Player
{
    public enum State
    {
        Man,
        Woman
    }

    public class User : INotifyPropertyChanged
    {
        private int level = 1;
        private int money;
        private int power = 0;
        private List<Treasure> treasures = new List<Treasure>();
        private List<Door> doors = new List<Door>();
        private Armor? body;
        private Armor? head;
        private Armor? legs;

        private State state = State.Man;

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

        public List<Treasure> Treasures
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

        public List<Door> Doors
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

        public void Fight() { }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
