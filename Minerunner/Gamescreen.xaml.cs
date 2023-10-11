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
    /// Interaction logic for Gamescreen.xaml
    /// </summary>
    public partial class Gamescreen : Page
    {
        private DispatcherTimer updateTimer = new DispatcherTimer();
        private Floor floor;

        public Gamescreen()
        {
            InitializeComponent();

            updateTimer.Interval = TimeSpan.FromMilliseconds(20);
            updateTimer.Tick += OnUpdate;
            updateTimer.Start();

            floor = new Floor(ChunkCanvas);
        }

        private Brush RandomColor()
        {
            Random r = new Random();
            return new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255),
                              (byte)r.Next(1, 255), (byte)r.Next(1, 233)));
        }

        private void OnUpdate(object? sender, EventArgs e)
        {
            floor.Scroll();
        }
    }
}