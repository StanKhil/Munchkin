using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            sceneContainer.Content = new MainMenu();
        }
        public void ToMainMenu()
        {
            sceneContainer.Content = new MainMenu();
        }
        public void ToGame()
        {
            sceneContainer.Content = new GameTable();
        }
        public void ToGuide()
        {
            sceneContainer.Content = new Guide();
        }

        private void ToMainMenuCommand(object sender, ExecutedRoutedEventArgs e)
        {
            sceneContainer.Content = new MainMenu();
        }
        private void ToGuideCommand(object sender, ExecutedRoutedEventArgs e)
        {
            sceneContainer.Content = new Guide();
        }
        private void ExitCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (sceneContainer.Content.ToString() == "Munchkin.MainMenu") e.CanExecute = false;
            else e.CanExecute = true;
            return;
        }
    }
    public class NavigationCommands
    {
        public static RoutedCommand Exit { get; set; }
        public static RoutedCommand Info { get; set; }
        static NavigationCommands()
        {
            Exit = new RoutedCommand("Exit", typeof(NavigationCommands));
            Info = new RoutedCommand("Info", typeof(NavigationCommands));
        }
    }
}