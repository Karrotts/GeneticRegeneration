using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticRegeneration.Helpers
{
    public static class DisplayHelper
    {
        public static string ProgressBar(int current, int max)
        {
            int bars = (int)(((float)current / (float)max) * 100) / 10;
            int dashs = 10 - bars;
            string bar = "";
            string dash = "";

            for (int i = 0; i < dashs; i++)
            {
                dash += '-';
            }

            for (int i = 0; i < bars; i++)
            {
                bar += '#';
            }

            return $"({bar}{dash})";
        }

        public static void SetDisplay(int current, int max, TimeSpan totalElapsed, float scorePrecentage)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"Currently on Generation {current}...");
            totalElapsed = (max - current) * totalElapsed;
            Console.WriteLine($"{ProgressBar(current, max)} ({current}/{max}) Estimated remaining time: {totalElapsed.ToString()}");
            Console.WriteLine($"Image closeness: {scorePrecentage * 100}%");
        }
    }
}
