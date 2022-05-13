using System.Drawing;

namespace GeneticRegeneration.Data
{
    struct BitmapData
    {
        public BitmapData(Image image)
        {
            Width = image.Width;
            Height = image.Height;
            Map = new Dictionary<Point, byte[]>();
            InitializeMap();
        }

        public BitmapData(int width, int height)
        {
            Width = width;
            Height = height;
            Map = new Dictionary<Point, byte[]>();
            InitializeMap();
            
        }
        
        /// <summary>
        /// Returns the color of a point on the map
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public byte[] GetPixel(Point point)
        {
            return Map.ContainsKey(point) ? Map[point] : null;
        }

        /// <summary>
        /// Sets the color of a point in the map
        /// </summary>
        /// <param name="point"></param>
        /// <param name="color"></param>
        public void SetPixel(Point point, byte[] color)
        {
            if (Map.ContainsKey(point))
            {
                Map[point] = color;
            }
            else
            {
                Map.Add(point, color);
            }
        }

        /// <summary>
        /// Initializes the Map dictonary
        /// </summary>
        private void InitializeMap()
        {
            if (Map.Count != 0) return;
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Map.Add(new Point(x, y), new byte[] { 255, 255, 255 });
                }
            }
        }

        public Dictionary<Point, byte[]> Map { get; }
        public int Width { get; }
        public int Height { get; }
    }
}
