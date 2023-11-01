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
        MediaPlayer player = new MediaPlayer();

        public Settings(MediaPlayer musicPlayer = null)
        {
            InitializeComponent();

            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;

            double sizeMultiplier = Math.Min(screenWidth / 1920, screenHeight / 1080); // Stel de basisresolutie in op 1920x1080

            Instellingentekst.FontSize = 70 * sizeMultiplier; // Pas de lettergrootte van de tekst "Instellingen" aan
            Volumelabel.FontSize = 20 * sizeMultiplier;
            Speeltijdknop.FontSize = 20 * sizeMultiplier;

            Rectangle1.Height = 75 * sizeMultiplier; // Pas de hoogte van de knoppen aan
            Rectangle1.Width = 300 * sizeMultiplier; // Pas de breedte van de knoppen aan

            Volume.Height = 25 * sizeMultiplier; // Pas de hoogte van de knoppen aan
            Volume.Width = 250 * sizeMultiplier; // Pas de breedte van de knoppen aan

            Speeltijdknop.Height = 75 * sizeMultiplier; // Pas de hoogte van de knoppen aan
            Speeltijdknop.Width = 300 * sizeMultiplier; // Pas de breedte van de knoppen aan

            Backknop.Height = 20 * sizeMultiplier; // Pas de hoogte van de knoppen aan
            Backknop.Width = 20 * sizeMultiplier; // Pas de breedte van de knoppen aan


            this.player = musicPlayer;

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
            player.Volume = Volumeamount;
        }
    }
}
