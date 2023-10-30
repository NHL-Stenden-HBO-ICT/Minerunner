using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.IO;
using System.Windows.Navigation;
using System.Net;

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
