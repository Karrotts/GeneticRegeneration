using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace EIG
{
    public class FastBitmap
    {
        public int[,][] Map;
        public int Width, Height;

        /// <summary>
        /// Creates a new empty FastBitmap initialized to 0
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public FastBitmap(int x, int y)
        {
            Width = x;
            Height = y;
            Map = new int[y, x][];
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    Map[i, j] = new int[] { 0, 0, 0 };
                }
            }
        }

        /// <summary>
        /// Creates a new Fast Bitmap from an bitmap image
        /// </summary>
        /// <param name="image"></param>
        public FastBitmap(Bitmap image)
        {
            Width = image.Width;
            Height = image.Height;
            Map = new int[image.Height, image.Width][];
            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width; j++)
                {
                    Color color = image.GetPixel(i, j);
                    Map[j, i] = new int[] { color.R, color.G, color.B };
                }
            }
        }

        public int[] GetPixel(int x, int y)
        {
            return Map[y, x];
        }

        public void SetPixel(int x, int y, int[] color)
        {
            Map[y, x] = color;
        }

        public void RenderRectangle(GeneticRegeneration.Data.Rectangle rectangle, int[] color)
        {
            int xStart = rectangle.X > 0 ? rectangle.X : 0;
            int yStart = rectangle.Y > 0 ? rectangle.Y : 0;
            int xEnd = xStart + rectangle.Width < Width ? rectangle.Width + xStart : Width;
            int yEnd = yStart + rectangle.Height < Height ? yStart + rectangle.Height : Height;

            for (int y = yStart; y < yEnd; y++)
            {
                for (int x = xStart; x < xEnd; x++)
                {
                    SetPixel(x, y, color);
                }
            }
        }

        public FastBitmap RenderRectangleClone(GeneticRegeneration.Data.Rectangle rectangle, int[] color)
        {
            FastBitmap clone = Clone();
            int xStart = rectangle.X > 0 ? rectangle.X : 0;
            int yStart = rectangle.Y > 0 ? rectangle.Y : 0;
            int xEnd = xStart + rectangle.Width < Width ? rectangle.Width + xStart : Width;
            int yEnd = yStart + rectangle.Height < Height ? yStart + rectangle.Height : Height;

            for (int y = yStart; y < yEnd; y++)
            {
                for (int x = xStart; x < xEnd; x++)
                {
                    clone.SetPixel(x, y, color);
                }
            }
            return clone;
        }

        public FastBitmap Clone()
        {
            FastBitmap clone = new FastBitmap(Width, Height);
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    clone.Map[y, x] = Map[y, x];
                }
            }
            return clone;
        }

        public Bitmap ExportImage()
        {
            Bitmap bitmap = new Bitmap(Width, Height);
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    int[] color = Map[y, x];
                    bitmap.SetPixel(x, y, Color.FromArgb(color[0], color[1], color[2]));
                }
            }
            return bitmap;
        }
    }
}
