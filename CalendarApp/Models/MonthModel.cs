using CalendarApp.Utils;
using CalendarApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalendarApp.Models
{
    public class MonthModel
    {
        public int Year { get; set; }

        public string MonthName { get; set; }

        public AppBrushesViewModel AppBrushesVM { get; set; }

        public MonthModel()
        {
            AppBrushesVM = Ioc.Get<AppBrushesViewModel>();
        }
    }
}
