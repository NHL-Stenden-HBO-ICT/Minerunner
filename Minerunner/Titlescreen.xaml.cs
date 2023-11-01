using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.IO;
using System.Windows.Navigation;
using System.Net;
using static System.Formats.Asn1.AsnWriter;

namespace Minerunner
{
    /// <summary>
    /// Interaction logic for Titlescreen.xaml
    /// </summary>
    public partial class Titlescreen : Page
    {
        MediaPlayer musicPlayer = new MediaPlayer();
        Uri uri = new Uri("assets/music/Sweden-C418.mp3", UriKind.Relative);

        public Titlescreen()
        {
            InitializeComponent();
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;

            double sizeMultiplier = Math.Min(screenWidth / 1920, screenHeight / 1080); // Stel de basisresolutie in op 1920x1080

            Titleminerunner.FontSize = 70 * sizeMultiplier; // Pas de lettergrootte van de tekst "Game Over" aan
            StartKNP.FontSize = 20 * sizeMultiplier;
            HighscoreKNP.FontSize = 20 * sizeMultiplier;
            InstellingenKNP.FontSize = 20 * sizeMultiplier;



            IntroBackground.Height = 1080 * sizeMultiplier; // Pas de hoogte van de knoppen aan
            IntroBackground.Width = 1920 * sizeMultiplier; // Pas de breedte van de knoppen aan
            IntroImage.Height = 500 * sizeMultiplier;
            IntroImage.Width = 500 * sizeMultiplier;

            StartKNP.Height = 75 * sizeMultiplier; // Pas de hoogte van de knoppen aan
            StartKNP.Width = 300 * sizeMultiplier; // Pas de breedte van de knoppen aan
            HighscoreKNP.Height = 75 * sizeMultiplier;
            HighscoreKNP.Width = 300 * sizeMultiplier;
            InstellingenKNP.Height = 75 * sizeMultiplier; // Pas de hoogte van de knoppen aan
            InstellingenKNP.Width = 300 * sizeMultiplier; // Pas de breedte van de knoppen aan
            
            xKNP.Height = 20 * sizeMultiplier; // Pas de hoogte van de knoppen aan
            xKNP.Width = 20 * sizeMultiplier; // Pas de breedte van de knoppen aan

            // Only load MusicPlayer once
            if (App.Loaded == false)
            {
                var tempFilePath = System.IO.Path.GetTempFileName();
                tempFilePath = System.IO.Path.ChangeExtension(tempFilePath, System.IO.Path.GetExtension(uri.OriginalString));

                var stream = Application.GetResourceStream(uri).Stream;
                var fileStream = File.Create(tempFilePath);
                stream.CopyTo(fileStream);
                fileStream.Close();

                this.musicPlayer.Open(new Uri(tempFilePath));
                this.musicPlayer.Play();

                App.Loaded = true;
            }
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Gamescreen(musicPlayer));
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Settings(musicPlayer));
        }

        private void Highscores_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Highscore());
        }
    }
}
