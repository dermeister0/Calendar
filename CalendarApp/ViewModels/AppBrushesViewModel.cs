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

        public Brush WeekendBackgroundBrush { get; private set; }

        public Brush ForegroundBrush { get; private set; }

        public AppBrushesViewModel()
        {
            Reload();
        }

        public void Reload()
        {
            var appSettings = AppSettings.Instance;

            BackgroundBrush = new SolidColorBrush(appSettings.BackgroundColor);
            WeekendBackgroundBrush = new SolidColorBrush(appSettings.WeekendBackgroundColor);
            ForegroundBrush = new SolidColorBrush(appSettings.ForegroundColor);
        }
    }
}
