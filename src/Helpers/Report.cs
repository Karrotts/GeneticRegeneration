using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GeneticRegeneration.Helpers
{
    public static class Report
    {
        public static List<ReportData> Data = new List<ReportData>();

        public static void ExportData()
        {
            var csv = new StringBuilder();
            csv.AppendLine("Generation, Score, CompleteTime, TotalTime");

            foreach (var report in Data)
            {
                csv.AppendLine($"{report.Generation}, {report.Score}, {report.CompleteTime.TotalMilliseconds}, {report.TotalTime.TotalMilliseconds}");
            }

            File.WriteAllText("./report.csv", csv.ToString());
        }
    }

    public class ReportData
    {
        public int Generation;
        public uint Score;
        public TimeSpan CompleteTime;
        public TimeSpan TotalTime;
        
        public ReportData(int generation, uint score, TimeSpan completeTime, TimeSpan totalTime)
        {
            Generation = generation;
            Score = score;
            CompleteTime = completeTime;
            TotalTime = totalTime;
        }
    }
}
