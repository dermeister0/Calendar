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

namespace CalendarApp.Controls
{
    public partial class MonthGrid : UserControl
    {
        DateTime today;

        DateTime startDate;

        DateTime finishDate;

        bool hasTodayCell;

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

            var model = new MonthModel
                {
                    Year = startDate.Year,
                    MonthName = CultureInfo.CurrentUICulture.DateTimeFormat.MonthNames[startDate.Month - 1].ToLower()
                };
            DataContext = model;

            hasTodayCell = today.Month == startDate.Month && today.Year == startDate.Year;

            CreateCells();
        }

        void CreateCells()
        {
            CreateWeekDays();

            int day = 2 - CalendarSupport.GetDayNumber(startDate.DayOfWeek);
            for (int w = 0; w < CalendarSupport.WeeksInMonth; w++)
            {
                for (int d = 0; d < CalendarSupport.DaysInWeek; d++)
                {
                    var cell = new DayCell();
                    Grid.SetRow(cell, w + 1);
                    Grid.SetColumn(cell, d);

                    var model = new DayModel();

                    if (day > 0 && day <= finishDate.Day)
                        model.Day = day;
                    else
                        model.Day = 0;

                    if (hasTodayCell && day == today.Day)
                        model.IsToday = true;

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
    }
}
