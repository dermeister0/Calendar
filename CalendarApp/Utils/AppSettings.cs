using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace CalendarApp.Utils
{
    public class AppSettings : AppSettingsBase
    {
        public Color BackgroundColor
        {
            get
            {
                var defaultColor = (Color)App.Current.Resources["PhoneBackgroundColor"];

                return GetValueOrDefault<Color>("BackgroundColor", defaultColor);
            }
            set { AddOrUpdateValueAndSave("BackgroundColor", value); }
        }

        public Color WeekendBackgroundColor
        {
            get
            {
                var defaultColor = (Color)App.Current.Resources["PhoneBackgroundColor"];

                return GetValueOrDefault<Color>("WeekendBackgroundColor", defaultColor);
            }
            set { AddOrUpdateValueAndSave("WeekendBackgroundColor", value); }
        }

        public Color ForegroundColor
        {
            get
            {
                var defaultColor = (Color)App.Current.Resources["PhoneForegroundColor"];

                return GetValueOrDefault<Color>("ForegroundColor", defaultColor);
            }
            set { AddOrUpdateValueAndSave("ForegroundColor", value); }
        }

        public static AppSettings Instance
        {
            get
            {
                return App.Current.Resources["AppSettings"] as AppSettings;
            }
        }
    }
}
