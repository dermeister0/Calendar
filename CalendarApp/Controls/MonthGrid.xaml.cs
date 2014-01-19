using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using CalendarApp.Utils;
using CalendarApp.Models;
using System.Globalization;
using Microsoft.Phone.UserData;

namespace CalendarApp.Controls
{
    public partial class MonthGrid : UserControl
    {
        DateTime today;

        DateTime startDate;

        DateTime finishDate;

        bool hasTodayCell;

        DayModel[] days;

        public MonthGrid()
        {
            InitializeComponent();

            today = DateTime.Today;
            startDate = new DateTime(today.Year, today.Month, 1);
            finishDate = startDate.AddMonths(1).AddDays(-1);

            Init();
        }

        void Init()
        {
            MonthCellGrid.Children.Clear();

            days = new DayModel[finishDate.Day];
            for (int i = 0; i < finishDate.Day; i++)
                days[i] = new DayModel { Day = i + 1 };

            var model = new MonthModel
            {
                Year = startDate.Year,
                MonthName = CultureInfo.CurrentUICulture.DateTimeFormat.MonthNames[startDate.Month - 1].ToLower()
            };
            DataContext = model;

            hasTodayCell = today.Month == startDate.Month && today.Year == startDate.Year;

            LoadAppointments();
        }

        void CreateCells()
        {
            CreateWeekDays();

            var emptyDay = new DayModel();

            int day = 2 - CalendarSupport.GetDayNumber(startDate.DayOfWeek);
            for (int w = 0; w < CalendarSupport.WeeksInMonth; w++)
            {
                for (int d = 0; d < CalendarSupport.DaysInWeek; d++)
                {
                    var cell = new DayCell();
                    Grid.SetRow(cell, w + 1);
                    Grid.SetColumn(cell, d);

                    DayModel model = emptyDay;

                    if (day > 0 && day <= finishDate.Day)
                    {
                        model = days[day - 1];

                        if (hasTodayCell && day == today.Day)
                            model.IsToday = true;
                    }

                    cell.DataContext = model;

                    MonthCellGrid.Children.Add(cell);
                    day++;
                }
            }
        }

        void CreateWeekDays()
        {
            var dayNames = CultureInfo.CurrentUICulture.DateTimeFormat.ShortestDayNames;

            for (int i = 0; i < CalendarSupport.DaysInWeek; i++)
            {
                var label = new TextBlock();
                label.Text = dayNames[CalendarSupport.GetIndexOfDay(i)].ToLower();
                label.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                label.Style = App.Current.Resources["PhoneTextTitle3Style"] as Style;

                Grid.SetColumn(label, i);
                MonthCellGrid.Children.Add(label);
            }
        }

        public void NextMonth()
        {
            startDate = startDate.AddMonths(1);
            finishDate = startDate.AddMonths(1).AddDays(-1);
            Init();
        }

        public void PreviousMonth()
        {
            startDate = startDate.AddMonths(-1);
            finishDate = startDate.AddMonths(1).AddDays(-1);
            Init();
        }

        void LoadAppointments()
        {
            var appointments = new Appointments();
            appointments.SearchCompleted += (sender, e) =>
                {
                    for (int i = 0; i < days.Length; i++)
                    {
                        var tmpDate = new DateTime(startDate.Year, startDate.Month, i + 1);
                        var events = e.Results.Where(a => a.StartTime >= tmpDate && a.StartTime < tmpDate.AddDays(1));

                        days[i].HasEvents = events.Any();
                    }

                    CreateCells();
                };

            appointments.SearchAsync(startDate, finishDate.AddDays(1).AddSeconds(-1), null);
        }
    }
}
