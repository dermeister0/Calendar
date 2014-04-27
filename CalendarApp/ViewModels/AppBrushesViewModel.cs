using CalendarApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace CalendarApp.ViewModels
{
    public class AppBrushesViewModel : BaseViewModel
    {
        Brush backgroundBrush;

        public Brush BackgroundBrush
        {
            get { return backgroundBrush; }
            private set
            {
                backgroundBrush = value;
                OnPropertyChanged("BackgroundBrush");
            }
        }

        Brush weekendBrush;
        
        public Brush WeekendBrush
        {
            get { return weekendBrush; }
            private set
            {
                weekendBrush = value;
                OnPropertyChanged("WeekendBrush");
            }
        }

        Brush foregroundBrush;

        public Brush ForegroundBrush
        {
            get { return foregroundBrush; }
            private set
            {
                foregroundBrush = value;
                OnPropertyChanged("ForegroundBrush");
            }
        }

        public AppBrushesViewModel()
        {
            Reload();
        }

        public void Reload()
        {
            var appSettings = AppSettings.Instance;

            BackgroundBrush = new SolidColorBrush(appSettings.BackgroundColor);
            WeekendBrush = new SolidColorBrush(appSettings.WeekendColor);
            ForegroundBrush = new SolidColorBrush(appSettings.ForegroundColor);
        }
    }
}
