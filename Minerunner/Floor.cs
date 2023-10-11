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
        public enum BlockType
        {
            Plains,
            Desert,
        }

        private Canvas _canvas;
        private int _scrollSpeed = 5;
        private int _blockSize = 50;

        private int _steps;
        private int _totalBlocks;

        private CircularBuffer<BlockType> _currentBlocksBuffer;

        public Floor(Canvas canvas, int scrollSpeed = 5, int blockSize = 50)
        {
            _canvas = canvas;
            _scrollSpeed = scrollSpeed;
            _blockSize = blockSize;

            _totalBlocks = (int)_canvas.Width / blockSize + 1;
            _currentBlocksBuffer = new CircularBuffer<BlockType>(_totalBlocks);

            for (int i = 0; i < _totalBlocks; i++)
            {
                var rect = new Rectangle();
                rect.Width = rect.Height = blockSize;
                rect.Fill = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                rect.Stroke = new SolidColorBrush(Color.FromRgb(0, 0, 0));

                _canvas.Children.Add(rect);
                Canvas.SetLeft(rect, i * blockSize);

                _currentBlocksBuffer.PushBack(BlockType.Plains);
            }
        }

        private void UpdateBlocks()
        {
            for (int i = 0; i < _totalBlocks; i++)
            {
                var color = Color.FromRgb(0, 0, 0);

                switch (_currentBlocksBuffer[i])
                {
                    case BlockType.Plains:
                        color = Color.FromRgb(0, 255, 0);
                        break;

                    case BlockType.Desert:
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
                _currentBlocksBuffer.PushBack((BlockType)new Random().Next(2));
                UpdateBlocks();

                Canvas.SetLeft(_canvas, 0);
            }
        }
    }
}