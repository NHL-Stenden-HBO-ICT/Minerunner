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
    public partial class GameOverPage : Page
    {

        private double score;
        public GameOverPage(double score)
        {

            InitializeComponent();
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;
            this.score = score;

            double sizeMultiplier = Math.Min(screenWidth / 1920, screenHeight / 1080); // Stel de basisresolutie in op 1920x1080

            gameover_TXT.FontSize = 50 * sizeMultiplier; // Pas de lettergrootte van de tekst "Game Over" aan
            Highscore_TXT.FontSize = 20 * sizeMultiplier; // Pas de lettergrootte van de tekst "Highscore" aan

            Replay_BTN.Height = 40 * sizeMultiplier; // Pas de hoogte van de knoppen aan
            Replay_BTN.Width = 200 * sizeMultiplier; // Pas de breedte van de knoppen aan

            Backtomainmenu_BTN.Height = 40 * sizeMultiplier; // Pas de hoogte van de knoppen aan
            Backtomainmenu_BTN.Width = 200 * sizeMultiplier; // Pas de breedte van de knoppen aan

            Highscore_TXT.Content = "Score: " + Convert.ToString(score);



        }

        private void Backtomainmenu_BTN_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Titlescreen());
        }

        private void Replay_BTN_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Gamescreen());
        }
    }  

}
