using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticRegeneration.Data
{
    class ShapeData
    {
        public ShapeData(Rectangle rectangle, int[] color)
        {
            Rectangle = rectangle;
            Color = color;
            Score = 0;
        }

        public int[] Color;
        public Rectangle Rectangle;
        public uint Score;
    }

    public class Rectangle
    { 
        public Rectangle(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public int X;
        public int Y;
        public int Width;
        public int Height;
    }

}
