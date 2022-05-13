using EIG;
using GeneticRegeneration.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticRegeneration.Test
{
    public static class Speed
    {
        public static void BitmapAccessTest()
        {
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("Starting FastBitmap Access Check (Old Method)");

            FastBitmap fastBitmap = new FastBitmap(1000, 1000);
            sw.Start();
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    fastBitmap.GetPixel(i, j);
                }
            }
            sw.Stop();
            Console.WriteLine("Test Complete...");
            Console.WriteLine($"Elapsed Time: {sw.Elapsed.ToString()}\n");

            sw.Restart();

            BitmapData data = new BitmapData(1000, 1000);
            Console.WriteLine("Starting BitmapData Access Check (Struct & Dictionary)");
            sw.Start();
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    data.GetPixel(new Point(i, j));
                }
            }
            sw.Stop();

            Console.WriteLine("Test Complete...");
            Console.WriteLine($"Elapsed Time: {sw.Elapsed.ToString()}\n");
            GC.Collect();
        }

        public static void ScoreImagesTest()
        {
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("Starting Scoring Test (100% Pixels, same image)");
            sw.Start();

            FastBitmap bitmap = new FastBitmap(200, 200);
            for (int i = 0; i < 1000; i++)
            {
                uint score = Generator.ScoreImage(bitmap, bitmap);
            }

            sw.Stop();
            Console.WriteLine("Test Complete...");
            Console.WriteLine($"Elapsed Time: {sw.Elapsed.ToString()}\n");
            sw.Restart();

            //Console.WriteLine("Starting Scoring Test (50% Pixels, same image)");
            //Console.WriteLine("Starting Scoring Test (25% Pixels, same image)");

            Console.WriteLine("Starting Scoring Test (100% Pixels, rendering rectangle to new image)");
            sw.Start();



            sw.Stop();
            Console.WriteLine("Test Complete...");
            Console.WriteLine($"Elapsed Time: {sw.Elapsed.ToString()}\n");
            sw.Restart();

            //Console.WriteLine("Starting Scoring Test (100% Pixels, rendering rectangle to new image)");
            //Console.WriteLine("Starting Scoring Test (100% Pixels, rendering rectangle to new image)");
        }
    }
}
