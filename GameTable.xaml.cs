﻿using Munchkin.Cards;
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
            int ind = -1;
            for (int i = 0; i < GameManager.User.Hand.Count; i++)
            {
                if (GameManager.User.Hand[i] == null && ind == -1)
                {
                    ind = i;
                }
            }
            if (ind == -1) ind = GameManager.User.Hand.Count;
            if (ind < GameManager.User.Hand.Count)
            {
                GameManager.User.Hand[ind] = GameManager.Deck.Treasures.Last();
            }
            else
            {
                GameManager.User.Hand.Add(GameManager.Deck.Treasures.Last());
            }
            ChoosePosition(ind+1);
            GameManager.Deck.Treasures.RemoveAt(GameManager.Deck.Treasures.Count - 1);
        }
        private void TakeDoor(object sender, RoutedEventArgs e)
        {
            var GameManager = this.DataContext as GameManager;
            int ind = -1;
            for (int i = 0; i < GameManager.User.Hand.Count; i++)
            {
                if (GameManager.User.Hand[i] == null && ind == -1)
                {
                    ind = i;
                }
            }
            if (ind == -1) ind = GameManager.User.Hand.Count;
            if (ind < GameManager.User.Hand.Count)
            {
                GameManager.User.Hand[ind] = GameManager.Deck.Doors.Last();
            }
            else
            {
                GameManager.User.Hand.Add(GameManager.Deck.Doors.Last());
            }
            ChoosePosition(ind + 1);
            GameManager.Deck.Doors.RemoveAt(GameManager.Deck.Doors.Count - 1);
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
            var GameManager = this.DataContext as GameManager;
            
            img.Source = null;
            int index = Convert.ToInt32(path.Last()) - '0' -1;
            //MessageBox.Show(index + "");
            GameManager.User.Hand[index] = null;
            if (GameManager.positions[path] is Treasure)
            {
                if (GameManager.User.ActiveTreasures.Count == 0)
                {
                    GameManager.User.ActiveTreasures.Add(GameManager.positions[path] as Treasure);
                    active1.Source = GameManager.positions[path].image.Source;
                    GameManager.positions[active1.Name] = GameManager.positions[path];
                }
                else if(GameManager.User.ActiveTreasures.Count == 1)
                {
                    GameManager.User.ActiveTreasures.Add(GameManager.positions[path] as Treasure);
                    active2.Source = GameManager.positions[path].image.Source;
                    GameManager.positions[active2.Name] = GameManager.positions[path];
                }
                else if (GameManager.User.ActiveTreasures.Count == 2)
                {
                    GameManager.User.ActiveTreasures.Add(GameManager.positions[path] as Treasure);
                    active3.Source = GameManager.positions[path].image.Source;
                    GameManager.positions[active3.Name] = GameManager.positions[path];
                }
                else if (GameManager.User.ActiveTreasures.Count == 3)
                {
                    GameManager.User.ActiveTreasures.Add(GameManager.positions[path] as Treasure);
                    active4.Source = GameManager.positions[path].image.Source;
                    GameManager.positions[active4.Name] = GameManager.positions[path];
                }
                else if (GameManager.User.ActiveTreasures.Count == 4)
                {
                    GameManager.User.ActiveTreasures.Add(GameManager.positions[path] as Treasure);
                    active5.Source = GameManager.positions[path].image.Source;
                    GameManager.positions[active5.Name] = GameManager.positions[path];
                }
                else if (GameManager.User.ActiveTreasures.Count == 5)
                {
                    GameManager.User.ActiveTreasures.Add(GameManager.positions[path] as Treasure);
                    active6.Source = GameManager.positions[path].image.Source;
                    GameManager.positions[active6.Name] = GameManager.positions[path];
                }
                else if (GameManager.User.ActiveTreasures.Count == 6)
                {
                    GameManager.User.ActiveTreasures.Add(GameManager.positions[path] as Treasure);
                    active7.Source = GameManager.positions[path].image.Source;
                    GameManager.positions[active7.Name] = GameManager.positions[path];
                }
            }
            GameManager.positions[path] = null;
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
            var GameManager = this.DataContext as GameManager;
            if (ind == 1)
            {
                card1.Source = GameManager.User.Hand[ind-1].image.Source;
                GameManager.positions[card1.Name] = GameManager.User.Hand[ind - 1];
            }
            else if (ind == 2)
            {
                card2.Source = GameManager.User.Hand[ind - 1].image.Source;
                GameManager.positions[card2.Name] = GameManager.User.Hand[ind - 1];
            }
            else if (ind == 3)
            {
                card3.Source = GameManager.User.Hand[ind - 1].image.Source;
                GameManager.positions[card3.Name] = GameManager.User.Hand[ind - 1];
            }
            else if (ind == 4)
            {
                card4.Source = GameManager.User.Hand[ind - 1].image.Source;
                GameManager.positions[card4.Name] = GameManager.User.Hand[ind - 1];
            }
            else if (ind == 5)
            {
                card5.Source = GameManager.User.Hand[ind - 1].image.Source;
                GameManager.positions[card5.Name] = GameManager.User.Hand[ind - 1];
            }
            else if (GameManager.User.Hand.Count == 6)
            {
                card6.Source = GameManager.User.Hand[ind - 1].image.Source;
                GameManager.positions[card6.Name] = GameManager.User.Hand[ind - 1];
            }
            else if (ind == 7)
            {
                card7.Source = GameManager.User.Hand[ind - 1].image.Source;
                GameManager.positions[card7.Name] = GameManager.User.Hand[ind - 1];
            }
            else if (ind == 8)
            {
                card8.Source = GameManager.User.Hand[ind - 1].image.Source;
                GameManager.positions[card8.Name] = GameManager.User.Hand[ind - 1];
            }
            else if (ind == 9)
            {
                card9.Source = GameManager.User.Hand[ind - 1].image.Source;
                GameManager.positions[card9.Name] = GameManager.User.Hand[ind - 1];
            }
            else if (ind == 10)
            {
                card10.Source = GameManager.User.Hand[ind - 1].image.Source;
                GameManager.positions[card10.Name] = GameManager.User.Hand[ind - 1];
            }
            
            return ind;
        }
    }
}
