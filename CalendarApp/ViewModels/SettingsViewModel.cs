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
            var appBrushesVM = Ioc.Get<AppBrushesViewModel>();

            ForegroundColor = new ColorPickerViewModel
                {
                    Header = "Foreground",
                    SelectedColor = new ColorItem(AppSettings.Instance.ForegroundColor) { Name = "Default" }
                };
            ForegroundColor.PropertyChanged += (sender, e) =>
                {
                    AppSettings.Instance.ForegroundColor = ForegroundColor.SelectedColor.Color;
                    appBrushesVM.Reload();
                };

            BackgroundColor = new ColorPickerViewModel
                {
                    Header = "Background",
                    SelectedColor = new ColorItem(AppSettings.Instance.BackgroundColor) { Name = "Default" }
                };
            BackgroundColor.PropertyChanged += (sender, e) =>
                {
                    AppSettings.Instance.BackgroundColor = BackgroundColor.SelectedColor.Color;
                    appBrushesVM.Reload();
                };

            WeekendBackgroundColor = new ColorPickerViewModel
                {
                    Header = "Weekend background",
                    SelectedColor = new ColorItem(AppSettings.Instance.WeekendBackgroundColor) { Name = "Default" }
                };
            WeekendBackgroundColor.PropertyChanged += (sender, e) =>
                {
                    AppSettings.Instance.WeekendBackgroundColor = WeekendBackgroundColor.SelectedColor.Color;
                    appBrushesVM.Reload();
                };
        }
    }
}
