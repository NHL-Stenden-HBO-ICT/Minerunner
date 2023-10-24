using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
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
using System.IO;

namespace Minerunner
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        private MediaPlayer musicPlayer = new MediaPlayer();

        public Settings(MediaPlayer musicPlayer = null)
        {
            InitializeComponent();

            this.musicPlayer = musicPlayer;

            double Volumeamount = musicPlayer.Volume;
            Volume.Value = Volumeamount;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Speeltijd_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ParentalControl());
        }

        private void Helderheid_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Volumeslider(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double Volumeamount = Volume.Value;
            musicPlayer.Volume = Volumeamount;
        }
    }
}
