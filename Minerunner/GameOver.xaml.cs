using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Minerunner
{
    public partial class GameOverPage : Page
    {
        public GameOverPage()
        {
            InitializeComponent();
        }

        private void Replay_BTN_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Gamescreen());
        }

        private void Backtomainmenu_BTN_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Titlescreen());
        }
    }
}
