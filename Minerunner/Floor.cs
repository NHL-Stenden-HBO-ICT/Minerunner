using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using CircularBuffer;

namespace Minerunner
{
    internal class Floor
    {
        public enum BiomeType
        {
            Plains,
            Desert,
        }

        public BiomeType CurrentBiome { get; private set; }

        private Canvas _canvas;
        private int _scrollSpeed = 5;
        private int _blockSize = 50;

        private int _steps;
        private int _totalBlocks;

        private CircularBuffer<BiomeType> _currentBlocksBuffer;

        public Floor(Canvas canvas, int scrollSpeed = 5, int blockSize = 50)
        {
            _canvas = canvas;
            _scrollSpeed = scrollSpeed;
            _blockSize = blockSize;

            _totalBlocks = (int)_canvas.Width / blockSize + 1;
            _currentBlocksBuffer = new CircularBuffer<BiomeType>(_totalBlocks);

            for (int i = 0; i < _totalBlocks; i++)
            {
                var rect = new Rectangle();
                rect.Width = rect.Height = blockSize;
                rect.Fill = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                rect.Stroke = new SolidColorBrush(Color.FromRgb(0, 0, 0));
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
                var color = Color.FromRgb(0, 0, 0);

                switch (_currentBlocksBuffer[i])
                {
                    case BiomeType.Plains:
                        color = Color.FromRgb(0, 255, 0);
                        break;

                    case BiomeType.Desert:
                        color = Color.FromRgb(225, 255, 0);
                        break;
                }

                ((Rectangle)_canvas.Children[i]).Fill = new SolidColorBrush(color);
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