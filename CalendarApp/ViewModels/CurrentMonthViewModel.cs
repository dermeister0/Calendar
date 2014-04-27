using CalendarApp.Util;
using CalendarApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace CalendarApp.ViewModels
{
    public class CurrentMonthViewModel
    {
        public ICommand GoToSettingsCommand { get; set; }

        public CurrentMonthViewModel()
        {
            GoToSettingsCommand = new ActionCommand(OnGoToSettings);
        }

        void OnGoToSettings()
        {
            Ioc.Get<NavigationService>().Navigate("/Pages/SettingsPage.xaml");
        }
    }
}
