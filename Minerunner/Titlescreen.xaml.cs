﻿using System;
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
using System.IO;

namespace Minerunner
{
    /// <summary>
    /// Interaction logic for Titlescreen.xaml
    /// </summary>
    public partial class Titlescreen : Page
    {

        MediaPlayer player = new MediaPlayer();
        Uri uri = new Uri("assets/music/Thirteen-C418.mp3", UriKind.Relative);

        public Titlescreen()
        {
            InitializeComponent();

            var tempFilePath = System.IO.Path.GetTempFileName();
            tempFilePath = System.IO.Path.ChangeExtension(tempFilePath, System.IO.Path.GetExtension(uri.OriginalString));

            var stream = Application.GetResourceStream(uri).Stream;
            var fileStream = File.Create(tempFilePath);
            stream.CopyTo(fileStream);
            fileStream.Close();

            player.Open(new Uri(tempFilePath));
            player.Play();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Gamescreen());
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Settings(player));
        }

        private void Highscores_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Highscore());
        }
    }
}
