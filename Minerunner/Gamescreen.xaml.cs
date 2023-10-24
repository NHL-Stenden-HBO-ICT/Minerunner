using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
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
        private bool jump, crouch, collision;
        private double gravity = 0;
        private Floor floor;
        private double score = 0; // Onni score.
        

        public Gamescreen()
        {
            // Load spritesheets
            playerSpriteWalk = new Spritesheet("/assets/spritesheets/player/steve_spritesheet.png", 4, 1, 2000, 3000);
            playerSpriteCrouch = new Spritesheet("/assets/spritesheets/player/steve_spritesheet.png", 4, 2, 2000, 3000);

            // Init gamescreen
            InitializeComponent();

            floor = new Floor(ChunkCanvas);
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
            floor.Scroll();

            // Score - Dit negeren, verplaatst naar spritesheet.
            //score += 0.1;
            //scoreText.Text = Math.Round(score, 1).ToString();
            //scoreText.Text = score.ToString();
            
            // Gravity
            Canvas.SetTop(player, Canvas.GetTop(player) + gravity);
            gravity += 2;

            // Collision
            foreach (var x in ChunkCanvas.Children.OfType<Rectangle>())
            {
            
                if ((string)x.Tag == "platform")
                {

                    // Platfrom Canvas.GetTop does not work, this is correct value
                    int platformTop = 1030;
                   
                    Rect playerHitBox = new Rect(Canvas.GetLeft(player), Canvas.GetTop(player), player.Width, player.Height);
                    Rect platformHitBox = new Rect(0, platformTop, 1920, 50);

                    if (playerHitBox.IntersectsWith(platformHitBox))
                    {
                        // Collision
                        gravity = 0;
                        collision = true;
                        Canvas.SetTop(player, platformTop - player.Height);

                        // Initial jump
                        if (jump == true)
                            Canvas.SetTop(player, Canvas.GetTop(player) - 2);

                    } else
                    {
                        // Player jump
                        if (jump == true)
                        {
                            collision = false;
                            Canvas.SetTop(player, Canvas.GetTop(player) - 2);

                            if (Canvas.GetTop(player) <= platformTop - player.Height - 100)
                                jump = false;
                        }
                    }
                }
            } 
        }

        // Movement trigger, on key press down
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space && collision == true)
                jump = true;

            if (e.Key == Key.LeftCtrl)
                crouch = true;
        }

        // Movement trigger, on key press up
        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftCtrl)
                crouch = false;
        }

        // Timer to handle spritesheets
        private void SpritesheetTimer(object? sender, EventArgs e)
        {
            // Score
            score++;
            scoreText.Text = "Score: " + score.ToString();

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
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Titlescreen());
        }
        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Settings());
        }
    }
}