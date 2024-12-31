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
    public delegate bool Condition(User? user);
    public delegate void Discard(User? user);
    public class Card : INotifyPropertyChanged
    {
        protected bool? active = false;
        protected Active? action;
        protected Condition? condition;
        protected Discard? discard;
        private string? name;
        public Image? image = new Image();
        public string? Cell { get; set; }

        
        public Active? Action 
        {
            get { return action; }
            set { action = value; }
        }
        public Condition? Condition
        {
            get => condition;
            set => condition = value;
        }
        public Discard? Discard
        {
            get => discard;
            set => discard = value;
        }
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

        public Image? Image
        {
            get { return image; }
            set
            {
                if (image != value)
                {
                    image = value;
                    OnPropertyChanged(nameof(Image));
                }
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
