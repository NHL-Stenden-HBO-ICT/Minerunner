﻿using System;
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

            // Score
            //score += 0.1;
            //scoreText.Text = Math.Round(score, 1).ToString();
            //ScoreText.Text = score.ToString();
            
            // Gravity
            Canvas.SetTop(player, Canvas.GetTop(player) + gravity);
            gravity += 2;

            // Collision
            foreach (var x in ChunkCanvas.Children.OfType<Rectangle>())
            {
            
                if ((string)x.Tag == "platform")
                {
                   
                    Rect playerHitBox = new Rect(Canvas.GetLeft(player), Canvas.GetTop(player), player.Width, player.Height);
                    Rect platformHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                    if (playerHitBox.IntersectsWith(platformHitBox))
                    {
                        // Collision
                        gravity = 0;
                        collision = true;
                        Canvas.SetTop(player, Canvas.GetTop(x) - player.Height);

                    } else
                    {
                        // Player jump
                        if (jump == true)
                        {
                            collision = false;
                            Canvas.SetTop(player, Canvas.GetTop(player) - 2);

                            if (Canvas.GetTop(player) <= Canvas.GetTop(x) - player.Height - 100)
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
            // Score maar dan in Spritesheet.
            score++;
            scoreText.Text = score.ToString();

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