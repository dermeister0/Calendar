using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ColorPaletteGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string imageUrl;
            int leftMargin, topMargin, hStep, vStep;

            imageUrl = @"..\..\Colors1.jpg";
            leftMargin = 20;
            topMargin = 32;
            hStep = 16;
            vStep = 12;

            imageUrl = @"..\..\ColorPallette9_0Small.jpg";
            leftMargin = 7;
            topMargin = 5;
            hStep = 11;
            vStep = 11;

            var image = new BitmapImage(new Uri(imageUrl, UriKind.Relative));

            int stride = (image.PixelWidth * image.Format.BitsPerPixel + 7) / 8;
            byte[] pixelByteArray = new byte[image.PixelHeight * stride];
            image.CopyPixels(pixelByteArray, stride, 0);

            if (image.Format != PixelFormats.Bgr32)
                throw new Exception("Invalid image format.");

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<html><head><style type='text/css'>");
            sb.AppendLine(".block { width: 20px; height: 20px; position: absolute; }");

            for (int i = 1; i <= 16; i++)
            {
                sb.AppendLine(string.Format(".x{0} {{ left: {1}px; }}", i, i * 30));
                sb.AppendLine(string.Format(".y{0} {{ top: {1}px; }}", i, i * 30));
            }

            int colorNumber = 1;
            for (int y = 0; y < 16; y++)
                for (int x = 0; x < 16; x++)
                {
                    int pixelX = leftMargin + x * hStep;
                    int pixelY = topMargin + y * vStep;

                    int pixelIndex = pixelY * image.PixelWidth * 4 + pixelX * 4;

                    byte blue = pixelByteArray[pixelIndex];
                    byte green = pixelByteArray[pixelIndex + 1];
                    byte red = pixelByteArray[pixelIndex + 2];

                    byte roundTo = 8;
                    red = Round(red, roundTo);
                    green = Round(green, roundTo);
                    blue = Round(blue, roundTo);

                    sb.AppendLine(string.Format(".c{3} {{ background-color: rgb({0}, {1}, {2}); }}", red, green, blue, colorNumber));

                    colorNumber++;
                }
            sb.AppendLine("</style></head><body>");

            for (int x = 0; x <= 15; x++)
                for (int y = 0; y <= 15; y++)
                {
                    int blockId = y * 16 + x + 1;
                    sb.AppendLine(string.Format("<div class='block c{0} x{1} y{2}'></div>", blockId, x + 1, y + 1));
                }

            sb.AppendLine("</body></html>");

            File.WriteAllText("Test.html", sb.ToString());
        }

        static byte Round(byte number, byte roundTo)
        {
            int quotient = (number + roundTo / 2) / roundTo;
            int result = quotient * roundTo;

            return result > 255 ? (byte)255 : (byte)result;
        }
    }
}
