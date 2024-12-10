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
    }
}