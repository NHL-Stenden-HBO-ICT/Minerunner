using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Minerunner
{
    /// <summary>
    /// Interaction logic for Gamescreen.xaml
    /// </summary>
    public partial class Gamescreen : Page
    {
        // Vars
        private ImageBrush playerBrush = new ImageBrush();
        private DispatcherTimer gameTimer = new DispatcherTimer();
        private DispatcherTimer spritesheetTimer = new DispatcherTimer();
        private Spritesheet Spritesheet;

        public Gamescreen()
        {
            // Load spritesheet
            Spritesheet = new Spritesheet("/assets/spritesheets/player/steve_spritesheet.png", 4, 1, 2000, 3000);

            // Init gamescreen
            InitializeComponent();
                
            // Load first sprite - needed to mitigate slow loading speed 
            playerBrush.ImageSource = Spritesheet.Load();
            player.Fill = playerBrush;

            // Gametimer
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            gameTimer.Tick += GameEngine;
            gameTimer.Start();

            // Spritesheet Timer
            spritesheetTimer.Interval = TimeSpan.FromMilliseconds(200);
            spritesheetTimer.Tick += SpritesheetTimer;
            spritesheetTimer.Start();

        }

        // Timer to handle game logic
        private void GameEngine(object? sender, EventArgs e)
        {



        }

        // Timer to handle spritesheets
        private void SpritesheetTimer(object? sender, EventArgs e)
        {
            // Load sprite & draw to player model
            playerBrush.ImageSource = Spritesheet.Load();

            player.Fill = playerBrush;
        }
    }
}
