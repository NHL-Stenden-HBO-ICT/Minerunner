using System.Collections.Generic;
using System.Windows.Shapes;
using System.IO;
using System.Text.Json;
using System.Windows.Controls;
using System.Windows.Media;
using CircularBuffer;
using System.Linq;
using System;

class Obstacles
{
    // Vars
    private Canvas canvas;
    private int[,,] obstacles =
    {
        {
            {0, 0, 0, 0,},
            {0, 0, 0, 0,},
            {0, 0, 1, 1,},
            {1, 0, 0, 0,}
        },
        {
            {0, 0, 0, 0,},
            {0, 0, 0, 0,},
            {0, 0, 0, 0,},
            {1, 1, 1, 1,}
        },
        {
            {0, 0, 0, 0,},
            {0, 0, 0, 0,},
            {0, 0, 0, 0,},
            {1, 0, 0, 0,}
        }

    };

    private int blockSize = 50;

    // No clue why the scrollspeed is this #
    private double scrollSpeed = 4.5;

    private int totalBlocks = 1920 / 50 + 2;
    private int blockSpacing = 5;
    private int blockSpacingCurrentSpace = 0;
    private int obstaclesOnScreen = 0;

    // Constructor
    public Obstacles(Canvas Canvas, string filename = "obstacles")
    {
        // Vars
        this.canvas = Canvas;

        // Load obstacles
        //loadFile(filename);

        LoadObstacle();

    }
    /*
    // Load obstacles from JSON file
    private void loadFile(string filename)
    {
        FileStream file = File.OpenRead("pack://application:,,,/resources/" + filename + ".json");

        this.obstacles = JsonSerializer.Deserialize<string>(file);
    }
    */
    private void LoadObstacle()
    {
        int x = 1920;
        int y = 0;

        Random r = new Random();
        int rInt = r.Next(0, obstacles.GetLength(0));

        for (int i = 0; i < obstacles.GetLength(1); i++)
        {
            for (int j = 0; j < obstacles.GetLength(2); j++)
            {
                if (obstacles[rInt,i,j] != 0)
                {
                    var rect = new Rectangle();
                    rect.Width = rect.Height = 50;
                    rect.Fill = new SolidColorBrush(Color.FromRgb(255, 0, 125));

                    canvas.Children.Add(rect);

                    Canvas.SetLeft(rect, x);
                    Canvas.SetTop(rect, y);
                }

                x += 50;
            }

            x = 1920;
            y += 50;
        }
    }

    public void Scroll()
    {

        //Scrolling effect
        Canvas.SetLeft(canvas, Canvas.GetLeft(canvas) - 4.5);
        
        // Reset
        if (Canvas.GetLeft(canvas) < -2120)
        {
            canvas.Children.Clear();
            Canvas.SetLeft(canvas, 0);

            LoadObstacle();
        }
    }


}
