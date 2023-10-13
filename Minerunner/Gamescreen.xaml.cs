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
        private ImageBrush playerBrush = new ImageBrush();
        private DispatcherTimer gameTimer = new DispatcherTimer();
        private Spritesheet Spritesheet;
        public Gamescreen()
        {
            // Load spritesheet
            Spritesheet = new Spritesheet("/assets/spritesheets/player/steve_spritesheet.png", 4, 2, 2000, 3000, 8);

            InitializeComponent();
            
            // Load first sprite - needed to mitigate slow loading speed 
            playerBrush.ImageSource = Spritesheet.Load();
            player.Fill = playerBrush;

            // Gametimer
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            gameTimer.Tick += GameEngine;
            gameTimer.Start();

        }

        private void GameEngine(object? sender, EventArgs e)
        {
            // Load sprite & draw to player model
            playerBrush.ImageSource = Spritesheet.Load();

            player.Fill = playerBrush;


        }
    }
}
