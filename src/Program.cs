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
FastBitmap generated = Generator.StartGenerator(source, 2000, 1000, 100);
BitmapHelper.SaveImage(generated.ExportImage());
