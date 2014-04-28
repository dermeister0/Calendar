using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace CalendarApp.ViewModels
{
    public class LiveTileViewModel : BaseViewModel
    {
        int tileWidth;

        public int TileWidth
        {
            get { return tileWidth; }
            set
            {
                tileWidth = value;
                OnPropertyChanged("TileWidth");
                OnPropertyChanged("WeekDayWidth");
            }
        }

        int tileHeight;

        public int TileHeight
        {
            get { return tileHeight; }
            set
            {
                tileHeight = value;
                OnPropertyChanged("TileHeight");
            }
        }

        int day;

        public int Day
        {
            get { return day; }
            set
            {
                day = value;
                OnPropertyChanged("Day");
            }
        }

        Brush foregroundBrush;

        public Brush ForegroundBrush
        {
            get { return foregroundBrush; }
            set
            {
                foregroundBrush = value;
                OnPropertyChanged("ForegroundBrush");
            }
        }

        int weekDayWidth;

        public int WeekDayWidth
        {
            get { return tileWidth / 2; }
        }

        string weekDay;

        public string WeekDay
        {
            get { return weekDay; }
            set
            {
                weekDay = value;
                OnPropertyChanged("WeekDay");
            }
        }
    }
}
