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
    }
}
