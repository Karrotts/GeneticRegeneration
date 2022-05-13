using EIG;
using GeneticRegeneration.Data;
using GeneticRegeneration.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticRegeneration
{
    public static class Generator
    {
        public static FastBitmap StartGenerator(FastBitmap source, int generations, int children, int mutations)
        {
            // create a new empty FastBitmap with the same dimentions as the source
            FastBitmap generated = new FastBitmap(source.Width, source.Height);

            // keep track of the last generations score
            uint lastScore = ScoreImage(source, generated);

            Stopwatch stopwatch = new Stopwatch();
            float generationScale = 1;

            // loop through each generation
            stopwatch.Start();
            for (int i = 0; i < generations; i++)
            {
                DisplayHelper.SetDisplay(i, generations, stopwatch.Elapsed, (float)lastScore / (float)(source.Width * source.Height * 100 * .50));
                stopwatch.Restart();

                // generate children for this generation and sort by their score
                List<ShapeData> generationChildren = GenerateChildren(source, children, generationScale);
                ScoreGeneration(generationChildren, source, generated);
                generationChildren = generationChildren.OrderBy(x => x.Score).ToList();

                // check if the top result is better than the last generation
                ShapeData highestChild = generationChildren[generationChildren.Count - 1];
                if (highestChild.Score > lastScore)
                {
                    // render the square and set the highest score
                    generated.RenderRectangle(highestChild.Rectangle, highestChild.Color);
                    lastScore = highestChild.Score;
                    generationScale = 1;
                }
                else
                {
                    // this generation of children failed to improve upon the last... NO REGRESSION
                    // this generation will be sent to the firey flames of hell

                    // we also make the next gen a little bit smaller overall,
                    // smaller changes tend to have a higher chance to increase the generation score
                    if (generationScale > .1f)
                    {
                        generationScale -= .05f;
                    }

                    i--;
                }
            }

            return generated;
        }

        private static List<ShapeData> GenerateChildren(FastBitmap source, int children, float scale)
        {
            List<ShapeData> data = new List<ShapeData>();

            for (int i = 0; i < children; i++)
            {
                Rectangle rect = CreateRectangle((float)i / children, source.Width, source.Height, scale);
                int[] color = RandomColor();
                data.Add(new ShapeData(rect, color));
            }

            return data;
        }

        private static int[] RandomColor()
        {
            Random random = new Random();
            int[] color = new int[] { random.Next(0, 256), random.Next(0, 256), random.Next(0, 256) };
            return color;
        }

        private static Rectangle CreateRectangle(float size, int maxWidth, int maxHeight, float scale)
        {
            Random random = new Random();

            int x = random.Next(maxWidth);
            int y = random.Next(maxHeight);
            int width = (int)((random.Next(maxWidth) * size) * scale + 1);
            int height = (int)((random.Next(maxHeight) * size) * scale + 1);
            return new Rectangle(x, y, width, height);
        }

        private static void ScoreGeneration(List<ShapeData> generationChildren, FastBitmap source, FastBitmap generated)
        {
            foreach (ShapeData child in generationChildren)
            {
                child.Score = ScoreImage(source, generated.RenderRectangleClone(child.Rectangle, child.Color));
            }
            GC.Collect();
        }

        public static uint ScoreImage(FastBitmap source, FastBitmap generation)
        {
            uint score = 0;
            int[] colorSource = new int[3];
            int[] colorGen = new int[3];
            double minDistance = ColorDistance(255, 0, 255, 0, 255, 0);
            for (int y = 0; y < source.Height; y += 1)
            {
                for (int x = 0; x < source.Width; x += 2)
                {
                    colorSource = source.GetPixel(x, y);
                    colorGen = generation.GetPixel(x, y);
                    score += (uint)((1 - (ColorDistance(colorSource[0], colorGen[0], colorSource[1], colorGen[1], colorSource[2], colorGen[2]) / minDistance)) * 100);
                }
            }
            return score;
        }

        private static double ColorDistance(int r1, int r2, int g1, int g2, int b1, int b2 )
        {
            return Math.Sqrt(Math.Pow((r2 - r1), 2) + Math.Pow((g2 - g1), 2) + Math.Pow((b1 - b2), 2));
        }
    }
}
