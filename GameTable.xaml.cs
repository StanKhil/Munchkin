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
            //card1.Source = gameManager.User.Treasures.Last().image.Source;

            string fieldName = "card" + (gameManager.User.Treasures.Count - 1); 

            FieldInfo fieldInfo = typeof(Image).GetField(fieldName);

            if (fieldInfo != null)
            {
                MessageBox.Show(gameManager.User.Treasures.Last().image.Source + "");
                fieldInfo.SetValue(card1, gameManager.User.Treasures.Last().image);
            }
        }
        private void TakeDoor(object sender, RoutedEventArgs e)
        {
            var gameManager = this.DataContext as GameManager;
            gameManager.Table.TreasuresHand.Add(gameManager.Deck.Treasures.Last());
            gameManager.Deck.Treasures.RemoveAt(gameManager.Deck.Treasures.Count - 1);
            MessageBox.Show(gameManager.Table.TreasuresHand[0].image.Source + "");
        }
    }
}
