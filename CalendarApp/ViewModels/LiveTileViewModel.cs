using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace CalendarApp.ViewModels
{
    public class LiveTileViewModel
    {
        public int TileWidth { get; set; }

        public int TileHeight { get; set; }

        public int Day { get; set; }

        public Brush ForegroundBrush { get; set; }
    }
}
