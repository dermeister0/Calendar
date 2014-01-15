using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace CalendarApp.Models
{
    class DayModel
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
            set
            {
                isToday = value;
                if (IsToday)
                    BorderBrush = App.Current.Resources["PhoneAccentBrush"] as Brush; // @@
            }
        }

        public Brush BorderBrush { get; set; }

        public DayModel()
        {
            BorderBrush = App.Current.Resources["PhoneForegroundBrush"] as Brush; // @@
        }
    }
}
