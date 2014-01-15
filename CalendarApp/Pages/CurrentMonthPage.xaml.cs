using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace CalendarApp.Pages
{
    public partial class CurrentMonthPage : PhoneApplicationPage
    {
        public CurrentMonthPage()
        {
            InitializeComponent();
        }

        protected override void OnOrientationChanged(OrientationChangedEventArgs e)
        {
            base.OnOrientationChanged(e);

            var minSize = Math.Min(ActualWidth, ActualHeight);
            CurrentMonthGrid.Width = minSize;
            CurrentMonthGrid.Height = minSize;
        }
    }
}