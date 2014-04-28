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

        public Color WeekendColor
        {
            get
            {
                var defaultColor = PhoneThemeColors.Red;

                return GetValueOrDefault<Color>("WeekendColor", defaultColor);
            }
            set { AddOrUpdateValueAndSave("WeekendColor", value); }
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
