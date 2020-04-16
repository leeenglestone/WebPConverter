using ImageProcessor;
using ImageProcessor.Imaging.Formats;
using ImageProcessor.Plugins.WebP.Imaging.Formats;
using System;
using System.IO;

namespace LocalWebPConverter.ConsoleApplication
{
    internal class WebPConverter
    {
        internal static void ConvertToWebP(string inputPath, string outputPath, int imageQualityPercentage)
        {
            ISupportedImageFormat webpFormat = new WebPFormat { Quality = imageQualityPercentage };
            ConvertImageToWebP(inputPath, outputPath, webpFormat);
        }

        private static void ConvertImageToWebP(string inputPath, string outputPath, ISupportedImageFormat outputImageFormat)
        {
            byte[] imageBytes;

            try
            {
                imageBytes = File.ReadAllBytes(inputPath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            using (MemoryStream memoryStream = new MemoryStream(imageBytes))
            using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
            {
                try
                {
                    imageFactory.Load(memoryStream).Format(outputImageFormat).Save(outputPath);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }
        }
    }
}
