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
    /// Interaction logic for ParentalControl.xaml
    /// </summary>
    public partial class ParentalControl : Page
    {
        string pincode = "";
        string[] testing = new string[4];
        int Maxpin = 0;

        

        public ParentalControl()
        {
            InitializeComponent();
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;

            double sizeMultiplier = Math.Min(screenWidth / 1920, screenHeight / 1080); // Stel de basisresolutie in op 1920x1080

            Title.FontSize = 60 * sizeMultiplier; // Pas de lettergrootte van de tekst "Game Over" aan

            Gereed.Height = 40 * sizeMultiplier; // Pas de hoogte van de knoppen aan
            Gereed.Width = 100 * sizeMultiplier; // Pas de breedte van de knoppen aan

            Back.Height = 30 * sizeMultiplier; // Pas de hoogte van de knoppen aan
            Back.Width = 50 * sizeMultiplier; // Pas de breedte van de knoppen aan

            Backspace.Height = 40 * sizeMultiplier; // Pas de hoogte van de knoppen aan
            Backspace.Width = 100 * sizeMultiplier; // Pas de breedte van de knoppen aan

            PWB_1.Height = 40 * sizeMultiplier; // Pas de hoogte van de knoppen aan
            PWB_1.Width = 200 * sizeMultiplier; // Pas de breedte van de knoppen aan

        }

        private void Backspace_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Gereed_Click(object sender, RoutedEventArgs e)
        {
            if (Maxpin == 4)
            {
                this.NavigationService.Navigate(new ParentalTime());
            }

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        void PasswordChangedHandler(Object sender, RoutedEventArgs args)
        {
            // Increment a counter each time the event fires.
                string Input = PWB_1.Password.ToString();
                pincode = Input;
                Maxpin++;
                 
        }
    }
}
