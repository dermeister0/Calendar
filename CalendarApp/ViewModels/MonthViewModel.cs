using CalendarApp.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalendarApp.ViewModels
{
    class MonthViewModel
    {
        IDayList dayList;

        public MonthViewModel(IDayList dayList)
        {
            this.dayList = dayList;
        }
    }
}
