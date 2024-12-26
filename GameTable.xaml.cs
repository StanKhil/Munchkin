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
            var gameManager = this.DataContext as GameManager;
            gameManager.User.Treasures.Add(gameManager.Deck.Treasures.Last());
            gameManager.Deck.Treasures.RemoveAt(gameManager.Deck.Treasures.Count - 1);

            if(gameManager.User.Treasures.Count + gameManager.User.Doors.Count == 1)
            {
                card1.Source = gameManager.User.Treasures.Last().image.Source;
            }
            else if (gameManager.User.Treasures.Count + gameManager.User.Doors.Count == 2)
            {
                card2.Source = gameManager.User.Treasures.Last().image.Source;
            }
            else if (gameManager.User.Treasures.Count + gameManager.User.Doors.Count == 3)
            {
                card3.Source = gameManager.User.Treasures.Last().image.Source;
            }
            else if (gameManager.User.Treasures.Count + gameManager.User.Doors.Count == 4)
            {
                card4.Source = gameManager.User.Treasures.Last().image.Source;
            }
            else if (gameManager.User.Treasures.Count + gameManager.User.Doors.Count == 5)
            {
                card5.Source = gameManager.User.Treasures.Last().image.Source;
            }
            else if (gameManager.User.Treasures.Count + gameManager.User.Doors.Count == 6)
            {
                card6.Source = gameManager.User.Treasures.Last().image.Source;
            }
            else if (gameManager.User.Treasures.Count + gameManager.User.Doors.Count == 7)
            {
                card7.Source = gameManager.User.Treasures.Last().image.Source;
            }
            else if (gameManager.User.Treasures.Count + gameManager.User.Doors.Count == 8)
            {
                card8.Source = gameManager.User.Treasures.Last().image.Source;
            }
            else if (gameManager.User.Treasures.Count + gameManager.User.Doors.Count == 9)
            {
                card9.Source = gameManager.User.Treasures.Last().image.Source;
            }
            else if (gameManager.User.Treasures.Count + gameManager.User.Doors.Count == 10)
            {
                card10.Source = gameManager.User.Treasures.Last().image.Source;
            }
        }
        private void TakeDoor(object sender, RoutedEventArgs e)
        {
            var gameManager = this.DataContext as GameManager;
            gameManager.User.Doors.Add(gameManager.Deck.Doors.Last());
            gameManager.Deck.Doors.RemoveAt(gameManager.Deck.Doors.Count - 1);

            if(gameManager.User.Treasures.Count + gameManager.User.Doors.Count == 1)
            {
                card1.Source = gameManager.User.Doors.Last().image.Source;
            }
            else if (gameManager.User.Treasures.Count + gameManager.User.Doors.Count == 2)
            {
                card2.Source = gameManager.User.Doors.Last().image.Source;
            }
            else if (gameManager.User.Treasures.Count + gameManager.User.Doors.Count == 3)
            {
                card3.Source = gameManager.User.Doors.Last().image.Source;
            }
            else if (gameManager.User.Treasures.Count + gameManager.User.Doors.Count == 4)
            {
                card4.Source = gameManager.User.Doors.Last().image.Source;
            }
            else if (gameManager.User.Treasures.Count + gameManager.User.Doors.Count == 5)
            {
                card5.Source = gameManager.User.Doors.Last().image.Source;
            }
            else if (gameManager.User.Treasures.Count + gameManager.User.Doors.Count == 6)
            {
                card6.Source = gameManager.User.Doors.Last().image.Source;
            }
            else if (gameManager.User.Treasures.Count + gameManager.User.Doors.Count == 7)
            {
                card7.Source = gameManager.User.Doors.Last().image.Source;
            }
            else if (gameManager.User.Treasures.Count + gameManager.User.Doors.Count == 8)
            {
                card8.Source = gameManager.User.Doors.Last().image.Source;
            }
            else if (gameManager.User.Treasures.Count + gameManager.User.Doors.Count == 9)
            {
                card9.Source = gameManager.User.Doors.Last().image.Source;
            }
            else if (gameManager.User.Treasures.Count + gameManager.User.Doors.Count == 10)
            {
                card10.Source = gameManager.User.Doors.Last().image.Source;
            }
        }
    }
}
