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
        private bool isJumping, isFalling = true, crouch, collision;

        private double acceleration = 1.3;
        private double fallSpeed = 1;
        private double jumpSpeed = 20;

        private Floor floor;
        private Obstacles obstacles;

        private double score = 0; // Onni score.
        

        public Gamescreen()
        {
            // Load spritesheets
            playerSpriteWalk = new Spritesheet("/assets/spritesheets/player/steve_spritesheet.png", 4, 1, 2000, 3000);
            playerSpriteCrouch = new Spritesheet("/assets/spritesheets/player/steve_spritesheet.png", 4, 2, 2000, 3000);

            // Init gamescreen
            InitializeComponent();

            floor = new Floor(ChunkCanvas);
            obstacles = new Obstacles(ObstacleCanvas);

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
            obstacles.Scroll();

            // Score - Dit negeren, verplaatst naar spritesheet.
            //score += 0.1;
            //scoreText.Text = Math.Round(score, 1).ToString();
            //scoreText.Text = score.ToString();

            // Gravity
            if (isFalling)
            {
                Canvas.SetTop(player, Canvas.GetTop(player) + fallSpeed);
                fallSpeed = fallSpeed * acceleration;
            }

            isFalling = true;

            // Jumping
            if (isJumping)
            {
                collision = false;

                // Set new height
                Canvas.SetTop(player, Canvas.GetTop(player) - jumpSpeed);
                jumpSpeed = jumpSpeed / acceleration;

                // Disable jump && enable gravity on max. height
                if (jumpSpeed <= 0.2)
                {
                    isJumping = false;
                    isFalling = true;

                    jumpSpeed = 20;
                    fallSpeed = 1;
                }
            }

            // Collision with floor
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
                        // Gravity
                        isFalling = false;
                        fallSpeed = 1;

                        // Collision
                        collision = true;
                        Canvas.SetTop(player, platformTop - player.Height);

                        // Initial jump
                        if (isJumping == true && collision == true)
                            Canvas.SetTop(player, Canvas.GetTop(player) - 0.1);

                    }
                }
            }
            
            // Collision with objects
            foreach (var x in ObstacleCanvas.Children.OfType<Rectangle>())
            {

                Rect playerHitBox = new Rect(Canvas.GetLeft(player), Canvas.GetTop(player), player.Width, player.Height);
                Rect obstacleHitBox = new Rect(Canvas.GetLeft(ObstacleCanvas) + Canvas.GetLeft(x) + 25, Canvas.GetTop(x) + 830, 50, 50);

                if (playerHitBox.IntersectsWith(obstacleHitBox))
                {

                    // Check if player hit the side, or is walking on top
                    // -7 && +10 are margings needed to compensate for WPFs slow speed
                    if (playerHitBox.Bottom - 7 > obstacleHitBox.Top && playerHitBox.Right < obstacleHitBox.Left + 10)
                    {
                        // GAME OVER Trigger
                        gameTimer.Stop();
                        spritesheetTimer.Stop();
                        this.NavigationService.Navigate(new GameOverPage());

                    } else
                    {
                        // Player walking ontop of obstacle

                        // Gravity
                        isFalling = false;
                        fallSpeed = 1;

                        // Collision
                        collision = true;
                        Canvas.SetTop(player, obstacleHitBox.Top - 100);

                        // Initial jump
                        if (isJumping == true && collision == true)
                            Canvas.SetTop(player, Canvas.GetTop(player) - 0.1);
                    }
                }

            }
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
            }
            else
            {
                playerBrush.ImageSource = playerSpriteWalk.Load();

                player.Fill = playerBrush;
            }
        }

        // Movement trigger, on key press down
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space && collision == true)
                isJumping = true;

            if (e.Key == Key.LeftCtrl)
                crouch = true;
        }

        // Movement trigger, on key press up
        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftCtrl)
                crouch = false;
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