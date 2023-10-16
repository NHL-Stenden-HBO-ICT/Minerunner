using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

/*  How to use
 *  
 *  | Create new Spritesheet(Relative URL, # of rows, Column number, Width of 1 sprite in px, Length of 1 sprite in px)
 *  Spritesheet = new Spritesheet("/assets/spritesheets/player/steve_spritesheet.png", 4, 2, 2000, 3000);
 *
 *  | Initial load
 *  playerBrush.ImageSource = Spritesheet.Load();
 *  player.Fill = playerBrush;
 *
 *  | Make custom timer for Spritesheets & update sprite every tick
 *  playerBrush.ImageSource = Spritesheet.Load();
 *  player.Fill = playerBrush;
 *
 */

class Spritesheet
{
    // Link to spritesheet image
    private string spritesheetImageURL;

    // Amount of rows
    private int rows;

    // Column
    private int column;

    // Amount of pixels per image in the X-axis
    private int pixelsX;

    // Amount of pixels per image in the Y-axis
    private int pixelsY;

    // Current tick
    private int tickrate = 0;

    // Spritesheet img
    private BitmapImage spritesheet;

    // List of Spritesheet sprites
    private List<CroppedBitmap> spritesheetSprites = new List<CroppedBitmap>();

    // Init Method
    public Spritesheet(string spritesheetImageURL, int rows, int column, int pixelsX, int pixelsY)
    {
        // Set vars
        this.spritesheetImageURL = spritesheetImageURL;
        this.rows = rows;
        this.column = column;
        this.pixelsX = pixelsX;
        this.pixelsY = pixelsY;

        // Load & split spritesheet
        var Spritesheet = LoadSpritesheet(this.spritesheetImageURL);
        SplitSpritesheet(Spritesheet, this.rows, this.column, this.pixelsX, this.pixelsY);
    }

    // Load sprites & change them every tick
    public CroppedBitmap Load()
    {
        // Reset if at last sprite
        if (this.tickrate == this.rows)
            this.tickrate = 0;

        // Return sprite
        var currentSprite = this.spritesheetSprites[this.tickrate];

        this.tickrate++;

        return currentSprite;
    }

    // Load Spritesheet
    private BitmapImage LoadSpritesheet(string spritesheetImageURL)
    {
        // Get spritesheet
        this.spritesheet = new BitmapImage(new Uri("pack://application:,,," + spritesheetImageURL));

        return this.spritesheet;
    }

    // Split the Spritesheet & add to list
    private void SplitSpritesheet(BitmapImage spritesheet, int rows, int column, int pixelsX, int pixelsY)
    {
        // vars
        int spriteX = 0;
        int spriteY = (column - 1) * pixelsY;
        
        // Add every sprite to a list
        for (int i = 0; i < rows; i++) {
            this.spritesheetSprites.Add(new CroppedBitmap(this.spritesheet, new Int32Rect(spriteX, spriteY, pixelsX, pixelsY)));

            // Possibly improves performance
            RenderOptions.SetBitmapScalingMode(this.spritesheetSprites[i], BitmapScalingMode.LowQuality);

            spriteX += pixelsX;
        }
    }
}