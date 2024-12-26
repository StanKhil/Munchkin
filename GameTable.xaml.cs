using Munchkin.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Munchkin
{
    /// <summary>
    /// Interaction logic for GameTable.xaml
    /// </summary>
    public partial class GameTable : UserControl
    {
        
        public GameTable()
        {
            InitializeComponent();
        }
        private void ToMainMenu(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.ToMainMenu();
        }

        private void ToGuide(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.ToGuide();
        }

        private void TakeTreasure(object sender, RoutedEventArgs e)
        {
            var GameManager = this.DataContext as GameManager;
            GameManager.User.Treasures.Add(GameManager.Deck.Treasures.Last());
            GameManager.Deck.Treasures.RemoveAt(GameManager.Deck.Treasures.Count - 1);

            if(GameManager.User.Treasures.Count + GameManager.User.Doors.Count == 1)
            {
                card1.Source = GameManager.User.Treasures.Last().image.Source;
                GameManager.User.Treasures.Last().Cell = card1.Name;
                GameManager.positions[card1.Name] = GameManager.User.Treasures.Last();
            }
            else if (GameManager.User.Treasures.Count + GameManager.User.Doors.Count == 2)
            {
                card2.Source = GameManager.User.Treasures.Last().image.Source;
                GameManager.User.Treasures.Last().Cell = card2.Name;
            }
            else if (GameManager.User.Treasures.Count + GameManager.User.Doors.Count == 3)
            {
                card3.Source = GameManager.User.Treasures.Last().image.Source;
                GameManager.User.Treasures.Last().Cell = card3.Name;
            }
            else if (GameManager.User.Treasures.Count + GameManager.User.Doors.Count == 4)
            {
                card4.Source = GameManager.User.Treasures.Last().image.Source;
                GameManager.User.Treasures.Last().Cell = card4.Name;
            }
            else if (GameManager.User.Treasures.Count + GameManager.User.Doors.Count == 5)
            {
                card5.Source = GameManager.User.Treasures.Last().image.Source;
                GameManager.User.Treasures.Last().Cell = card5.Name;
            }
            else if (GameManager.User.Treasures.Count + GameManager.User.Doors.Count == 6)
            {
                card6.Source = GameManager.User.Treasures.Last().image.Source;
                GameManager.User.Treasures.Last().Cell = card6.Name;
            }
            else if (GameManager.User.Treasures.Count + GameManager.User.Doors.Count == 7)
            {
                card7.Source = GameManager.User.Treasures.Last().image.Source;
                GameManager.User.Treasures.Last().Cell = card7.Name;
            }
            else if (GameManager.User.Treasures.Count + GameManager.User.Doors.Count == 8)
            {
                card8.Source = GameManager.User.Treasures.Last().image.Source;
                GameManager.User.Treasures.Last().Cell = card8.Name;
            }
            else if (GameManager.User.Treasures.Count + GameManager.User.Doors.Count == 9)
            {
                card9.Source = GameManager.User.Treasures.Last().image.Source;
                GameManager.User.Treasures.Last().Cell = card9.Name;
            }
            else if (GameManager.User.Treasures.Count + GameManager.User.Doors.Count == 10)
            {
                card10.Source = GameManager.User.Treasures.Last().image.Source;
                GameManager.User.Treasures.Last().Cell = card10.Name;
            }
        }
        private void TakeDoor(object sender, RoutedEventArgs e)
        {
            var GameManager = this.DataContext as GameManager;
            GameManager.User.Doors.Add(GameManager.Deck.Doors.Last());
            GameManager.Deck.Doors.RemoveAt(GameManager.Deck.Doors.Count - 1);

            if(GameManager.User.Treasures.Count + GameManager.User.Doors.Count == 1)
            {
                card1.Source = GameManager.User.Doors.Last().image.Source;
                GameManager.User.Doors.Last().Cell = card1.Name;
            }
            else if (GameManager.User.Treasures.Count + GameManager.User.Doors.Count == 2)
            {
                card2.Source = GameManager.User.Doors.Last().image.Source;
                GameManager.User.Doors.Last().Cell = card2.Name;
            }
            else if (GameManager.User.Treasures.Count + GameManager.User.Doors.Count == 3)
            {
                card3.Source = GameManager.User.Doors.Last().image.Source;
                GameManager.User.Doors.Last().Cell = card3.Name;
            }
            else if (GameManager.User.Treasures.Count + GameManager.User.Doors.Count == 4)
            {
                card4.Source = GameManager.User.Doors.Last().image.Source;
                GameManager.User.Doors.Last().Cell = card4.Name;
            }
            else if (GameManager.User.Treasures.Count + GameManager.User.Doors.Count == 5)
            {
                card5.Source = GameManager.User.Doors.Last().image.Source;
                GameManager.User.Doors.Last().Cell = card5.Name;
            }
            else if (GameManager.User.Treasures.Count + GameManager.User.Doors.Count == 6)
            {
                card6.Source = GameManager.User.Doors.Last().image.Source;
                GameManager.User.Doors.Last().Cell = card6.Name;
            }
            else if (GameManager.User.Treasures.Count + GameManager.User.Doors.Count == 7)
            {
                card7.Source = GameManager.User.Doors.Last().image.Source;
                GameManager.User.Doors.Last().Cell = card7.Name;
            }
            else if (GameManager.User.Treasures.Count + GameManager.User.Doors.Count == 8)
            {
                card8.Source = GameManager.User.Doors.Last().image.Source;
                GameManager.User.Doors.Last().Cell = card8.Name;
            }
            else if (GameManager.User.Treasures.Count + GameManager.User.Doors.Count == 9)
            {
                card9.Source = GameManager.User.Doors.Last().image.Source;
                GameManager.User.Doors.Last().Cell = card9.Name;
            }
            else if (GameManager.User.Treasures.Count + GameManager.User.Doors.Count == 10)
            {
                card10.Source = GameManager.User.Doors.Last().image.Source;
                GameManager.User.Doors.Last().Cell = card10.Name;
            }
        }
        public void Use(object sender, RoutedEventArgs e)
        {
            MenuItem? item = sender as MenuItem;
            ContextMenu? menu = item.CommandParameter as ContextMenu;
            Image? image = menu.PlacementTarget as Image;
            if(image != null) MessageBox.Show(image.Source + "");

        }
        private void Selected(object sender, MouseButtonEventArgs e)
        {
            Image? image = sender as Image;
            if(image != null)
            {
                var contextMenu = image.ContextMenu;
                contextMenu.IsOpen = true;
            }
        }

        
    }
}
