using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticRegeneration.Helpers
{
    public class BitmapHelper
    {
        /// <summary>
        /// Opens an image at a given path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Image OpenImage(string path)
        {
            return Image.FromFile(path);
        }

        /// <summary>
        /// Saves a bitmap image to the current file directory
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns>True on success</returns>
        public static bool SaveImage(Image image)
        {
            try
            {
                image.Save("./output.png");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Saves a bitmap image to the current file directory
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns>True on success</returns>
        public static bool SaveImage(Image image, string path)
        {
            try
            {
                image.Save(path);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Creates a new bitmap with the given dimentions.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Image CreateImage(int width, int height)
        {
            return new Bitmap(width, height);
        }
    }
}
