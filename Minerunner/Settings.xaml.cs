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
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
        private void Volume_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
        private void Helderheid_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
        private void Speeltijd_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Speeltijd_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ParentalControl());
        }
    }
}
