using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Munchkin.Player;

namespace Munchkin.Cards
{
    public delegate void Active(User? user);
    public class Card : INotifyPropertyChanged
    {
        protected bool? active = false;
        protected Active? action;
        private string? name;
        public Image? image = new Image();
        public string? Cell { get; set; }

        public string? Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        public bool? Activated
        {
            get { return active; }
            set { active = value; }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
