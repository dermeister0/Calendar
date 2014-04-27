using CalendarApp.Utils;
using CalendarApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace CalendarApp.Models
{
    public class DayModel : BaseViewModel
    {
        int day;

        public int Day 
        { 
            get { return day; }
            set
            {
                day = value;
                IsTextVisible = day != 0 ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public Visibility IsTextVisible { get; set; }

        bool isToday;

        public bool IsToday 
        { 
            get { return isToday; }
            set { isToday = value; }
        }

        public Brush BorderBrush
        {
            get
            {
                if (IsWeekend)
                    return IsToday ? appBrushesVM.BackgroundBrush : appBrushesVM.WeekendBackgroundBrush;
                else
                    return IsToday ? appBrushesVM.BackgroundBrush : appBrushesVM.ForegroundBrush;
            }
        }

        public Brush BackgroundBrush
        {
            get
            {
                if (IsWeekend)
                    return IsToday ? appBrushesVM.WeekendBackgroundBrush : appBrushesVM.BackgroundBrush;
                else
                    return IsToday ? appBrushesVM.ForegroundBrush : appBrushesVM.BackgroundBrush;
            }
        }

        bool hasEvents;

        public bool HasEvents
        {
            get { return hasEvents; }
            set
            {
                hasEvents = value;
                IsEventsFlagVisible = hasEvents ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public Visibility IsEventsFlagVisible { get; set; }

        AppBrushesViewModel appBrushesVM;

        public bool IsWeekend { get; set; }

        public DayModel()
        {
            appBrushesVM = Ioc.Get<AppBrushesViewModel>();
            appBrushesVM.PropertyChanged += (sender, e) =>
                {
                    OnPropertyChanged("BorderBrush");
                    OnPropertyChanged("BackgroundBrush");
                };

            IsTextVisible = Visibility.Collapsed;
            IsEventsFlagVisible = Visibility.Collapsed;
        }
    }
}
