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
using System.Globalization;

namespace CalendarApp.Utils
{
    public class LiveTileGenerator
    {
        public const int FlipSmallWidth = 159;

        public const int FlipSmallHeight = 159;

        public const int FlipMediumWidth = 336;

        public const int FlipMediumHeight = 336;

        public const int FlipWideWidth = 691;

        public const int FlipWideHeight = 336;

        const string TileBitmapFile = "/Shared/ShellContent/TileBitmap.png";

        void CreateTileBitmap(int width, int height)
        {
            WriteableBitmap b = new WriteableBitmap(width, height);

            var liveTileVM = new LiveTileViewModel(); // @@
            liveTileVM.Day = DateTime.Now.Day;
            liveTileVM.WeekDay = DateTime.Now.ToString("ddd");
            liveTileVM.TileWidth = b.PixelWidth - 10;
            liveTileVM.TileHeight = b.PixelHeight;
            liveTileVM.ForegroundBrush = Application.Current.Resources["PhoneForegroundBrush"] as Brush;

            var liveTileControl = new LiveTileControl();
            liveTileControl.DataContext = liveTileVM; // @@ Binding using StaticResource does not work.

            b.Render(liveTileControl, null);
            b.Invalidate(); //Draw bitmap

            //Save bitmap as jpeg file in Isolated Storage
            using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream imageStream = new IsolatedStorageFileStream(TileBitmapFile,
                    System.IO.FileMode.Create, isf))
                {
                    var encoder = new PngEncoder();
                    encoder.Encode(b.ToImage(), imageStream);
                }
            }
        }

        public void CreateApplicationTile()
        {
            CreateTileBitmap(FlipMediumWidth, FlipMediumHeight);
            
            var appTile = ShellTile.ActiveTiles.First();
            if (appTile == null)
                return;
          
            var store = IsolatedStorageFile.GetUserStoreForApplication();
            var standardTile = new StandardTileData
                {
                    BackgroundImage = new Uri(@"isostore:" + TileBitmapFile, UriKind.Absolute),
                };
            appTile.Update(standardTile);
        }
    }
}
