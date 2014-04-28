using CalendarApp.Controls;
using ImageTools.IO.Png;
using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ImageTools;
using CalendarApp.ViewModels;

namespace CalendarApp.Utils
{
    public class LiveTile
    {
        public LiveTile()
        {
        }

        public const int FlipSmallWidth = 159;

        public const int FlipSmallHeight = 159;

        public const int FlipMediumWidth = 336;

        public const int FlipMediumHeight = 336;

        public const int FlipWideWidth = 691;

        public const int FlipWideHeight = 336;

        public void CreateBitmap()
        {
            RenderText("28", FlipMediumWidth, FlipMediumHeight, 100, "DemoImage");
            return;

            //Image img = new Image();
            //img.Source = new BitmapImage(new Uri("/MyImage.jpg", UriKind.Relative));
            //img.Source = new BitmapImage();
            WriteableBitmap wb = new WriteableBitmap(173, 173);

            TextBlock txtblk = new TextBlock();
            txtblk.Foreground = new SolidColorBrush(Colors.Red);
            //txtblk.Style = App.Current.Resources[""];
            txtblk.Text = "overlay text";

            wb.Render(txtblk, new TranslateTransform() { X = 20, Y = 50 });
            wb.Invalidate();

            string imageFolder = "/Shared/ShellContent/";
            string imageFileName = "DemoImage.jpg";

            //Using Isolated storage for storage
            using (var isoFile = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (!isoFile.DirectoryExists(imageFolder))
                {
                    isoFile.CreateDirectory(imageFolder);
                }
                string filePath = System.IO.Path.Combine(imageFolder, imageFileName);
                using (var stream = isoFile.CreateFile(filePath))
                {
                    wb.SaveJpeg(stream, wb.PixelWidth, wb.PixelHeight, 0, 100);
                }
            }
        }

        public void CreateApplicationTile()
        {
            var appTile = ShellTile.ActiveTiles.First();

            if (appTile == null)
                return;

            //Retrieve the seconds part of current timestamp
            int Sec = System.DateTime.Now.Second;
            var store = IsolatedStorageFile.GetUserStoreForApplication();
            if (appTile != null)
            {
                var standardTile = new StandardTileData
                {
                    Title = "CalendarApp",
                    BackgroundImage = new Uri(@"isostore:/Shared/ShellContent/DemoImage.png", UriKind.Absolute),
                    Count = 0,
                    BackBackgroundImage = new Uri("", UriKind.Relative),
                    BackContent = string.Empty,
                    BackTitle = string.Empty
                };
                appTile.Update(standardTile);
            }
        }

        private static void RenderText(string text, int width, int height, int fontsize, string imagename)
        {
            WriteableBitmap b = new WriteableBitmap(width, height);

            var liveTileVM = Ioc.Get<LiveTileViewModel>();
            liveTileVM.Day = 29;
            liveTileVM.TileWidth = b.PixelWidth;
            liveTileVM.TileHeight = b.PixelHeight;

            var liveTileControl = new LiveTileControl();

            var canvas = new Grid();
            canvas.Width = b.PixelWidth;
            canvas.Height = b.PixelHeight;

            var background = new Canvas();
            background.Height = b.PixelHeight;
            background.Width = b.PixelWidth;

            //Created background color as Accent color
            SolidColorBrush backColor = new SolidColorBrush((Color)App.Current.Resources["PhoneAccentColor"]);
            background.Background = backColor;

            var textBlock = new TextBlock();
            textBlock.Text = text;
            //textBlock.FontWeight = FontWeights.Medium;
            textBlock.FontFamily = App.Current.Resources["PhoneFontFamilySemiBold"] as FontFamily;
            textBlock.TextAlignment = TextAlignment.Right;
            textBlock.HorizontalAlignment = HorizontalAlignment.Right;
            textBlock.VerticalAlignment = VerticalAlignment.Bottom;
            textBlock.Margin = new Thickness(35);
            textBlock.Width = b.PixelWidth - textBlock.Margin.Left * 2;
            textBlock.TextWrapping = TextWrapping.Wrap;
            textBlock.Foreground = new SolidColorBrush(Colors.White); //color of the text on the Tile
            textBlock.FontSize = fontsize;

            canvas.Children.Add(textBlock);

            //b.Render(background, null);
            //b.Render(canvas, null);
            b.Render(liveTileControl, null);
            b.Invalidate(); //Draw bitmap

            //Save bitmap as jpeg file in Isolated Storage
            using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream imageStream = new IsolatedStorageFileStream("/Shared/ShellContent/" + imagename + ".png", System.IO.FileMode.Create, isf))
                {
                    var encoder = new PngEncoder();
                    encoder.Encode(b.ToImage(), imageStream);
                }
            }
        }

    }
}
