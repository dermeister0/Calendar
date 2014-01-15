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

namespace CalendarApp.Controls
{
    public partial class MonthGrid : UserControl
    {
        public MonthGrid()
        {
            InitializeComponent();

            for (int w = 0; w < CalendarSupport.WeeksInMonth; w++)
            {
                for (int d = 0; d < CalendarSupport.DaysInWeek; d++)
                {
                    var cell = new DayCell();
                    Grid.SetRow(cell, w + 1);
                    Grid.SetColumn(cell, d);

                    MonthCellGrid.Children.Add(cell);
                }
            }
        }

        void CreateCells()
        {
        }
    }
}
