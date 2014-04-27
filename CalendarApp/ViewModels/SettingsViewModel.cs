using CalendarApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalendarApp.ViewModels
{
    public class SettingsViewModel
    {
        public ColorPickerViewModel ForegroundColor { get; set; }

        public ColorPickerViewModel BackgroundColor { get; set; }

        public ColorPickerViewModel WeekendBackgroundColor { get; set; }

        public SettingsViewModel()
        {
            ForegroundColor = new ColorPickerViewModel { Header = "Foreground" };
            BackgroundColor = new ColorPickerViewModel { Header = "Background" };
            WeekendBackgroundColor = new ColorPickerViewModel { Header = "Weekend background" };
        }
    }
}
