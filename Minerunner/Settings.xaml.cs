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
        Uri uri = new Uri("assets/music/Sweden-C418.mp3", UriKind.Relative);

        public Settings()
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
