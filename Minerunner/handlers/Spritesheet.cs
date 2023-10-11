using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;

class Spritesheet
{
    // Link to spritesheet image
    private string spritesheetImageURL;

    // Amount of rows
    private int rows;

    // Amount of columns
    private int columns;

    // Amount of pixels per image in the X-axis
    private int pixelsX;

    // Amount of pixels per image in the Y-axis
    private int pixelsY;

    // Spritesheet img
    private BitmapImage spritesheet;

    // List of Spritesheet sprites
    private List<CroppedBitmap> spritesheetSprites = new List<CroppedBitmap>();

    // Init Method
    public Spritesheet(string spritesheetImageURL, int rows, int columns, int pixelsX, int pixelsY)
    {
        this.spritesheetImageURL = spritesheetImageURL;
        this.rows = rows;
        this.columns = columns;
        this.pixelsX = pixelsX;
        this.pixelsY = pixelsY;

        LoadSpritesheet(this.spritesheetImageURL);

        SplitSpritesheet(this.spritesheet, this.rows, this.columns, this.pixelsX, this.pixelsY);
    }

    // Load Spritesheet
    private void LoadSpritesheet(string spritesheetImageURL)
    {
        this.spritesheet = new BitmapImage(new Uri(spritesheetImageURL));

        return;
    }

    // Split the Spritesheet & add to list
    private void SplitSpritesheet(BitmapImage spritesheet, int rows, int columns, int pixelsX, int pixelsY)
    {
        int spriteX = 0;
        int spriteY = 0;
        int spriteWidth = pixelsX;
        int spriteHeight = pixelsY;

        for (int i = 0; i < rows; i++) {
            CroppedBitmap sprite = new CroppedBitmap(this.spritesheet, new Int32Rect(spriteX, spriteY, spriteWidth, spriteHeight));

            this.spritesheetSprites.Add(sprite);

            spriteX += pixelsX;
            spriteY += pixelsY;
        }
    }
}