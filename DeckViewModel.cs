using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace Munchkin.Cards
{
    public class DeckViewModel
    {
        public ObservableCollection<Treasure> Treasures { get; set; }
        public ObservableCollection<Door> Doors { get; set; }

        public DeckViewModel(Deck deck)
        {
            Treasures = new ObservableCollection<Treasure>(deck.Treasures);
            Doors = new ObservableCollection<Door>(deck.Doors);
        }
    }
}
