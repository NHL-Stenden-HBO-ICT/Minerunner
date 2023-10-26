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
    /// <summary>
    /// Interaction logic for ParentalTime.xaml
    /// </summary>
    public partial class ParentalTime : Page
    {
        private int time = 1000;
        private DispatcherTimer Timer;
        private bool starttime = false;
        public ParentalTime()
        {
            InitializeComponent();
            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Tick += Timer_Tick;
            Timer.Start();
            
    }

        void Timer_Tick(object sender, EventArgs e)
        {
            if (starttime == true)
            {
                if (time >= 0)
                {
                    time--;
                    TBCountDown.Text = string.Format("00:0{0}:{1}", time / 60, time % 60);
                }
                else 
                {
                    Timer.Stop();
                }
               
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            Timer.Stop();
            time = 0;
        }

        private void Gereed_Click(object sender, RoutedEventArgs e)
        {
            starttime = true;
        }
    }

    }
