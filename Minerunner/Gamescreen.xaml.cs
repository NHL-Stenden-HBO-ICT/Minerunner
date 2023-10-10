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

        private int[,] testChunk = {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 3, 0, 3, 0, 3, 3, 3, 0, 3, 0, 0, 0, 0, 0, 0 },
            { 0, 3, 0, 3, 0, 3, 0, 3, 0, 3, 0, 0, 0, 0, 0, 0 },
            { 0, 3, 3, 3, 0, 3, 0, 3, 0, 3, 0, 0, 0, 0, 0, 0 },
            { 0, 3, 0, 3, 0, 3, 0, 3, 0, 3, 0, 0, 0, 0, 0, 0 },
            { 0, 3, 0, 3, 0, 3, 3, 3, 0, 3, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
            { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 },
        };

        public Gamescreen()
        {
            InitializeComponent();

            updateTimer.Interval = TimeSpan.FromMilliseconds(16);
            updateTimer.Tick += OnUpdate;
            updateTimer.Start();

            RenderChunk(testChunk);
        }

        private Brush RandomColor()
        {
            Random r = new Random();
            return new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255),
                              (byte)r.Next(1, 255), (byte)r.Next(1, 233)));
        }

        private void RenderChunk(int[,] chunkData)
        {
            for (int i = 0; i < 256; i++)
            {
                int x = i % 16;
                int y = i / 16;

                Rectangle rect = new Rectangle();
                rect.Width = rect.Height = 20;

                switch (chunkData[y, x])
                {
                    case 0:
                        rect.Fill = new SolidColorBrush(Color.FromRgb(49, 189, 175));
                        break;

                    case 1:
                        rect.Fill = new SolidColorBrush(Color.FromRgb(49, 189, 79));
                        break;

                    case 2:
                        rect.Fill = new SolidColorBrush(Color.FromRgb(94, 40, 16));
                        break;

                    case 3:
                        rect.Fill = new SolidColorBrush(Color.FromRgb(222, 52, 235));
                        break;
                }

                //rect.Fill = RandomColor();

                ChunkCanvas.Children.Add(rect);
                Canvas.SetLeft(rect, x * rect.Width);
                Canvas.SetTop(rect, y * rect.Height);
            }
        }

        private void OnUpdate(object? sender, EventArgs e)
        {
        }
    }
}