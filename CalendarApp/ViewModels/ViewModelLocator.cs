using CalendarApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalendarApp.ViewModels
{
    public class ViewModelLocator
    {
        public MonthViewModel MonthVM
        {
            get { return Ioc.Get<MonthViewModel>(); }
        }

        public SettingsViewModel SettingsVM
        {
            get { return Ioc.Get<SettingsViewModel>(); }
        }

        public CurrentMonthViewModel CurrentMonthVM
        {
            get { return Ioc.Get<CurrentMonthViewModel>(); }
        }

        public LiveTileViewModel LiveTileVM
        {
            get { return Ioc.Get<LiveTileViewModel>(); }
        }
    }
}
