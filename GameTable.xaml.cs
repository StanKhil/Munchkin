using Munchkin.Cards;
using Munchkin.Cards.Doors;
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
        public User user;
        public GameManager gameManager;
        public GameTable()
        {
            InitializeComponent();

            if (this.DataContext == null)
            {
                this.DataContext = new GameManager();
            }
            user = new User();
            user.GameTable = this;

            gameManager = this.DataContext as GameManager;

            if (gameManager != null)
            {
                gameManager.User = user;
            }
            else
            {
                throw new Exception("GameManager не был правильно инициализирован.");
            }
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
        public void ProvideTreasure()
        {
            
            int ind = -1;
            for (int i = 0; i <gameManager.User.Hand.Count; i++)
            {
                if (gameManager.User.Hand[i] == null && ind == -1)
                {
                    ind = i;
                }
            }
            if (ind == -1) ind = gameManager.User.Hand.Count;
            if (ind < gameManager.User.Hand.Count)
            {
                gameManager.User.Hand[ind] = gameManager.Deck.Treasures.Last();
            }
            else
            {
                gameManager.User.Hand.Add(gameManager.Deck.Treasures.Last());
            }
            ChoosePosition(ind + 1);
            gameManager.Deck.Treasures.RemoveAt(gameManager.Deck.Treasures.Count - 1);
        }
        public void ProvideDoor()
        {
            
            int ind = -1;
            for (int i = 0; i < gameManager.User.Hand.Count; i++)
            {
                if (gameManager.User.Hand[i] == null && ind == -1)
                {
                    ind = i;
                }
            }
            if (ind == -1) ind = gameManager.User.Hand.Count;
            if (ind < gameManager.User.Hand.Count)
            {
                gameManager.User.Hand[ind] = gameManager.Deck.Doors.Last();
            }
            else
            {
                gameManager.User.Hand.Add(gameManager.Deck.Doors.Last());
            }
            ChoosePosition(ind + 1);
            gameManager.Deck.Doors.RemoveAt(gameManager.Deck.Doors.Count - 1);
        }
        public void TakeTreasure(object sender, RoutedEventArgs e)
        {
            ProvideTreasure();
        }
        public void TakeDoor(object sender, RoutedEventArgs e)
        {
            ProvideDoor();
        }
        public void Use(object sender, RoutedEventArgs e)
        {

            Image img = null;
            string path="";
            if (sender is MenuItem menuItem && menuItem.Parent is ContextMenu contextMenu)
            {
                var target = contextMenu.PlacementTarget;
                if (target is Image image)
                {
                    path = image.Name;
                    img = image;
                }
            }


            if (gameManager.positions[path] is Treasure)
            {
                if (!gameManager.positions[path].Condition(gameManager.User))
                {
                    MessageBox.Show("You can't use this card");
                    return;
                }

                gameManager.positions[path].Action(gameManager.User);

                int ind = -1;
                for (int i = 0; i < gameManager.User.ActiveTreasures.Count; i++)
                {
                    if (gameManager.User.ActiveTreasures[i] == null && ind == -1)
                    {
                        ind = i;
                    }
                }
                if (ind == -1) ind = gameManager.User.ActiveTreasures.Count;


                if (ind < gameManager.User.ActiveTreasures.Count)
                {
                    gameManager.User.ActiveTreasures[ind] = gameManager.positions[path] as Treasure;
                }
                else
                {
                    gameManager.User.ActiveTreasures.Add(gameManager.positions[path] as Treasure);
                }


                if (ind == 0)
                {
                    active1.Source = gameManager.positions[path].image.Source;
                    gameManager.positions[active1.Name] = gameManager.positions[path];
                }
                else if (ind == 1)
                {
                    active2.Source = gameManager.positions[path].image.Source;
                    gameManager.positions[active2.Name] = gameManager.positions[path];
                }
                else if (ind == 2)
                {
                    active3.Source = gameManager.positions[path].image.Source;
                    gameManager.positions[active3.Name] = gameManager.positions[path];
                }
                else if (ind == 3)
                {
                    active4.Source = gameManager.positions[path].image.Source;
                    gameManager.positions[active4.Name] = gameManager.positions[path];
                }
                else if (ind == 4)
                {
                    active5.Source = gameManager.positions[path].image.Source;
                    gameManager.positions[active5.Name] = gameManager.positions[path];
                }
                else if (ind == 5)
                {
                    active6.Source = gameManager.positions[path].image.Source;
                    gameManager.positions[active6.Name] = gameManager.positions[path];
                }
                else if (ind == 6)
                {
                    active7.Source = gameManager.positions[path].image.Source;
                    gameManager.positions[active7.Name] = gameManager.positions[path];
                }
            }

            else if (gameManager.positions[path] is Monster)
            {
                /*if (!gameManager.positions[path].Condition(gameManager.User))
                {
                    MessageBox.Show("You can't use this card");
                    return;
                }
                gameManager.positions[path].Action(gameManager.User);*/

                gameManager.positions[monster.Name] = gameManager.positions[path];
                monster.Source = gameManager.positions[path].image.Source;
            }

            else if (gameManager.positions[path] is PlayerRace)
            {
                if (gameManager.positions[path].Name == "HalfBreed")
                {
                    gameManager.User.IsHalfBlood = true;
                    halfBlood.Source = gameManager.positions[path].image.Source;
                    gameManager.positions[halfBlood.Name] = gameManager.positions[path];
                }
                else if (gameManager.positions[path].Name == "SuperMunchkin")
                {
                    gameManager.User.IsSuperMunchkin = true;
                    supermunchkin.Source = gameManager.positions[path].image.Source;
                    gameManager.positions[supermunchkin.Name] = gameManager.positions[path];
                }
                else
                {
                    if (gameManager.positions[race1.Name] == null)
                    {
                        gameManager.positions[race1.Name] = gameManager.positions[path];
                        race1.Source = gameManager.positions[path].image.Source;
                    }
                    else if (gameManager.positions[race2.Name] == null)
                    {
                        gameManager.positions[race2.Name] = gameManager.positions[path];
                        race2.Source = gameManager.positions[path].image.Source;
                    }
                    else
                    {
                        MessageBox.Show("You can't use this card");
                        return;
                    }
                }

            }

            else if (gameManager.positions[path] is PlayerClass)
            {
                if (gameManager.positions[path].Name == "Supermunchkin")
                {
                    gameManager.User.IsSuperMunchkin = true;
                    supermunchkin.Source = gameManager.positions[path].image.Source;
                    gameManager.positions[supermunchkin.Name] = gameManager.positions[path];
                }
                else
                {
                    if (gameManager.positions[class1.Name] == null)
                    {
                        gameManager.positions[class1.Name] = gameManager.positions[path];
                        class1.Source = gameManager.positions[path].image.Source;
                    }
                    else if (gameManager.positions[class2.Name] == null)
                    {
                        gameManager.positions[class2.Name] = gameManager.positions[path];
                        class2.Source = gameManager.positions[path].image.Source;
                    }
                    else
                    {
                        MessageBox.Show("You can't use this card");
                        return;
                    }
                }
            }


            img.Source = null;
            int index = Convert.ToInt32(path.Last()) - '0' - 1;
            gameManager.positions[path] = null;
            if (path[0] == 'c') gameManager.User.Hand[index] = null;
            else if (path[0] == 'a') gameManager.User.ActiveTreasures[index] = null;
        }
        private void Selected(object sender, MouseButtonEventArgs e)
        {
            if (sender is Image image)
            {
                var contextMenu = image.ContextMenu;
                if (contextMenu != null)
                {
                    contextMenu.PlacementTarget = image;
                    contextMenu.IsOpen = true;
                }
            }
        }

        /*private void CardContextMenu_Opened(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(sender.GetType()+"");
            if (sender is ContextMenu contextMenu)
            {
                MessageBox.Show(contextMenu.PlacementTarget.ToString());
                //MessageBox.Show(contextMenu.PlacementTarget.GetType()+"");
                var image = contextMenu.PlacementTarget as Image;
                if (image == null && contextMenu.PlacementTarget is Border border)
                {
                    image = border.Child as Image; 
                }

                if (image != null)
                {
                    MessageBox.Show($"Контекстное меню открыто для: {image.Name}");
                }
                else
                {
                    MessageBox.Show("Контекстное меню не связано с элементом Image.");
                }
            }
        }*/

        private int ChoosePosition(int ind)
        {
            if (ind == 1)
            {
                card1.Source = gameManager.User.Hand[ind-1].image.Source;
                gameManager.positions[card1.Name] = gameManager.User.Hand[ind - 1];
            }
            else if (ind == 2)
            {
                card2.Source = gameManager.User.Hand[ind - 1].image.Source;
                gameManager.positions[card2.Name] = gameManager.User.Hand[ind - 1];
            }
            else if (ind == 3)
            {
                card3.Source = gameManager.User.Hand[ind - 1].image.Source;
                gameManager.positions[card3.Name] = gameManager.User.Hand[ind - 1];
            }
            else if (ind == 4)
            {
                card4.Source = gameManager.User.Hand[ind - 1].image.Source;
                gameManager.positions[card4.Name] = gameManager.User.Hand[ind - 1];
            }
            else if (ind == 5)
            {
                card5.Source = gameManager.User.Hand[ind - 1].image.Source;
                gameManager.positions[card5.Name] = gameManager.User.Hand[ind - 1];
            }
            else if (gameManager.User.Hand.Count == 6)
            {
                card6.Source = gameManager.User.Hand[ind - 1].image.Source;
                gameManager.positions[card6.Name] = gameManager.User.Hand[ind - 1];
            }
            else if (ind == 7)
            {
                card7.Source = gameManager.User.Hand[ind - 1].image.Source;
                gameManager.positions[card7.Name] = gameManager.User.Hand[ind - 1];
            }
            else if (ind == 8)
            {
                card8.Source = gameManager.User.Hand[ind - 1].image.Source;
                gameManager.positions[card8.Name] = gameManager.User.Hand[ind - 1];
            }
            else if (ind == 9)
            {
                card9.Source = gameManager.User.Hand[ind - 1].image.Source;
                gameManager.positions[card9.Name] = gameManager.User.Hand[ind - 1];
            }
            else if (ind == 10)
            {
                card10.Source = gameManager.User.Hand[ind - 1].image.Source;
                gameManager.positions[card10.Name] = gameManager.User.Hand[ind - 1];
            }
            
            return ind;
        }
    }
}
