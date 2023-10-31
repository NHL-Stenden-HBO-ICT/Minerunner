using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CircularBuffer;

namespace Minerunner
{
    internal class Floor
    {
        public enum BiomeType
        {
            Plains,
            Taiga,
            Desert,
            Mushroom,
        }

        public BiomeType CurrentBiome { get; private set; }

        private Canvas _canvas;
        private int _scrollSpeed = 5;
        private int _blockSize = 50;

        private int _steps;
        private int _totalBlocks;

        private CircularBuffer<BiomeType> _currentBlocksBuffer;

        public static Floor Instance;

        public Floor(Canvas canvas, int scrollSpeed = 5, int blockSize = 50)
        {
            Instance = this;

            _canvas = canvas;
            _scrollSpeed = scrollSpeed;
            _blockSize = blockSize;

            _totalBlocks = (int)1920 / blockSize + 2;
            _currentBlocksBuffer = new CircularBuffer<BiomeType>(_totalBlocks);

            for (int i = 0; i < _totalBlocks; i++)
            {
                var rect = new Rectangle();
                rect.Width = rect.Height = blockSize;
                rect.Tag = "platform";

                _canvas.Children.Add(rect);

                Canvas.SetLeft(rect, i * blockSize);
                Canvas.SetTop(rect, Canvas.GetBottom(_canvas));

                _currentBlocksBuffer.PushBack(BiomeType.Plains);
            }
        }

        private void UpdateBlocks()
        {
            for (int i = 0; i < _totalBlocks; i++)
            {
                Uri imageURL = new Uri("pack://application:,,,/assets/textures/dirt.jpg");

                switch (_currentBlocksBuffer[i])
                {
                    case BiomeType.Plains:
                        imageURL = new Uri("pack://application:,,,/assets/textures/grassblock.jpg");
                        break;

                    case BiomeType.Taiga:
                        imageURL = new Uri("pack://application:,,,/assets/textures/taiga_grassblock.jpg");
                        break;

                    case BiomeType.Desert:
                        imageURL = new Uri("pack://application:,,,/assets/textures/desert_sand.jpg");
                        break;                    
                    
                    case BiomeType.Mushroom:
                        imageURL = new Uri("pack://application:,,,/assets/textures/mushroom_mycelium.jpg");
                        break;
                }

                ((Rectangle)_canvas.Children[i]).Fill = new ImageBrush(new BitmapImage(imageURL));
            }
        }

        public void Scroll()
        {
            Canvas.SetLeft(_canvas, Canvas.GetLeft(_canvas) - _scrollSpeed);
            if (Canvas.GetLeft(_canvas) < -_blockSize)
            {
                int biomeIndex = (int)Math.Floor(_steps / 100.0);
                if (Enum.IsDefined(typeof(BiomeType), biomeIndex))
                {
                    CurrentBiome = (BiomeType)biomeIndex;
                }
                else
                {
                    CurrentBiome = BiomeType.Plains;
                }

                _currentBlocksBuffer.PushBack(CurrentBiome);
                UpdateBlocks();

                Canvas.SetLeft(_canvas, 0);

                _steps++;
            }
        }
    }
}