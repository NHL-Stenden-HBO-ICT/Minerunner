using System;
using System.IO;
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
        private string Pincodefile = "pincode.txt"; // Naam van het bestand
        private string Pincode;
        public ParentalControl()
        {

            LadenPincode(); // Probeer de pincode te laden wanneer het scherm wordt geopend
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

        private void LadenPincode()
        {
            if (File.Exists(Pincodefile))
            {
                Pincode = File.ReadAllText(Pincodefile);
            }
            else
            {
                Pincode = null; // Er is nog geen pincode opgeslagen
            }
        }
        private void Backspace_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Gereed_Click(object sender, RoutedEventArgs e)
        {
            string ingevoerdePincode = PWB_1.Password;

            if (ingevoerdePincode.Length == 4)
            {
                if (Pincode == null)
                {
                    // Er is geen eerder opgeslagen pincode, sla de ingevoerde pincode op
                    Pincode = ingevoerdePincode;
                    File.WriteAllText(Pincode, ingevoerdePincode);
                    MessageBox.Show("Pincode ingesteld", "Succes");
                    this.NavigationService.Navigate(new ParentalTime());
                }
                else
                {
                    // Controleer of de ingevoerde pincode overeenkomt met de opgeslagen pincode
                    if (ingevoerdePincode == Pincode)
                    {
                        MessageBox.Show("Pincode correct", "Succes");
                        this.NavigationService.Navigate(new ParentalTime());
                    }
                    else
                    {
                        MessageBox.Show("Onjuiste pincode", "Fout");
                    }
                }
            }
            else
            {
                MessageBox.Show("Pincode moet 4 tekens bevatten", "Fout");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
