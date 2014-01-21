using CalendarApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalendarApp.Logic
{
    public interface IDayList
    {
        DayModel CurrentDay { get; set; }
    }
}
