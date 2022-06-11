using EIG;
using GeneticRegeneration;
using GeneticRegeneration.Helpers;
using GeneticRegeneration.Test;
using System.Drawing;

//Speed.BitmapAccessTest();
//Speed.RenderingRectangles();
//Speed.ScoreImagesTest();

//Image sourceImage = BitmapHelper.OpenImage(@"C:\dev\GeneticRegeneration\src\test.jpg");
//FastBitmap source = new FastBitmap((Bitmap)sourceImage);
//FastBitmap generated = Generator.StartGenerator(source, 700, 1000, 0, true);
//BitmapHelper.SaveImage(generated.ExportImage());

if (args.Length >= 4)
{
    try
    {
        string path = args[0];
        int generations = int.Parse(args[1]);
        int children = int.Parse(args[2]);
        int mutations = int.Parse(args[3]);
        bool exportFrames = false;
        bool reports = false;

        if (args.Length >= 5)
        {
            exportFrames = bool.Parse(args[4]);
        }

        if (args.Length >= 6)
        {
            reports = bool.Parse(args[5]);
        }


        Image sourceImage = BitmapHelper.OpenImage(path);
        FastBitmap source = new FastBitmap((Bitmap)sourceImage);
        FastBitmap generated = Generator.StartGenerator(source, generations, children, mutations, exportFrames, reports);
        BitmapHelper.SaveImage(generated.ExportImage());
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }
} 
else
{
    Console.WriteLine("Usage: GeneticRegeneration.exe IMAGE_PATH GENERATIONS CHILDREN MUTATIONS EXPORT_FRAMES REPORTS");
}