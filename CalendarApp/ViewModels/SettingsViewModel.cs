using CalendarApp.Models;
using CalendarApp.Utils;
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
            ForegroundColor = new ColorPickerViewModel
                {
                    Header = "Foreground",
                    SelectedColor = new ColorItem(AppSettings.Instance.ForegroundColor) { Name = "Default" }
                };
            BackgroundColor = new ColorPickerViewModel
                {
                    Header = "Background",
                    SelectedColor = new ColorItem(AppSettings.Instance.BackgroundColor) { Name = "Default" }
                };
            WeekendBackgroundColor = new ColorPickerViewModel
                {
                    Header = "Weekend background",
                    SelectedColor = new ColorItem(AppSettings.Instance.WeekendBackgroundColor) { Name = "Default" }
                };
        }
    }
}
