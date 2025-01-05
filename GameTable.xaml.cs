using Munchkin.Cards;
using Munchkin.Cards.Doors;
using Munchkin.Cards.Treasures;
using Munchkin.Player;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Munchkin
{
    public partial class GameTable : UserControl, INotifyPropertyChanged
    {
        public User user;
        public GameManager? gameManager;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public User User
        {
            get => user;
            set
            {
                user = value;
                OnPropertyChanged(nameof(User));
            }
        }
        public GameTable()
        {
            InitializeComponent();

            if (this.DataContext == null)
            {
                this.DataContext = new GameManager();
            }

            gameManager = this.DataContext as GameManager;
            gameManager.Table = this;

            user = new User(gameManager);
            user.GameTable = this;

            if (gameManager != null)
            {
                gameManager.User = user;
            }
            else
            {
                throw new Exception("GameManager не был правильно инициализирован.");
            }
        }

        public void ToMainMenu(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.ToMainMenu();
        }

        private void ToGuide(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.ToGuide();
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
        public void SeekAddPosition(string? path)
        {
            switch (path)
            {
                case "card1":
                    card1.Source = gameManager.positions[path].Image.Source;
                    break;
                case "card2":
                    card2.Source = gameManager.positions[path].Image.Source;
                    break;
                case "card3":
                    card3.Source = gameManager.positions[path].Image.Source;
                    break;
                case "card4":
                    card4.Source = gameManager.positions[path].Image.Source;
                    break;
                case "card5":
                    card5.Source = gameManager.positions[path].Image.Source;
                    break;
                case "card6":
                    card6.Source = gameManager.positions[path].Image.Source;
                    break;
                case "card7":
                    card7.Source = gameManager.positions[path].Image.Source;
                    break;
                case "card8":
                    card8.Source = gameManager.positions[path].Image.Source;
                    break;
                case "card9":
                    card9.Source = gameManager.positions[path].Image.Source;
                    break;
                case "card10":
                    card10.Source = gameManager.positions[path].Image.Source;
                    break;
            }
        }
        public void ProvideTreasure()
        {
            if (user.Hand.Count == 10)
            {
                MessageBox.Show("You cannot take more cards");
                return;
            }
            if(gameManager.Deck.Treasures.Count == 0)
            {
                gameManager.Deck.UpdateTreasures();
            }

            int cardNumber = new Random().Next(0, gameManager.Deck.Treasures.Count);
            Card card = gameManager.Deck.Treasures[cardNumber];
            gameManager.Deck.Treasures.RemoveAt(cardNumber);

            string path = "";
            foreach (var position in gameManager.positions)
            {
                if (position.Value == null)
                {
                    path = position.Key;
                    break;
                }
            }
            gameManager.positions[path] = card;
            user.Hand.Add(card);
            SeekAddPosition(path);

            gameManager.treasuresToTake--;
        }
        public void ProvideTreasureDiscard()
        {
            if (user.FirstClass != Class.Cleric && user.SecondClass != Class.Cleric) return;
            if (gameManager.discardTreasures.Count == 0) return;
            if (user.Hand.Count == 10)
            {
                MessageBox.Show("You cannot take more cards");
                return;
            }
            int cardNumber = new Random().Next(0, gameManager.discardTreasures.Count);
            Card card = gameManager.discardTreasures[cardNumber];
            gameManager.discardTreasures.RemoveAt(cardNumber);

            string path = "";
            foreach (var position in gameManager.positions)
            {
                if (position.Value == null)
                {
                    path = position.Key;
                    break;
                }
            }
            gameManager.positions[path] = card;
            user.Hand.Add(card);
            SeekAddPosition(path);

            gameManager.treasuresToTake--;
        }
        public void ProvideDoor()
        {
            if (gameManager.Stadia == Stadia.OpenDoors)
            {
                gameManager.LastCalledMethod = "OpenDoor";
                return;
            }
            if (user.Hand.Count == 10)
            {
                MessageBox.Show("You cannot take more cards");
                return;
            }

            if (gameManager.Deck.Doors.Count == 0)
            {
                gameManager.Deck.UpdateDoors();
            }

            int cardNumber = new Random().Next(0, gameManager.Deck.Doors.Count);
            Card selectedCard = gameManager.Deck.Doors[cardNumber];
            gameManager.Deck.Doors.RemoveAt(cardNumber);

            string path = "";
            foreach (var position in gameManager.positions)
            {
                if (position.Value == null)
                {
                    path = position.Key;
                    break;
                }
            }
            gameManager.LastCalledMethod = "ProvideDoor";
            gameManager.positions[path] = selectedCard;
            user.Hand.Add(selectedCard);
            SeekAddPosition(path);

            gameManager.doorsToOpen--;
        }
        public void ProvideDoorDiscard()
        {
            if (user.FirstClass != Class.Cleric && user.SecondClass != Class.Cleric) return;
            if (gameManager.discardDoors.Count == 0) return;
            if (gameManager.Stadia == Stadia.OpenDoors)
            {
                gameManager.LastCalledMethod = "OpenDoor";
                return;
            }
            if (user.Hand.Count == 10)
            {
                MessageBox.Show("You cannot take more cards");
                return;
            }

            if (gameManager.Deck.Doors.Count == 0)
            {
                gameManager.Deck.UpdateDoors();
            }

            int cardNumber = new Random().Next(0, gameManager.discardDoors.Count);
            Card selectedCard = gameManager.discardDoors[cardNumber];
            gameManager.discardDoors.RemoveAt(cardNumber);

            string path = "";
            foreach (var position in gameManager.positions)
            {
                if (position.Value == null)
                {
                    path = position.Key;
                    break;
                }
            }
            gameManager.LastCalledMethod = "ProvideDoor";
            gameManager.positions[path] = selectedCard;
            user.Hand.Add(selectedCard);
            SeekAddPosition(path);

            gameManager.doorsToOpen--;
        }
        private void TakeTreasureDiscard(object sender, MouseButtonEventArgs e)
        {
            if (gameManager.treasuresToTake != 0) ProvideTreasureDiscard();
        }
        private void TakeDoorDiscard(object sender, MouseButtonEventArgs e)
        {
            if (gameManager.doorsToOpen != 0) ProvideDoorDiscard();
        }
        public void TakeTreasure(object sender, RoutedEventArgs e)
        {
            if (gameManager.treasuresToTake != 0) ProvideTreasure();
        }
        public void TakeDoor(object sender, RoutedEventArgs e)
        {
            if (gameManager.doorsToOpen != 0) ProvideDoor();
        }
        public void Use(object sender, RoutedEventArgs e)
        {
            Image img = null;
            string path = "";
            if (sender is MenuItem menuItem && menuItem.Parent is ContextMenu contextMenu)
            {
                var target = contextMenu.PlacementTarget;
                if (target is Image image)
                {
                    path = image.Name;
                    img = image;
                }
            }

            //-----------------------------------------------

            Card selectedCard = gameManager.positions[path];
            if (selectedCard.Condition != null && !selectedCard.Condition(user))
            {
                MessageBox.Show("You can't use this card");
                return;
            }
            else if(selectedCard is Monster && gameManager.Stadia != Stadia.Choice)
            {
                MessageBox.Show("You can't use this card");
                return;
            }
            else
            {
                if (selectedCard is Monster)
                {
                    gameManager.LastCalledMethod = "Use";
                    gameManager.CurrentMonster = selectedCard as Monster;
                }
                selectedCard.Action(user);
            }
            switch (path)
            {
                case "card1":
                    card1.Source = null;
                    break;
                case "card2":
                    card2.Source = null;
                    break;
                case "card3":
                    card3.Source = null;
                    break;
                case "card4":
                    card4.Source = null;
                    break;
                case "card5":
                    card5.Source = null;
                    break;
                case "card6":
                    card6.Source = null;
                    break;
                case "card7":
                    card7.Source = null;
                    break;
                case "card8":
                    card8.Source = null;
                    break;
                case "card9":
                    card9.Source = null;
                    break;
                case "card10":
                    card10.Source = null;
                    break;
            }
            gameManager.UsedCard = selectedCard;
            gameManager.positions[path] = null;
            user.Hand.Remove(selectedCard);

        }

        public void Discard(object sender, RoutedEventArgs e)
        {
            gameManager.LastCalledMethod = "Discard";
            Image? img = null;
            string path = "";
            if (sender is MenuItem menuItem && menuItem.Parent is ContextMenu contextMenu)
            {
                var target = contextMenu.PlacementTarget;
                if (target is Image image)
                {
                    path = image.Name;
                    img = image;
                }
            }
            img.Source = null;
            Card card = gameManager.positions[path];
            if (!path.Contains("card") && card != null)
            {
                if (card.Discard != null) card.Discard(user);
            }
            gameManager.positions[path] = null;
            if(card is Treasure)
            {
                gameManager.discardTreasures.Add(card as Treasure);
            }
            else if(card is Door)
            {
                gameManager.discardDoors.Add(card as Door);
            }

            if(gameManager.Stadia == Stadia.Battle && (user.FirstClass == Class.Warrior || user.SecondClass == Class.Warrior))
            {
                user.Discarded++;
                user.Power += user.Discarded / 3;
            }
            if (gameManager.Stadia == Stadia.Battle && (user.FirstClass == Class.Wizard || user.SecondClass == Class.Wizard)) user.Discarded++;

            user.Hand.Remove(card);
            if((user.FirstClass == Class.Wizard || user.SecondClass == Class.Wizard) && user.Hand.Count == 0 && user.Discarded >= 3)
            {
                gameManager.Tips = "You charmed the\nmonster";
                gameManager.treasuresToTake = gameManager.CurrentMonster.Treasusers;
                fightPanel.Visibility = Visibility.Hidden;
                gameManager.discardDoors.Add(gameManager.CurrentMonster);
                gameManager.CurrentMonster = null;
                monster.Source = null;
                gameManager.positions["monster"] = null;
                gameManager.Stadia = Stadia.TakeTreasures;
            }
        }

        public void Sell(object sender, RoutedEventArgs e)
        {
            string path = "";
            if (sender is MenuItem menuItem && menuItem.Parent is ContextMenu contextMenu)
            {
                var target = contextMenu.PlacementTarget;
                if (target is Image image)
                {
                    path = image.Name;
                }
            }
            if (gameManager.positions[path] is Treasure && user.Level != 9)
            {
                user.Money += (gameManager.positions[path] as Treasure).Price;
                if((user.FirstRace == Race.Hafling || user.SecondRace == Race.Hafling) && user.SellDoublePrice)
                {
                    user.Money += (gameManager.positions[path] as Treasure).Price;
                    user.SellDoublePrice = false;
                }
                user.Level += (user.Money) / 1000;
                user.Money %= 1000;
                Discard(sender, e);
            }
            else
            {
                MessageBox.Show("You can't sell this card");
            }
        }

        private void Fight(object sender, RoutedEventArgs e)
        {
            gameManager.LastCalledMethod = "Fight";
            //User.Fight(gameManager.CurrentMonster);
        }

        private void Roll(object sender, RoutedEventArgs e)
        {
            gameManager.LastCalledMethod = "Roll";
        }

        private void Flee(object sender, RoutedEventArgs e)
        {
            gameManager.LastCalledMethod = "Flee";
        }

        
    }
}
