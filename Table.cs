using Munchkin.Cards;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Munchkin
{
    public class Table : INotifyPropertyChanged
    {
        private ObservableCollection<Treasure> treasuresHand = new ObservableCollection<Treasure>();
        private ObservableCollection<Door> doorsHand = new ObservableCollection<Door>();

        public ObservableCollection<Treasure> TreasuresHand
        {
            get => treasuresHand;
            set
            {
                if (treasuresHand != value)
                {
                    treasuresHand = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<Door> DoorsHand
        {
            get => doorsHand;
            set
            {
                if (doorsHand != value)
                {
                    doorsHand = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
