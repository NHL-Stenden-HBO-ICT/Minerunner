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
using System.Windows.Threading;

namespace Minerunner
{
    public partial class ParentalTime : Page
    {
        private int hours = 0;
        private int minutes = 0;
        private int seconds = 0;
        private readonly DispatcherTimer Timer;
        private bool timerRunning = false;

        public ParentalTime()
        {
            InitializeComponent();
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;

            double sizeMultiplier = Math.Min(screenWidth / 1920, screenHeight / 1080); // Stel de basisresolutie in op 1920x1080

            Title_time.FontSize = 60 * sizeMultiplier; // Pas de lettergrootte van de tekst "Game Over" aan

            Gereed.Height = 40 * sizeMultiplier; // Pas de hoogte van de knoppen aan
            Gereed.Width = 100 * sizeMultiplier; // Pas de breedte van de knoppen aan

            Stop.Height = 40 * sizeMultiplier; // Pas de hoogte van de knoppen aan
            Stop.Width = 100 * sizeMultiplier; // Pas de breedte van de knoppen aan

            Back.Height = 30 * sizeMultiplier; // Pas de hoogte van de knoppen aan
            Back.Width = 50 * sizeMultiplier; // Pas de breedte van de knoppen aan

            TBHours.Height = 40 * sizeMultiplier; // Pas de hoogte van de knoppen aan
            TBHours.Width = 40 * sizeMultiplier; // Pas de breedte van de knoppen aan

            TBMinutes.Height = 40 * sizeMultiplier; // Pas de hoogte van de knoppen aan
            TBMinutes.Width = 40 * sizeMultiplier; // Pas de breedte van de knoppen aan

            TBSeconds.Height = 40 * sizeMultiplier; // Pas de hoogte van de knoppen aan
            TBSeconds.Width = 40 * sizeMultiplier; // Pas de breedte van de knoppen aan

            Gereed.Click += (sender, e) =>
            {
                if (int.TryParse(TBHours.Text, out int hoursInput) &&
                    int.TryParse(TBMinutes.Text, out int minutesInput) &&
                    int.TryParse(TBSeconds.Text, out int secondsInput))
                {
                    hours = hoursInput;
                    minutes = minutesInput;
                    seconds = secondsInput;
                    timerRunning = true;
                    Timer.Start();
                    UpdateTextBox();
                }
            };

            Stop.Click += (sender, e) =>
            {
                Timer.Stop();
                timerRunning = false;
            };

            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Tick += Timer_Tick;
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            if (timerRunning)
            {
                if (hours == 0 && minutes == 0 && seconds == 0)
                {
                    Timer.Stop();
                    timerRunning = false;
                }
                else
                {
                    if (seconds == 0)
                    {
                        if (minutes > 0)
                        {
                            minutes--;
                            seconds = 59;
                        }
                        else if (hours > 0)
                        {
                            hours--;
                            minutes = 59;
                            seconds = 59;
                        }
                    }
                    else
                    {
                        seconds--;
                    }

                    UpdateTextBox();
                }
            }
        }

        void UpdateTextBox()
        {
            TBHours.Text = hours.ToString("D2");
            TBMinutes.Text = minutes.ToString("D2");
            TBSeconds.Text = seconds.ToString("D2");
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Gereed_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
