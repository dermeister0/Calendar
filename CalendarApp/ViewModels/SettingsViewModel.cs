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

        public ColorPickerViewModel WeekendColor { get; set; }

        public SettingsViewModel()
        {
            var appBrushesVM = Ioc.Get<AppBrushesViewModel>();

            ForegroundColor = new ColorPickerViewModel
                {
                    Header = "Foreground color",
                    SelectedColor = new ColorItem(AppSettings.Instance.ForegroundColor) { Name = "Default" }
                };
            ForegroundColor.PropertyChanged += (sender, e) =>
                {
                    AppSettings.Instance.ForegroundColor = ForegroundColor.SelectedColor.Color;
                    appBrushesVM.Reload();
                };

            BackgroundColor = new ColorPickerViewModel
                {
                    Header = "Background color",
                    SelectedColor = new ColorItem(AppSettings.Instance.BackgroundColor) { Name = "Default" }
                };
            BackgroundColor.PropertyChanged += (sender, e) =>
                {
                    AppSettings.Instance.BackgroundColor = BackgroundColor.SelectedColor.Color;
                    appBrushesVM.Reload();
                };

            WeekendColor = new ColorPickerViewModel
                {
                    Header = "Weekend color",
                    SelectedColor = new ColorItem(AppSettings.Instance.WeekendColor) { Name = "Default" }
                };
            WeekendColor.PropertyChanged += (sender, e) =>
                {
                    AppSettings.Instance.WeekendColor = WeekendColor.SelectedColor.Color;
                    appBrushesVM.Reload();
                };
        }
    }
}
