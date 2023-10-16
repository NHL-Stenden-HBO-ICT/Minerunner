using System;
using System.Windows.Controls;
using System.Windows.Input;
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
        private Spritesheet playerSpriteWalk, playerSpriteCrouch;
        private bool jump, crouch;
        private int gravity = 25;

        public Gamescreen()
        {
            // Load spritesheets
            playerSpriteWalk = new Spritesheet("/assets/spritesheets/player/steve_spritesheet.png", 4, 1, 2000, 3000);
            playerSpriteCrouch = new Spritesheet("/assets/spritesheets/player/steve_spritesheet.png", 4, 2, 2000, 3000);

            // Init gamescreen
            InitializeComponent();

            gameCanvas.Focus();

            // Load first sprite - needed to mitigate slow loading speed 
            playerBrush.ImageSource = playerSpriteWalk.Load();
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
            // Gravity
            Canvas.SetTop(player, Canvas.GetTop(player) + gravity);
            
            // Player jump
            if (jump == true)
                Canvas.SetTop(player, Canvas.GetTop(player) - 100);
                

        }

        // Movement trigger, on key press down
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                jump = true;

            if (e.Key == Key.LeftCtrl)
                crouch = true;

        }

        // Movement trigger, on key press up
        private void OnKeyUp(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Space)
                jump = false;

            if (e.Key == Key.LeftCtrl)
                crouch = false;
        }

        // Timer to handle spritesheets
        private void SpritesheetTimer(object? sender, EventArgs e)
        {
            if (crouch == true)
            {
                playerBrush.ImageSource = playerSpriteCrouch.Load();

                player.Fill = playerBrush;
            } else
            {
                playerBrush.ImageSource = playerSpriteWalk.Load();

                player.Fill = playerBrush;
            }
        }
    }
}
