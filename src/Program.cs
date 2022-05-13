using EIG;
using GeneticRegeneration;
using GeneticRegeneration.Helpers;
using GeneticRegeneration.Test;
using System.Drawing;

//Speed.BitmapAccessTest();
//Speed.RenderingRectangles();
//Speed.ScoreImagesTest();

Image sourceImage = BitmapHelper.OpenImage(@"C:\dev\GeneticRegeneration\src\test.jpg");
FastBitmap source = new FastBitmap((Bitmap)sourceImage);
FastBitmap generated = Generator.StartGenerator(source, 500, 500, 100, true);
BitmapHelper.SaveImage(generated.ExportImage());
