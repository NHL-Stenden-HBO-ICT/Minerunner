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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Highscore : Page
    {
        public Highscore()
        {
            InitializeComponent();
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;

            double sizeMultiplier = Math.Min(screenWidth / 1920, screenHeight / 1080); // Stel de basisresolutie in op 1920x1080

            Highscore_titel.FontSize = 60 * sizeMultiplier; // Pas de lettergrootte van de tekst "Game Over" aan
            Dylanscore.FontSize = 20 * sizeMultiplier;
            Frearkscore.FontSize = 20 * sizeMultiplier;
            Maxscore.FontSize = 20 * sizeMultiplier;
            Onurcanscore.FontSize = 20 * sizeMultiplier;
            Larsscore.FontSize = 20 * sizeMultiplier;
            Eelkescore.FontSize = 20 * sizeMultiplier;
            persoonlijke_Highscore.FontSize = 16 * sizeMultiplier;
            terugKnop.FontSize = 20 * sizeMultiplier;


            terugKnop.Height = 75 * sizeMultiplier; // Pas de hoogte van de knoppen aan
            terugKnop.Width = 300 * sizeMultiplier; // Pas de breedte van de knoppen aan
        }

        private void Highscore_Terug(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
